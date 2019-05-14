using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;

namespace AssetMonitor
{
    public partial class AssetMonitor : Form
    {
        private string databaseLocation;
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private BindingList<Loginstat> loginstats = new BindingList<Loginstat>();

        public AssetMonitor()
        {
            InitializeComponent();
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

            string filterDate = filterDatePicker.Value.ToString("yyyyMMdd");
            string betweenDate = string.Empty;

            switch (commandListComboBox.SelectedIndex)
            {
                case 0:
                    cmd.CommandText = @"select * from loginstats group by werkplekid";
                    break;
                case 1:
                    cmd.CommandText = @"select * from loginstats where werkplekId LIKE '%" + assetNumberTextBox.Text + "%'";
                    break;
                case 2:
                    break;
                case 3:
                    if (beforeRadioButton.Checked || afterRadioButton.Checked)
                    {
                        if (afterRadioButton.Checked)
                        {
                            cmd.CommandText = @"SELECT * FROM loginstats WHERE DATE(substr(datum,7,4)||'-'||substr(datum,4,2)||'-'||substr(datum,1,2)) >= '"  +  filterDate + "'";
                        }
                        else
                        {
                            cmd.CommandText = @"SELECT * FROM loginstats WHERE DATE(substr(datum,7,4)||'-'||substr(datum,4,2)||'-'||substr(datum,1,2)) <= '" + filterDate + "'";

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
            var userId = loginstatDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString(); ;
            if (userId != null)
            {
                UserData userDataForm = new UserData(conn, userId);
                userDataForm.Show();
            }
            else
            {
                MessageBox.Show("Invalid column selected!");
            }
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
            if (checkAssetsButton.Enabled)
                CheckAssetsButton_Click(sender, e);
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
