using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.MSTest
{
    [TestClass]
    public class StringUtilsTestMS
    {
        private StringUtils stringUtils;

        [TestInitialize]
        public void Setup()
        {
            stringUtils = new StringUtils();
        }

        [TestMethod]
        [DataRow("hello")]
        [DataRow("example")]
        public void ReverseString_WhenGivenString_ReturnsReversedString(string value)
        {
            string result = stringUtils.ReverseString(value);

            Assert.AreEqual(stringUtils.ReverseString(value), result);
        }

        [TestMethod]
        [DataRow("miguel")]
        [DataRow("")]
        public void ToUpperCase_WhenGivenString_ReturnsUpperCaseString(string value)
        {
            string result = stringUtils.ToUpperCase(value);

            Assert.AreEqual(value.ToUpper(), result);
        }

        [TestMethod]
        [DataRow("miguel")]
        [DataRow("")]
        public void ToLowerCase_WhenGivenString_ReturnsLowerCaseString(string value)
        {
            string result = stringUtils.ToLowerCase(value);

            Assert.AreEqual(value.ToLower(), result);
        }

        [TestMethod]
        [DataRow("Hello ", "World")]
        [DataRow("I'm ", "Miguel")]
        public void ConcatenateStrings_WhenGivenMultipleStrings_ReturnsConcatenatedString(string val1, string val2)
        {
            string result = stringUtils.ConcatenateStrings(val1, val2);

            Assert.AreEqual(string.Concat(val1, val2), result);
        }

        [TestMethod]
        [DataRow("radar")]
        [DataRow("racecar")]
        public void IsPalindrome_ValidPalindrome_ReturnsTrue(string palindrome)
        {
            bool result = stringUtils.IsPalindrome(palindrome);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("Hello ", "World",false)]
        [DataRow("MIGUEL", "miguel",true)]
        public void AreEqualOrdinalIgnoreCase_WhenGivenStrings_ReturnsCorrectResult(string str1, string str2, bool expected)
        {
            bool result = stringUtils.AreEqualOrdinalIgnoreCase(str1, str2);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(bool));
        }


        [TestMethod]
        [DataRow("HELLO", "HELLO", true)]
        [DataRow("MIGUEL", "miguel", false)]
        public void AreEqualOrdinalCase_WhenGivenStrings_ReturnsCorrectResult(string str1, string str2, bool expected)
        {
            bool result = stringUtils.AreEqualOrdinalCase(str1, str2);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        [DataRow("result", "R","T", true)]
        [DataRow("fails", "a", "x", false)]
        public void CheckStartEnd_ShouldReturnTrue_WhenStringISValid(string str, string x, string y, bool expected)
        {
            bool result = stringUtils.checkStartEnd(str,x,y);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        [TestMethod]
        [DataRow("hello", 2)]
        [DataRow("HELLO", 2)]
        [DataRow("world", 1)]
        [DataRow("aeiou", 5)]
        [DataRow("", 0)]
        public void CountVowels_ShouldReturnCorrectCount(string input, int expected)
        {
            int result = stringUtils.CountVowels(input);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [TestMethod]
        [DataRow("hello world", 2)]
        [DataRow("hello", 1)]
        [DataRow("   ", 0)]
        [DataRow("word1\nword2\tword3", 3)]
        [DataRow("", 0)]
        public void CountWords_ShouldReturnCorrectCount(string input, int expected)
        {
            int result = stringUtils.CountWords(input);
            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [DataTestMethod]
        [DataRow("hello", 'L', 2)]   
        [DataRow("HELLO", 'l', 2)]   
        [DataRow("hello", 'z', 0)]
        [DataRow("Hello World", ' ', 1)]
        [DataRow("", 'a', 0)]
        public void CountCharacterOccurrences_ShouldReturnCorrectCount(string input, char character, int expected)
        {
            int result = stringUtils.CountCharacterOccurrences(input, character);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [DataTestMethod]
        [DataRow("Hello World", "World Hello")]
        [DataRow("Good Morning", "Morning Good")]

        public void ReverseWordsOrder_ShouldReturnReversedWordsCorrectly(string input, string expected)
        {
            string result = stringUtils.ReverseWords(input);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [DataTestMethod]
        [DataRow("C# is awesome", "#C si emosewa")]
        [DataRow("Unit Testing", "tinU gnitseT")]
        public void ReverseEachWord_ShouldReturnReversedWordsCorrectly(string input, string expected)
        {
            string result = stringUtils.ReverseEachWord(input);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [DataTestMethod]
        [DataRow("hello", "HELLO")]
        [DataRow("test CASE", "TEST case")]
        public void AlternateCase_ShouldReturnCorrectlyFormattedString(string input, string expected)
        {
            string result = stringUtils.AlternateCase(input);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOfType(result, typeof(string));
        }
    }
}
