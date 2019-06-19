using System.Data.SqlClient;

namespace AssetMonitor.Databases
{
    class LiveDB
    {

        private SqlCommand _sqlCommand;
        private SqlConnection _sqlConnection;


        public LiveDB(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }


        public SqlDataReader GetUserDataWithParty(string assetId)
        {
            _sqlCommand = new SqlCommand(
                @"SELECT a.username, 
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
            AND    c.assetnumber = '" + assetId + "'", _sqlConnection);

            return _sqlCommand.ExecuteReader();
        }


        public SqlDataReader GetUserDataWithoutParty(string assetId)
        {
            _sqlCommand = new SqlCommand(
                @"SELECT c.description, 
                    c.serialNumber, 
                    c.assetNumber, 
                    c.notes,
                    d.entry
            FROM    product c, 
                    valuelistentry D
            WHERE   c.assetnumber = '" + assetId + "' " +
            "AND    c.productstatusid = d.valuelistentryid", _sqlConnection);

            return _sqlCommand.ExecuteReader();
        }

    }
}
