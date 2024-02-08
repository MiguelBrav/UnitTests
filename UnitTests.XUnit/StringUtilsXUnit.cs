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
    }
}
