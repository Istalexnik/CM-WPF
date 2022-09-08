using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_WPF
{
    class Environment
    {
        public string siteName;
        public string siteUrl;
        public string zipCode;

        public Environment(string siteName, string siteUrl, string zipCode)
        {
            this.siteName = siteName;
            this.siteUrl = siteUrl;
            this.zipCode = zipCode;
        }

        public static List<Environment> createEnvironments()
        {
            List<Environment> list = new List<Environment>();
            list.Add(new Environment("TN UAT", "https://uat-app-vos47000000.geosolinc.com/vosnet/default.aspx", "37243"));
            list.Add(new Environment("PA UAT", "https://uat-app-vos42000000.geosolinc.com/vosnet/default.aspx", "17104"));
            list.Add(new Environment("NE UAT", "https://uat-app-vos31000000.geosolinc.com/vosnet/default.aspx", "68104"));
            return list;
        }
    }

}
