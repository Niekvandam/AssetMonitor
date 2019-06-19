using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Security;
using System.Windows.Forms;
using System.Xml;
using AssetMonitor.Databases;

namespace AssetMonitor
{
    public partial class AssetMonitor : Form
    {
        //List with loginstats
        private BindingList<Loginstat> loginstats = new BindingList<Loginstat>();

        //Child forms
        private UserData userDataForm;
        private AssetData assetDataForm;

        //Live & Local db variables
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _server = string.Empty;
        private string _database = string.Empty;
        private string _databaseLocation;
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private SqlConnection liveConn;
        private SqlCommand liveCmd;

        private string _liveDBConnString;

        /// <summary>
        /// While creating the WinForm, read variables from the secret.xml and create both local and live connections
        /// </summary>
        public AssetMonitor()
        {
            InitializeComponent();
            InitializeVariables();
            CreateLiveConnection();
            CreateLocalConnection();
            beforeRadioButton.Checked = true;
        }

        /// <summary>
        /// Read the settings.SECRET.xml, which you will have to create yourself. In there you can put the live and local server data
        /// </summary>
        private void InitializeVariables()
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Users\DamN\Documents\Visual studio\AssetMonitor\AssetMonitor\settings.SECRET.xml"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "live_server_name":
                                _server = reader.ReadString();
                                break;
                            case "live_server_db":
                                _database = reader.ReadString();
                                break;
                            case "live_server_user":
                                _username = reader.ReadString();
                                break;
                            case "live_server_pass":
                                _password = reader.ReadString();
                                break;
                            case "local_db_path":
                                _databaseLocation = reader.ReadString();
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a connection with the live database with the variables previously read out in the xml reader
        /// </summary>
        private void CreateLiveConnection()
        {
            _liveDBConnString = String.Format(@"Server={0};Database={1};User Id={2};Password={3}", _server, _database, _username, _password);
            liveConn = new SqlConnection(_liveDBConnString);
            liveCmd = new SqlCommand("", liveConn);
        }

        /// <summary>
        /// Creates a local db connection with the given .db location
        /// </summary>
        private void CreateLocalConnection()
        {
            conn = new SQLiteConnection("data source=" + _databaseLocation);
            cmd = new SQLiteCommand(conn);
            dbLocationTextBox.Text = _databaseLocation;
        }


        /// <summary>
        /// Opens an OpenFileDialog where you can choose your .db file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseFileSelectButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Please select a Data Base file";
            openFileDialog1.Filter = "Data Base files(*.db)|*.db";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _databaseLocation = openFileDialog1.FileName;
                    dbLocationTextBox.Text = _databaseLocation;
                    CreateLocalConnection();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error. \n\n Error message: {ex.Message} \n\n" +
                        $"Details: \n\n{ex.StackTrace}");
                }
            }
            validateCheckAssetsButtonEnabled();
        }

        /// <summary>
        /// When this button is clicked, the local db connection will execute one of the 4 sql commands, based on what was selected in the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAssetsButton_Click(object sender, EventArgs e)
        {
            LocalDB localDB = new LocalDB("data source=" + _databaseLocation);
            LiveDB liveDB = new LiveDB(String.Format(@"Server={0};Database={1};User Id={2};Password={3}", _server, _database, _username, _password));
            SQLiteDataReader SQLiteDataResult;

            string filterDate = filterDatePicker.Value.ToString("yyyy-MM-dd");
            int selectedCommand = commandListComboBox.SelectedIndex;
            switch (selectedCommand)
            {
                case 0:
                    SQLiteDataResult = localDB.GetCurrentAssetStats();
                    break;
                case 1:
                    SQLiteDataResult = localDB.GetAssetStatsByName(assetNumberTextBox.Text);
                    break;
                case 2:
                    throw new NotImplementedException();
                case 3:
                    if (beforeRadioButton.Checked || afterRadioButton.Checked)
                    {
                        if (afterRadioButton.Checked)
                        {
                            SQLiteDataResult = localDB.GetAssetDataBetweenDatesGreater(filterDate);
                        }
                        else
                        {
                            SQLiteDataResult = localDB.GetAssetDataBetweenDatesLesser(filterDate);
                        }
                    }
                    break;
                case 4:
                    SQLiteDataReader localResult = localDB.GetCurrentAssetStats();
                    
                    //TODO write good live DB query 
                    //SqlDataReader liveResults = liveDB.GetUserDataWithParty();
                    break;
            }
            fillDataGrid(selectedCommand);
        }

        private void fillDataGrid(int selectedIndexFromDropdown)
        {
            loginstats.Clear();
            conn.Open();
            if (cmd.CommandText != null)
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (selectedIndexFromDropdown == 4)
                        {
                            using (SqlDataReader sqlReader = liveCmd.ExecuteReader())
                            {

                            }

                            liveCmd.Parameters.AddWithValue("@assetId", (string)reader["werkplekid"]);
                        }
                        loginstats.Add(new Loginstat(Convert.ToDateTime((string)reader["datum"]), (string)reader["tijd"], (string)reader["server"], (string)reader["loginid"], (string)reader["werkplekid"]));

                    }
                }
                loginstatDataGrid.DataSource = loginstats;
                loginstatDataGrid.Refresh();
                validateFilterBoxesEnabled();
            }
            conn.Close();
        }

        #region check for enabled objects

        /// <summary>
        /// Determines whether the checkAssetsButton should be enabled or not
        /// </summary>
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

        /// <summary>
        /// Dethermines whether the filter boxes should be enabled or not
        /// </summary>
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

        /// <summary>
        /// Checks wheter the selected index should enable filtering or textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// If the text is changed, rebase the datagrid on the text changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// If the text is changed, rebase the datagrid on the text changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssetIdTextBox_TextChanged(object sender, EventArgs e)
        {
            var filteredStats = new List<Loginstat>();
            foreach (Loginstat stat in loginstats)
            {
                if (stat.AssetId.ToLower().Contains(assetIdTextBox.Text.ToLower()))
                    filteredStats.Add(stat);
            }
            loginstatDataGrid.DataSource = filteredStats;
        }

        #endregion

        private void LoginstatDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var userId = loginstatDataGrid.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (e.ColumnIndex == 0)
            {
                return;
            }
            if (e.ColumnIndex == 3)
            {
                userDataForm = new UserData(conn, userId);
                userDataForm.Show();
            }
            else if (e.ColumnIndex == 4)
            {
                var assetId = loginstatDataGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                assetDataForm = new AssetData(_liveDBConnString, assetId, userId);
                assetDataForm.Show();
            }
        }
    }
}
