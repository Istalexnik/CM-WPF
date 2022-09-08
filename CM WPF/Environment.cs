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
    }

}
