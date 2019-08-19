using System;
using System.Data;
using System.Data.SQLite;

namespace AssetMonitor.Databases
{
    class LocalDB
    {


        public SQLiteCommand _sqlCommand;
        public SQLiteConnection _sqlConnection;

        //Static readonly variables used for sql query formatting
        static readonly string FORMATTED_DATE = " DATE(substr(datum,7,4)||'-'||substr(datum,4,2)||'-'||substr(datum,1,2))";
        static readonly string DATUM_ORDER_DESC = String.Format(" ORDER BY {0} DESC", FORMATTED_DATE);


        public LocalDB(SQLiteConnection localConnection)
        {
            _sqlConnection = localConnection;
            _sqlCommand = new SQLiteCommand("", _sqlConnection);
        }

        /// <summary>
        /// Get all asset stats by the last login on them
        /// </summary>
        /// <returns></returns>
        public DataTable GetCurrentAssetStats()
        {
            DataTable result = new DataTable();
            _sqlConnection.Open();
            _sqlCommand = new SQLiteCommand(String.Format("select *, MAX({0}) FROM loginstats GROUP BY werkplekid {1}", FORMATTED_DATE, DATUM_ORDER_DESC));
            _sqlCommand.Connection = _sqlConnection;
            result = ReaderToDataTable( _sqlCommand.ExecuteReader());
            _sqlConnection.Close();
            return result;

        }
        /// <summary>
        /// Get all assets that have a name that resembles the given param
        /// </summary>
        /// <param name="nameToFilter">The name that will be filtered on</param>
        /// <returns></returns>
        public DataTable GetAssetStatsByName(string nameToFilter)
        {
            DataTable result = new DataTable();
            _sqlCommand = new SQLiteCommand(String.Format(@"select * from loginstats where werkplekid LIKE '%{0}%' {1}", nameToFilter, DATUM_ORDER_DESC));
            _sqlCommand.Connection = _sqlConnection;
            result = ReaderToDataTable(_sqlCommand.ExecuteReader());
            return result;
        }

        /// <summary>
        /// Returns all assets where the date is lower than the given date
        /// </summary>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public DataTable GetAssetDataBetweenDatesLesser(string filterDate)
        {
            DataTable result = new DataTable();
            _sqlCommand = new SQLiteCommand(String.Format(@"SELECT * FROM loginstats WHERE {0} <= '{1}' {2}", FORMATTED_DATE, filterDate, DATUM_ORDER_DESC));
            _sqlCommand.Connection = _sqlConnection;
            result = ReaderToDataTable(_sqlCommand.ExecuteReader());
            return result;
        }

        /// <summary>
        /// Returns all assets where the date is higher than the given date
        /// </summary>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public DataTable GetAssetDataBetweenDatesGreater(string filterDate)
        {
           DataTable result = new DataTable();
            _sqlCommand = new SQLiteCommand(String.Format(@"SELECT * FROM loginstats WHERE {0} >= '{1}' {2}", FORMATTED_DATE, filterDate, DATUM_ORDER_DESC));
            _sqlCommand.Connection = _sqlConnection;
            result = ReaderToDataTable( _sqlCommand.ExecuteReader());
            return result;
        }

        public DataTable ReaderToDataTable(SQLiteDataReader fetchedValues)
        {
            DataTable dataTable = new DataTable();
            PrepareDataTableForLocal(dataTable);
            using (SQLiteDataReader reader = fetchedValues)
            {
                while (reader.Read())
                {
                    dataTable.Rows.Add(Convert.ToDateTime((string)reader["datum"]).ToShortDateString(), (string)reader["tijd"], (string)reader["server"], (string)reader["loginid"], (string)reader["werkplekid"], "No live data found");
                }
            }
            return dataTable;
        }

        public DataTable PrepareDataTableForLocal(DataTable dataTable)
        {
            dataTable.Columns.Add("Date");
            dataTable.Columns.Add("Time");
            dataTable.Columns.Add("Server");
            dataTable.Columns.Add("LoginId");
            dataTable.Columns.Add("AssetId");
            dataTable.Columns.Add("Validity");
            return dataTable;
        }
    }
}
