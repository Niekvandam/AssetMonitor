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

namespace AssetMonitor
{
    public partial class Form1 : Form
    {
        private string databaseLocation;
        private SQLiteConnection conn;
        private SQLiteCommand cmd;


        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeDataBase()
        {
            conn = new SQLiteConnection("data source=" + databaseLocation);
            cmd = new SQLiteCommand(conn);

        }

        private void CommandListComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (commandListComboBox.SelectedIndex == 1)
            {
                assetNumberTextBox.Enabled = true;
            }
            else
            {
                assetNumberTextBox.Enabled = false;
            }
            validateCheckAssetsButtonEnabled();
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
            BindingList<Loginstat> loginstats = new BindingList<Loginstat>();
            conn.Open();
            switch (commandListComboBox.SelectedIndex)
            {
                case 0:
                    cmd.CommandText = @"select * from loginstats group by werkplekid";
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
            if (cmd.CommandText != null)
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        loginstats.Add(new Loginstat((string)reader["datum"], (string)reader["tijd"], (string)reader["server"], (string)reader["loginid"], (string)reader["werkplekid"]));
                    }
                }
                loginstatDataGrid.DataSource = loginstats;
                loginstatDataGrid.Refresh();
            }
            conn.Close();
        }

        public void validateCheckAssetsButtonEnabled()
        {
            if(dbLocationTextBox.Text != string.Empty && commandListComboBox.SelectedIndex != -1)
            {
                checkAssetsButton.Enabled = true;
            } else
            {
                checkAssetsButton.Enabled = false;
            }
        }

        private void LoginIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorkspaceIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
