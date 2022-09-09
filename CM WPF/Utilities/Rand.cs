using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM_WPF.Utilities
{
    public static class Rand
    {
        public static String generateRandom(string candidateChars, int length)
        {
            var randomString = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < length; i++)
                randomString.Append(candidateChars[random.Next(candidateChars.Length)]);

            return randomString.ToString();
        }

       
    }
}
