﻿using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.NUnit
{
    [TestFixture]

    public class StringUtilsTest
    {
        private StringUtils stringUtils;

        [SetUp]
        public void Setup()
        {
            stringUtils = new StringUtils();
        }

        [Test]
        [TestCase("hello")]
        [TestCase("example")]
        public void ReverseString_WhenGivenString_ReturnsReversedString(string value)
        {
            string result = stringUtils.ReverseString(value);

            Assert.AreEqual(stringUtils.ReverseString(value), result);
        }

        [Test]
        [TestCase("miguel")]
        [TestCase("")]
        public void ToUpperCase_WhenGivenString_ReturnsUpperCaseString(string value)
        {
            string result = stringUtils.ToUpperCase(value);

            Assert.AreEqual(value.ToUpper(), result);
        }

        [Test]
        [TestCase("miguel")]
        [TestCase("")]
        public void ToLowerCase_WhenGivenString_ReturnsLowerCaseString(string value)
        {
            string result = stringUtils.ToLowerCase(value);

            Assert.AreEqual(value.ToLower(), result);
        }

        [Test]
        [TestCase("Hello ", "World")]
        [TestCase("I'm ", "Miguel")]
        public void ConcatenateStrings_WhenGivenMultipleStrings_ReturnsConcatenatedString(string val1, string val2)
        {
            string result = stringUtils.ConcatenateStrings(val1, val2);

            Assert.AreEqual(string.Concat(val1, val2), result);
        }

        [TestCase("radar")]
        [TestCase("racecar")]
        public void IsPalindrome_ValidPalindrome_ReturnsTrue(string palindrome)
        {
            bool result = stringUtils.IsPalindrome(palindrome);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("Hello", "World", false)]
        [TestCase("MIGUEL", "miguel", true)]
        public void AreEqualOrdinalIgnoreCase_WhenGivenStrings_ReturnsCorrectResult(string str1, string str2, bool expected)
        {
            bool result = stringUtils.AreEqualOrdinalIgnoreCase(str1, str2);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOf<bool>(result);
        }

        [Test]
        [TestCase("HELLO", "HELLO", true)]
        [TestCase("MIGUEL", "miguel", false)]
        public void AreEqualOrdinalCase_WhenGivenStrings_ReturnsCorrectResult(string str1, string str2, bool expected)
        {
            bool result = stringUtils.AreEqualOrdinalCase(str1, str2);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOf<bool>(result);
        }

        [Test]
        [TestCase("result", "R", "T", true)]
        [TestCase("fails", "a", "x", false)]
        public void CheckStartEnd_ShouldReturnExpectedResult_WhenStringIsValid(string str, string x, string y, bool expected)
        {
            bool result = stringUtils.checkStartEnd(str, x, y);

            Assert.AreEqual(expected, result);
            Assert.IsInstanceOf<bool>(result);
        }
    }
}
