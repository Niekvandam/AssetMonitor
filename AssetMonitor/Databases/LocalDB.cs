using System;
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
        public SQLiteDataReader GetCurrentAssetStats()
        {
            _sqlCommand = new SQLiteCommand(String.Format("select *, MAX({0}) FROM loginstats GROUP BY werkplekid {1}", FORMATTED_DATE, DATUM_ORDER_DESC));
            _sqlCommand.Connection = _sqlConnection;
            return _sqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Get all assets that have a name that resembles the given param
        /// </summary>
        /// <param name="nameToFilter">The name that will be filtered on</param>
        /// <returns></returns>
        public SQLiteDataReader GetAssetStatsByName(string nameToFilter)
        {
            _sqlCommand = new SQLiteCommand(String.Format(@"select * from loginstats where werkplekid LIKE '%{0}%' {1}", nameToFilter, DATUM_ORDER_DESC));
            return _sqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Returns all assets where the date is lower than the given date
        /// </summary>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public SQLiteDataReader GetAssetDataBetweenDatesLesser(string filterDate)
        {
            _sqlCommand = new SQLiteCommand(String.Format(@"SELECT * FROM loginstats WHERE {0} <= '{1}' {2}", FORMATTED_DATE, filterDate, DATUM_ORDER_DESC));

            return _sqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Returns all assets where the date is higher than the given date
        /// </summary>
        /// <param name="filterDate"></param>
        /// <returns></returns>
        public SQLiteDataReader GetAssetDataBetweenDatesGreater(string filterDate)
        {
            _sqlCommand = new SQLiteCommand(String.Format(@"SELECT * FROM loginstats WHERE {0} >= '{1}' {2}", FORMATTED_DATE, filterDate, DATUM_ORDER_DESC));
            return _sqlCommand.ExecuteReader();
        }


    }
}
