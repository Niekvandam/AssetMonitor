using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AssetMonitor
{
    public partial class UserData : Form
    {
        private SQLiteConnection _conn;
        private SQLiteCommand _cmd;
        private string _loginId;
        private List<Loginstat> _loginstats = new List<Loginstat>();
        private User _currentUser;

        public UserData(SQLiteConnection dbconnection, string loginId)
        {
            InitializeComponent();
            _conn = dbconnection;
            this._loginId = loginId;
            InitializeDataGrid();
            InitializeUserData();
        }

        private void InitializeUserData()
        {
            _conn.Open();
            _cmd.CommandText = @"Select * from ADusers where loginId = '" + _loginId + "'";
            SQLiteDataReader reader = _cmd.ExecuteReader();
            while (reader.Read())
            {
                _currentUser = new User((string)reader["Department"], (string)reader["Name"], (string)reader["JobTitle"], (string)reader["Telephone"], (string)reader["Email"], bool.Parse((string)reader["Active"]));
            }
            this.Name = _currentUser.Name;

            firstNameTextBox.Text = _currentUser.Name;
            eMailTextBox.Text = _currentUser.Email;
            phoneNumberTextBox.Text = _currentUser.Telephone;
            jobTextBox.Text = _currentUser.Job;
            deptTextBox.Text = _currentUser.Department;

            if (_currentUser.isActive)
            {
                activeTrue.Checked = true;
            }
            else
            {
                activeFalse.Checked = true;
            }
            //Set header title to name
            this.Text = "User data of " + _currentUser.Name;
            _conn.Close();
        }


        private void InitializeDataGrid()
        {
            _conn.Open();
            _cmd = new SQLiteCommand(_conn)
            {
                CommandText = @"Select * from loginstats where loginId = '" + _loginId + "'"
            };
            using (SQLiteDataReader reader = _cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    _loginstats.Add(new Loginstat(Convert.ToDateTime((string)reader["datum"]), (string)reader["tijd"], (string)reader["server"], (string)reader["loginid"], (string)reader["werkplekid"]));
                }
            }
            userDataGrid.DataSource = _loginstats;
            userDataGrid.Refresh();
            _conn.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var filteredStats = new List<Loginstat>();
            foreach (Loginstat stat in _loginstats)
            {
                if (stat.AssetId.ToLower().Contains(textBox1.Text.ToLower()))
                    filteredStats.Add(stat);
            }
            userDataGrid.DataSource = filteredStats;
        }
    }
}
