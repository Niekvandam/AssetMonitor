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
        private SQLiteConnection conn;
        private SQLiteCommand cmd;
        private string loginId;
        private List<Loginstat> loginstats = new List<Loginstat>();

        public UserData(SQLiteConnection dbconnection, string loginId)
        {
            InitializeComponent();
            conn = dbconnection;
            this.loginId = loginId;
            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            conn.Open();
            cmd = new SQLiteCommand(conn);
            cmd.CommandText = @"Select * from loginstats where loginId = '" + loginId + "'";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    loginstats.Add(new Loginstat(Convert.ToDateTime((string)reader["datum"]), (string)reader["tijd"], (string)reader["server"], (string)reader["loginid"], (string)reader["werkplekid"]));
                }
            }
            userDataGrid.DataSource = loginstats;
            userDataGrid.Refresh();
            conn.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
