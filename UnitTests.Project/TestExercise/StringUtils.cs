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

        public bool IsPalindrome(string word)
        {
            word = word.ToLower();

            int startIndex = 0;
            int endIndex = word.Length - 1;

            while (startIndex < endIndex)
            {
                if (word[startIndex] != word[endIndex])
                {
                    return false;
                }

                startIndex++;
                endIndex--;
            }

            return true;
        }
    }
}
