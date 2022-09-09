using CM_WPF.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CM_WPF
{
    public static class Data
    {
        public static string _URL;
        public static string _ZIP;
        public static string _site;
        public static string _Login;
        public static string _SSN;
        public static string _FirstName = "Alex";
        public static string _LastName = "Istomin";
        public static string _DOB = "11/11/1959";
        public static string _Employer1 = "Amazon";
        public static string _Employer2 = "Walmart";
        public static bool _SecondEmployer = false;
        public static string _WorkedFrom1 = "11/11/2020";
        public static string _WorkedTo1 = DateTime.Now.ToString("MM/dd/yyyy");
        public static string _WorkedFrom2 = "11/11/2020";
        public static string _WorkedTo2 = DateTime.Now.ToString("MM/dd/yyyy");
        public static int _claimType;
        public static string[] _claimTypes = {"Regular", "UCX", "UCFE", "CWC", "Alien", "PUA"};
        public static string[] _Employers = { "Publix", "Target", "Toyota", "Alex" };
 


        public static string _newSSN() => "5" + Utilities.Rand.generateRandom("0123456789", 8);

        public static void _newLogin() 
        {
         _Login = "GSIUI" + _hostName().Substring(0, 2) + Utilities.Rand.generateRandom("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 7) + _claimType.ToString();
        }

        public static string _hostName() => System.Net.Dns.GetHostName();

        public static void _printing()
        {
            Debug.WriteLine($"{_site} {_claimType.ToString()} {_Login} {_SSN} {_FirstName} {_LastName} {_DOB} {_ZIP} " +
                $"{_URL} {_Employer1} {_WorkedFrom1} {_WorkedTo1} {_SecondEmployer} {_Employer2} {_WorkedFrom2} {_WorkedTo2}");
        }
        static Data()
        {

        }


    }
}
