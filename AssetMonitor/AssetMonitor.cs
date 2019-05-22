using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Security;
using System.Windows.Forms;

namespace AssetMonitor
{
    public partial class AssetMonitor : Form
    {
        private string databaseLocation;
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private BindingList<Loginstat> loginstats = new BindingList<Loginstat>();
        UserData userDataForm;
        static readonly string FORMATTED_DATE = " DATE(substr(datum,7,4)||'-'||substr(datum,4,2)||'-'||substr(datum,1,2))";
        static readonly string DATUM_ORDER_DESC = String.Format(" ORDER BY {0} DESC", FORMATTED_DATE);
        static readonly string GROUP_WERKPLEKID = " GROUP BY werkplekid";

        public AssetMonitor()
        {
            InitializeComponent();
            beforeRadioButton.Checked = true;
        }

        private void InitializeDataBase()
        {
            conn = new SQLiteConnection("data source=" + databaseLocation);
            cmd = new SQLiteCommand(conn);

        }


        private void DatabaseFileSelectButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Please select a Data Base file";
            openFileDialog1.Filter = "Data Base files(*.db)|*.db";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    databaseLocation = openFileDialog1.FileName;
                    dbLocationTextBox.Text = databaseLocation;
                    InitializeDataBase();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error. \n\n Error message: {ex.Message} \n\n" +
                        $"Details: \n\n{ex.StackTrace}");
                }
            }
            validateCheckAssetsButtonEnabled();
        }

        private void CheckAssetsButton_Click(object sender, EventArgs e)
        {

            string filterDate = filterDatePicker.Value.ToString("yyyy-MM-dd");
            
            switch (commandListComboBox.SelectedIndex)
            {
                case 0:
                    cmd.CommandText = string.Format(@"select * from loginstats {0} {1}", GROUP_WERKPLEKID, DATUM_ORDER_DESC);
                    break;
                case 1:
                    cmd.CommandText = string.Format(@"select * from loginstats where werkplekid LIKE '%{0}%' {1}",  assetNumberTextBox.Text, DATUM_ORDER_DESC);
                    break;
                case 2:
                    break;
                case 3:
                    if (beforeRadioButton.Checked || afterRadioButton.Checked)
                    {
                        if (afterRadioButton.Checked)
                        {
                            cmd.CommandText = String.Format(@"SELECT * FROM loginstats WHERE {0} >= '{1}' {2} {3}", FORMATTED_DATE, filterDate, GROUP_WERKPLEKID, " ORDER BY datum DESC");
                        }
                        else
                        {
                            cmd.CommandText = String.Format(@"SELECT * FROM loginstats WHERE {0} <= '{1}' {2} {3}", FORMATTED_DATE, filterDate, GROUP_WERKPLEKID, DATUM_ORDER_DESC);

                        }
                    }
                    break;
            }

            loginstats.Clear();
            conn.Open();
            if (cmd.CommandText != null)
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loginstats.Add(new Loginstat(Convert.ToDateTime((string)reader["datum"]), (string)reader["tijd"], (string)reader["server"], (string)reader["loginid"], (string)reader["werkplekid"]));
                    }
                }
                loginstatDataGrid.DataSource = loginstats;
                loginstatDataGrid.Refresh();
                validateFilterBoxesEnabled();
            }
            conn.Close();
        }
        private void LoginstatDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var userId = loginstatDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
            userDataForm = new UserData(conn, userId);
            userDataForm.Show();
        }


        #region check for enabled objects
        public void validateCheckAssetsButtonEnabled()
        {
            if (dbLocationTextBox.Text != string.Empty && commandListComboBox.SelectedIndex != -1)
            {
                checkAssetsButton.Enabled = true;
            }
            else
            {
                checkAssetsButton.Enabled = false;
            }
        }

        public void validateFilterBoxesEnabled()
        {
            if (loginstats.Count != 0)
            {
                assetIdTextBox.Enabled = true;
                loginIdTextBox.Enabled = true;
            }
            else
            {
                assetIdTextBox.Enabled = false;
                loginIdTextBox.Enabled = false;
            }
        }


        private void CommandListComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (commandListComboBox.SelectedIndex == 1)
            {
                assetNumberTextBox.Enabled = true;
            }
            else if (commandListComboBox.SelectedIndex == 3)
            {
                dateFilteringGroupBox.Enabled = true;
            }
            else
            {
                dateFilteringGroupBox.Enabled = false;
                assetNumberTextBox.Enabled = false;
            }
            validateCheckAssetsButtonEnabled();
        }
        #endregion

        #region filters
        //TODO replace filters with more efficient ones using LINQ if time left
        private void LoginIdTextBox_TextChanged(object sender, EventArgs e)
        {
            var filteredStats = new List<Loginstat>();
            foreach (Loginstat stat in loginstats)
            {
                if (stat.LoginId.Contains(loginIdTextBox.Text))
                    filteredStats.Add(stat);
            }
            loginstatDataGrid.DataSource = filteredStats;
        }

        private void AssetIdTextBox_TextChanged(object sender, EventArgs e)
        {
            var filteredStats = new List<Loginstat>();
            foreach (Loginstat stat in loginstats)
            {
                if (stat.AssetId.Contains(assetIdTextBox.Text))
                    filteredStats.Add(stat);
            }
            loginstatDataGrid.DataSource = filteredStats;
        }


        #endregion

    }
}
