using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.InitialProject.TestExercise
{
    public class StringUtils
    {
        public string ReverseString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string ToUpperCase(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.ToUpper();
        }

        public string ToLowerCase(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.ToLower();
        }

        public string ConcatenateStrings(params string[] strings)
        {
            return string.Concat(strings);
        }
        
    }
}
