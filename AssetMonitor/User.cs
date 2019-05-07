using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMonitor
{
    class User
    {

        public string Department;
        public string Name;
        public string Job;
        public string Email;
        public string Telephone;
        public bool isActive;


        public User(string department, string name, string job, string telephone, string email, bool active)
        {
            Department = department;
            Name = name;
            Job = job;
            Telephone = telephone;
            Email = email;
            isActive = active;
        }

    }
}
