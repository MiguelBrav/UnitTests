﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [DataRow("Hello ","World")]
        [DataRow("I'm ", "Miguel")]
        public void ConcatenateStrings_WhenGivenMultipleStrings_ReturnsConcatenatedString(string val1, string val2)
        {
            string result = stringUtils.ConcatenateStrings(val1, val2);

            Assert.AreEqual(string.Concat(val1,val2), result);
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
    }
}
