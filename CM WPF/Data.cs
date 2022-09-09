using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_WPF
{
    public static class Data
    {
        public static string _FirstName = "Alex";
        public static string _LastName = "Istomin";
        public static string _DOB = "11/11/1959";
        public static string _Employer1 = "Amazon";
        public static string _Employer2 = "Walmart";
        public static string _WorkedFrom1 = "11/11/2020";
      //  public static string _WorkedTo1 = "";
        public static string _WorkedFrom2 = "11/11/2020";
      //  public static string _WorkedTo2 = "";
        public static int _claimType = 1;
        public static string[] _claimTypes = {"Regular", "UCX", "UCFE", "CWC", "Alien", "PUA"};
        public static string[] _Employers = { "Publix", "Target", "Toyota", "Alex" };

        static Data()
        {

        }


    }
}
