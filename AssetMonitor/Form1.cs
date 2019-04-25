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

namespace AssetMonitor
{
    public partial class Form1 : Form
    {
        private string databaseLocation;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeDataBase()
        {
            string myConnectionString = "Data Source=" + databaseLocation + " ;Version=3;";
        }

        private void CommandListComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {

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
        }
    }
}
