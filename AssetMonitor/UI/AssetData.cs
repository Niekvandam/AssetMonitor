using AssetMonitor.Databases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetMonitor
{
    //TODO custom class for data retrieval from live DB
    public partial class AssetData : Form
    {
        //The assetId given when creating this class
        private string _assetId;

        //The local user that had most recently used the asset
        private string _localUser;

        private LiveDB _liveDB;

        public AssetData(string connString, string assetId, string localUser)
        {
            InitializeComponent();
            _localUser = localUser;
            _assetId = assetId;
            _liveDB = new LiveDB(new SqlConnection(connString));
            SetFormValues();
            InitializeAssetData();
        }

        //Sets title and name of the groupbox to the assetId
        private void SetFormValues()
        {
            this.Text += "  " + _assetId;
            groupBox1.Text += "  " + _assetId;
        }



        private void DisplayDataValidity(int dataValidity)
        {
            switch (dataValidity)
            {
                case 0:
                    textBoxAssetNotFound.Visible = true;
                    break;
                case 1:
                    textBoxAssetNotFound.Text = "Asset not bound to user in clientele";
                    textBoxAssetNotFound.ForeColor = Color.Orange;
                    textBoxAssetNotFound.Visible = true;
                    break;
                case 2:
                    textBoxAssetNotFound.Text = "All data is valid";
                    textBoxAssetNotFound.ForeColor = Color.MediumSeaGreen;
                    textBoxAssetNotFound.Visible = true;
                    break;
                case 3:
                    textBoxAssetNotFound.ForeColor = Color.Orange;
                    textBoxAssetNotFound.Text = "Users do not match in Clientele and Local DB";
                    textBoxAssetNotFound.Show();
                    break;
            }

        }

        private void InitializeAssetData()
        {
            DataTable datatable = null;
            switch (_liveDB.GetDataValidity(_assetId))
            {
                case 0:
                    DisplayDataValidity(0);
                    break;
                case 1:
                    DisplayDataValidity(1);
                    datatable = _liveDB.GetUserData(false, _assetId);
                    FillAssetDataFields(datatable, 1);
                    break;
                case 2:
                    DisplayDataValidity(2);
                    datatable = _liveDB.GetUserData(true, _assetId);
                    FillAssetDataFields(datatable, 2);
                    break;

            }
        }


        private void FillAssetDataFields(DataTable datatable, int assetvalidity)
        {
            DataRow row = datatable.Rows[0];
            localUserTextBox.Text = _localUser;
            switch (assetvalidity)
            {
                case 1:
                    assetStatusTextBox.Text = (row["Entry"] == DBNull.Value) ? "No asset status found" : (string)row["Entry"];
                    assetDescriptionTextBox.Text = (row["Description"] == DBNull.Value) ? "No description found" : (string)row["Description"];
                    serialNumberTextBox.Text = (row["SerialNumber"] == DBNull.Value) ? "No serial number found" : (string)row["SerialNumber"];
                    assetNumberTextBox.Text = (row["AssetNumber"] == DBNull.Value) ? "No asset number found" : (string)row["AssetNumber"];
                    commentsTextBox.Text = (row["Notes"] == DBNull.Value) ? "No notes available" : (string)row["Notes"];
                    break;
                case 2:
                    userStatusTextBox.Text = (row["Alert"] == DBNull.Value) ? "Active" : (string)row["Alert"];
                    personnelNumberTextBox.Text = (row["PersonnelNumber"] == DBNull.Value) ? "No personnel number" : (string)row["PersonnelNumber"];
                    assetUserTextBox.Text = (row["fullName"] == DBNull.Value) ? "No user found" : (string)row["fullName"];
                    if ((string)row["Username"] != _localUser)
                    {
                        DisplayDataValidity(3);
                    }
                    if (row["comments"] != null)
                    {
                        commentsTextBox.Text = (row["comments"] == DBNull.Value) ? "No comments available" : (string)row["comments"];
                    }
                    //Call recursive to fill in the non-party related fields
                    FillAssetDataFields(_liveDB.GetUserData(false, _assetId), assetvalidity);
                    break;
            }
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }
    }
}
