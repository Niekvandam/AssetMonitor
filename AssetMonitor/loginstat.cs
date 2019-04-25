﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMonitor
{
    public class Loginstat
    {
        public string LoginDate {get;set; }
        public string LoginTime {get;set;}
        public string Server {get;set;}
        public string LoginId {get;set;}
        public string WorkspaceId {get;set;}


        public Loginstat(string loginDate, string loginTime, string server, string loginId, string workspaceId)
        {
            LoginDate = loginDate;
            LoginTime = loginTime;
            LoginId = loginId;
            Server = server;
            WorkspaceId = workspaceId;
        }
    }
}
