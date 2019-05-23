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
    public partial class AssetData : Form
    {
        //The assetId given when creating this class
        private string _assetId;

        //The local user that had most recently used the asset
        private string _localUser;

        //The sqlCommand that will be executed is already initialised.
        private SqlCommand _liveCmd;
        private SqlConnection _liveConn;
        private bool isInDB = false;


        public AssetData(SqlConnection conn, string assetId, string localUser)
        {
            InitializeComponent();
            _localUser = localUser;
            _assetId = assetId;
            _liveConn = conn;
            _liveCmd = new SqlCommand("", _liveConn);
            SetFormValues();
            initializeAssetData();
        }

        //Sets title and name of the groupbox to the assetId
        private void SetFormValues()
        {
            this.Text += "  " + _assetId;
            groupBox1.Text += "  " + _assetId;
        }

        private void initializeAssetData()
        {
            _liveConn.Open();
            _liveCmd = new SqlCommand(getCommandTextWithParty(_assetId), _liveConn);
            using (SqlDataReader reader = _liveCmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    FillAssetDataFields(reader, true);
                    textBoxAssetNotFound.Text = "All data is valid";
                    textBoxAssetNotFound.ForeColor = Color.MediumSeaGreen;
                    textBoxAssetNotFound.Visible = true;
                }
            }
            if (isInDB == false)
            {
                _liveCmd = new SqlCommand(getCommandTextWithoutParty(_assetId), _liveConn);
                using (SqlDataReader reader = _liveCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        FillAssetDataFields(reader, false);
                        textBoxAssetNotFound.Text = "Asset not bound to user in clientele";
                        textBoxAssetNotFound.ForeColor = Color.Orange;
                        textBoxAssetNotFound.Visible = true;
                    }
                }
            }
            _liveConn.Close();
            if (!isInDB)
            {
                textBoxAssetNotFound.Visible = true;
            }
        }

        private void FillAssetDataFields(SqlDataReader reader, bool isParty)
        {
            //TODO make fields be filled in dynamically
            assetStatusTextBox.Text = (reader["Entry"] == DBNull.Value) ? "No asset status found" : (string)reader["Entry"];
            assetDescriptionTextBox.Text = (reader["Description"] == DBNull.Value) ? "No description found" : (string)reader["Description"];
            serialNumberTextBox.Text = (reader["SerialNumber"] == DBNull.Value) ? "No serial number found" : (string)reader["SerialNumber"];
            assetNumberTextBox.Text = (reader["AssetNumber"] == DBNull.Value) ? "No asset number found" : (string)reader["AssetNumber"];
            if (isParty)
            {
                commentsTextBox.Text = (reader["Comments"] == DBNull.Value) ? "No comments available" : (string)reader["Comments"];
                userStatusTextBox.Text = (reader["Alert"] == DBNull.Value) ? "Active" : (string)reader["Alert"];
                personnelNumberTextBox.Text = (reader["PersonnelNumber"] == DBNull.Value) ? "No personnel number" : (string)reader["PersonnelNumber"];
                assetUserTextBox.Text = (reader["fullName"] == DBNull.Value) ? "No user found" : (string)reader["fullName"];
                if ((string)reader["Username"] != _localUser)
                {
                    textBoxAssetNotFound.Text = "Users do not match in Clientele and Local DB";
                    textBoxAssetNotFound.Show();
                }
            }
            else
            {
                commentsTextBox.Text = (reader["Notes"] == DBNull.Value) ? "No notes available" : (string)reader["Notes"];

            }
            localUserTextBox.Text = _localUser;
            isInDB = true;



        }



        /// <summary>
        /// Returns the command text for the clientele database query
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        private string getCommandTextWithParty(string assetId)
        {
            return @"SELECT a.username, 
                   a.alert, 
                   a.personnelnumber, 
                   a.fullname, 
                   a.active, 
                   a.comments, 
                   c.assetnumber, 
                   c.description, 
                   c.serialnumber, 
                   d.entry 
            FROM   person A, 
                   party B, 
                   product C, 
                   valuelistentry D 
            WHERE  b.personid = a.personid 
            AND    c.partyid = b.partyid 
            AND    c.productstatusid = d.valuelistentryid 
            AND    c.assetnumber = '" + assetId + "'";
        }
        /// <summary>
        /// Returns the command text for the clientele database query when there is no peson matched to the asset
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns></returns>
        private string getCommandTextWithoutParty(string assetId)
        {
            return @"SELECT c.description, 
                    c.serialNumber, 
                    c.assetNumber, 
                    c.notes,
                    d.entry
            FROM    product c, 
                    valuelistentry D
            WHERE   c.assetnumber = '" + assetId + "' " +
            "AND    c.productstatusid = d.valuelistentryid";
        }
        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
