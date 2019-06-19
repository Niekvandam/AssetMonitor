using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMonitor
{
    public class Loginstat
    {
        public DateTime LoginDate {get;set; }
        public string LoginTime {get;set;}
        public string Server {get;set;}
        public string LoginId {get;set;}
        public string AssetId {get;set;}


        public Loginstat(DateTime loginDate, string loginTime, string server, string loginId, string assetId)
        {
            LoginDate = loginDate;
            LoginTime = loginTime;
            LoginId = loginId;
            Server = server;
            AssetId = assetId;
        }
    }
}
