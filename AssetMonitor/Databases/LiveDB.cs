using System;
using System.Data;
using System.Data.SqlClient;

namespace AssetMonitor.Databases
{
    class LiveDB
    {

        public SqlCommand _sqlCommand;
        public SqlConnection _sqlConnection;

        public LiveDB(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
            _sqlCommand = new SqlCommand("", _sqlConnection);
        }

        public DataTable GetUserData(bool withParty, string assetId)
        {
            DataTable result = null;
            if (withParty)
            {
                result = GetDataTableFromCommand(string.Format(
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
            AND    c.assetnumber = '{0}'", assetId));
            }
            else
            {
                result = GetDataTableFromCommand(string.Format(@"SELECT c.description, 
                    c.serialNumber, 
                    c.assetNumber, 
                    c.notes,
                    d.entry
            FROM    product c, 
                    valuelistentry D
            WHERE   c.assetnumber = '{0}' " +
            "AND    c.productstatusid = d.valuelistentryid", assetId));
            }
            return result;
        }

        public DataTable GetDataTableFromCommand(string sqlCommand)
        {
            _sqlConnection.Open();
            var dataTable = new DataTable();
            _sqlCommand.CommandText = sqlCommand;
            var result = _sqlCommand.ExecuteReader();
            dataTable.Load(result);
            _sqlConnection.Close();
            return dataTable;
        }


        public int GetDataValidity(string assetId)
        {
            _sqlConnection.Open();
            _sqlCommand.CommandText = string.Format(
            @"SELECT(SELECT COUNT(*)
            FROM    person A, 
                    party B, 
                    product C, 
                    valuelistentry D 
            WHERE   b.personid = a.personid 
            AND     c.partyid = b.partyid 
            AND     c.productstatusid = d.valuelistentryid 
            AND     c.assetnumber = '{0}')
            +
            (SELECT COUNT(*)
            FROM    product c, 
                    valuelistentry D
            WHERE   c.assetnumber = '{1}' 
            AND     c.productstatusid = d.valuelistentryid) as sum", assetId, assetId);
            var reader = _sqlCommand.ExecuteReader();
            reader.Read();
            int result = Convert.ToInt32(reader[0]);
            _sqlConnection.Close();
            return result;
        }


        public DataTable GetThinClients()
        {
            DataTable result = new DataTable();
            _sqlConnection.Open();
            _sqlCommand.CommandText = string.Format(
            @" SELECT TOP 1000
                    [AssetNumber],
                    [Description],
                    [Active],
            FROM    [ClienteleITSM_Prod_Application].[dbo].[Product]
            WHERE   Active = 1 
            AND     ItemID in ( 
            SELECT  ItemID   
            FROM    [ClienteleITSM_Prod_Application].[dbo].[Items]
            WHERE   Description like '%thin%')");
            var reader = _sqlCommand.ExecuteReader();
            result.Load(reader);
            _sqlConnection.Close();
            return result;
        }
    }
}
