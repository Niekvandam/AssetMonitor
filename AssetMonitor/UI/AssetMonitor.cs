using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
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
        private string _databaseLocation = string.Empty;
        private string _databaseLocationPorthos = string.Empty;
        private SQLiteConnection conn;
        private SQLiteCommand cmd;


        private string _liveDBConnString;


        private LocalDB localDB;
        private LiveDB liveDB;

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
            string assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string xmlPath = Path.Combine(assemblyPath, "settings.SECRET.xml");
            using (XmlReader reader = XmlReader.Create(xmlPath))
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
                            case "local_db_":
                                if (reader.ReadString() != null)
                                    _databaseLocation = reader.ReadString();
                                break;
                        }
                    }
                }
            }

        }

        /// <summary
        /// Creates a connection with the live database with the variables previously read out in the xml reader
        /// </summary>
        private void CreateLiveConnection()
        {
            _liveDBConnString = String.Format(@"Server={0};Database={1};User Id={2};Password={3}", _server, _database, _username, _password);
            liveDB = new LiveDB(new SqlConnection(_liveDBConnString));

        }

        /// <summary>
        /// Creates a local db connection with the given .db location
        /// </summary>
        private void CreateLocalConnection()
        {
            if (_databaseLocation != string.Empty)
            {
                conn = new SQLiteConnection("data source=" + _databaseLocation);
                cmd = new SQLiteCommand(conn);
                dbLocationTextBox.Text = _databaseLocation;
                localDB = new LocalDB(new SQLiteConnection(@"data source=" + _databaseLocation));
                var dbloc = new FileInfo(_databaseLocation).Directory.FullName;
                _databaseLocationPorthos = Path.Combine(($@"data source={dbloc}\\auditPorthos.db"));
            }
        }


        /// <summary>
        /// Opens an OpenFileDialog where you can choose your .db file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseFileSelectButton_Click(object sender, EventArgs e)
        {
            OpenDbFileDialog();
            validateCheckAssetsButtonEnabled();
        }

        /// <summary>
        /// When this button is clicked, the local db connection will execute one of the 4 sql commands, based on what was selected in the dropdown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckAssetsButton_Click(object sender, EventArgs e)
        {
            DataTable result = null;
            localDB._sqlConnection.Open();


            string filterDate = filterDatePicker.Value.ToString("yyyy-MM-dd");
            int selectedCommand = commandListComboBox.SelectedIndex;

            result = GetLocalAssetData(selectedCommand, filterDate);

            fillDataGrid(result, selectedCommand);
            if (assetValidityCheck.Checked)
            {
                checkAssetsButton.Enabled = false;
                Thread assetValidationThread = new Thread(ValidateAssets);
                assetValidationThread.Start();
                checkAssetsButton.Enabled = true;
            }
            exportToEmailButton.Enabled = true;
        }

        private DataTable GetLocalAssetData(int selectedCommand, string filterDate = null)
        {
            DataTable result = null;
            switch (selectedCommand)
            {
                case 0:
                    result = localDB.GetCurrentAssetStats();
                    break;
                case 1:
                    result = localDB.GetAssetStatsByName(assetNumberTextBox.Text);
                    break;
                case 2:
                    var dataTable = new DataTable();
                    dataTable.Columns.Add("AssetNumber");
                    dataTable.Columns.Add("Last Login");
                    dataTable.Columns.Add("Last User");
                    dataTable.Columns.Add("Description");
                    dataTable.Columns.Add("Status");
                    var porthosLocalDB = new LocalDB(new SQLiteConnection(_databaseLocationPorthos));
                    var porthosAssets = porthosLocalDB.GetCurrentAssetStats();
                    var veereAssets = localDB.GetCurrentAssetStats();
                    var clienteleAssets = liveDB.GetThinClients();
                    veereAssets.Merge(porthosAssets);
                    foreach (DataGridViewRow rows in clienteleAssets.Rows)
                    {
                        foreach (DataGridViewRow localRows in veereAssets.Rows)
                        {
                            if (rows.Cells[0].Value.ToString() == localRows.Cells[4].Value.ToString())
                            {
                                var time = TimeSpan.Parse(localRows.Cells[0].Value.ToString());
                                var date = DateTime.Parse(localRows.Cells[1].Value.ToString());
                                DateTime loginTime = date + time;
                                var lastLogin = localRows.Cells[0];
                                dataTable.Rows.Add(rows.Cells[0].Value.ToString(), loginTime, localRows.Cells[2].Value.ToString(), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString());
                                break;
                            }
                        }
                        continue;
                    }
                    break;
                case 3:
                    if (beforeRadioButton.Checked || afterRadioButton.Checked)
                    {
                        if (afterRadioButton.Checked)
                        {
                            result = localDB.GetAssetDataBetweenDatesGreater(filterDate);
                        }
                        else
                        {
                            result = localDB.GetAssetDataBetweenDatesLesser(filterDate);
                        }
                    }
                    break;
            }
            return result;
        }

        private void fillDataGrid(DataTable fetchedValues, int selectedCommandIndex)
        {
            loginstatDataGrid.DataSource = fetchedValues;
            loginstatDataGrid.Refresh();
            validateFilterBoxesEnabled();
            localDB._sqlConnection.Close();
        }

        private void ValidateAssets()
        {
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            foreach (DataGridViewRow row in loginstatDataGrid.Rows)
            {
                var assetId = row.Cells[4].ToString();
                var assetvalidity = liveDB.GetDataValidity(row.Cells[4].Value.ToString());
                switch (assetvalidity)
                {
                    case 1:
                        row.Cells[5].Value = "Conflicting data found";
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        break;
                    case 2:
                        row.DefaultCellStyle.BackColor = Color.SeaGreen;
                        row.Cells[5].Value = "Correct data found";
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.Red;
                        break;
                }
            }
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
            if (loginstatDataGrid.Rows.Count != 0)
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
                assetNumberGroupBox.Enabled = true;

            }
            else if (commandListComboBox.SelectedIndex == 3)
            {
                dateFilteringGroupBox.Enabled = true;
            }
            else
            {
                dateFilteringGroupBox.Enabled = false;
                assetNumberGroupBox.Enabled = false;
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
            foreach (DataGridViewRow row in loginstatDataGrid.Rows)
            {
                if (!row.Cells[3].Value.ToString().Contains(loginIdTextBox.Text))
                {
                }
            }
        }

        /// <summary>
        /// If the text is changed, rebase the datagrid on the text changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssetIdTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in loginstatDataGrid.Rows)
            {
                if (!row.Cells[4].Value.ToString().Contains(assetIdTextBox.Text))
                {
                }
            }
        }

        #endregion


        private void OpenDbFileDialog()
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
        }


        private void LoginstatDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != 0)
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

        private void AssetIdTextBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Warning! \n Using this filter will currently erease the colour scheme!", "Warning!");
        }

        private void LoginIdTextBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Warning! \n Using this filter will currently erease the colour scheme!", "Warning!");
        }
    }
}
