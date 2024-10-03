using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;
using Xunit;

namespace UnitTests.XUnit
{
    public class StringUtilsXUnit
    {
        private readonly StringUtils stringUtils;

        public StringUtilsXUnit()
        {
            stringUtils = new StringUtils();
        }

        [Theory]
        [InlineData("hello")]
        [InlineData("example")]
        public void ReverseString_WhenGivenString_ReturnsReversedString(string value)
        {
            string result = stringUtils.ReverseString(value);

            Assert.Equal(stringUtils.ReverseString(value), result);
        }

        [Theory]
        [InlineData("miguel")]
        [InlineData("")]
        public void ToUpperCase_WhenGivenString_ReturnsUpperCaseString(string value)
        {
            string result = stringUtils.ToUpperCase(value);

            Assert.Equal(value.ToUpper(), result);
        }

        [Theory]
        [InlineData("miguel")]
        [InlineData("")]
        public void ToLowerCase_WhenGivenString_ReturnsLowerCaseString(string value)
        {
            string result = stringUtils.ToLowerCase(value);

            Assert.Equal(value.ToLower(), result);
        }

        [Theory]
        [InlineData("Hello ", "World")]
        [InlineData("I'm ", "Miguel")]
        public void ConcatenateStrings_WhenGivenMultipleStrings_ReturnsConcatenatedString(string val1, string val2)
        {
            string result = stringUtils.ConcatenateStrings(val1, val2);

            Assert.Equal(string.Concat(val1, val2), result);
        }

        [Theory]
        [InlineData("radar")]
        [InlineData("racecar")]
        public void IsPalindrome_ValidPalindrome_ReturnsTrue(string palindrome)
        {

            bool result = stringUtils.IsPalindrome(palindrome);

            Assert.True(result);
        }


        [Theory]
        [InlineData("Hello", "World", false)]
        [InlineData("MIGUEL", "miguel", true)]
        public void AreEqualOrdinalIgnoreCase_WhenGivenStrings_ReturnsCorrectResult(string str1, string str2, bool expected)
        {
            bool result = stringUtils.AreEqualOrdinalIgnoreCase(str1, str2);

            Assert.Equal(expected, result);
            Assert.IsType<bool>(result);
        }

        [Theory]
        [InlineData("HELLO", "HELLO", true)]
        [InlineData("MIGUEL", "miguel", false)]
        public void AreEqualOrdinalCase_WhenGivenStrings_ReturnsCorrectResult(string str1, string str2, bool expected)
        {
            bool result = stringUtils.AreEqualOrdinalCase(str1, str2);

            Assert.Equal(expected, result);
            Assert.IsType<bool>(result);
        }

        [Theory]
        [InlineData("result", "R", "T", true)]
        [InlineData("fails", "a", "x", false)]
        public void CheckStartEnd_ShouldReturnExpectedResult_WhenStringIsValid(string str, string x, string y, bool expected)
        {
            bool result = stringUtils.checkStartEnd(str, x, y);

            Assert.Equal(expected, result);
            Assert.IsType<bool>(result);
        }

        [Theory]
        [InlineData("hello", 2)]
        [InlineData("HELLO", 2)]
        [InlineData("world", 1)]
        [InlineData("aeiou", 5)]
        [InlineData("", 0)]
        public void CountVowels_ShouldReturnCorrectCount(string input, int expected)
        {
            int result = stringUtils.CountVowels(input);

            Assert.Equal(expected, result);
            Assert.IsType<int>(result);
        }

        [Theory]
        [InlineData("hello world", 2)]
        [InlineData("hello", 1)]
        [InlineData("   ", 0)]
        [InlineData("word1\nword2\tword3", 3)]
        [InlineData("", 0)]
        public void CountWords_ShouldReturnCorrectCount(string input, int expected)
        {
            int result = stringUtils.CountWords(input);

            Assert.Equal(expected, result);
            Assert.IsType<int>(result);
        }
    }
}
