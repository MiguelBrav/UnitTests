using Moq;
using NUnit.Framework;
using System.Collections.Generic;
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
            var result = stringUtils.ReverseString(value);

            Assert.That(result, Is.EqualTo(stringUtils.ReverseString(value)));
        }

        [Test]
        [TestCase("miguel")]
        [TestCase("")]
        public void ToUpperCase_WhenGivenString_ReturnsUpperCaseString(string value)
        {
            var result = stringUtils.ToUpperCase(value);

            Assert.That(result, Is.EqualTo(value.ToUpper()));
        }

        [Test]
        [TestCase("miguel")]
        [TestCase("")]
        public void ToLowerCase_WhenGivenString_ReturnsLowerCaseString(string value)
        {
            var result = stringUtils.ToLowerCase(value);

            Assert.That(result, Is.EqualTo(value.ToLower()));
        }

        [Test]
        [TestCase("Hello ", "World")]
        [TestCase("I'm ", "Miguel")]
        public void ConcatenateStrings_WhenGivenMultipleStrings_ReturnsConcatenatedString(string val1, string val2)
        {
            var result = stringUtils.ConcatenateStrings(val1, val2);

            Assert.That(result, Is.EqualTo(val1 + val2));
        }

        [Test]
        [TestCase("radar")]
        [TestCase("racecar")]
        public void IsPalindrome_ValidPalindrome_ReturnsTrue(string palindrome)
        {
            var result = stringUtils.IsPalindrome(palindrome);

            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase("Hello", "World", false)]
        [TestCase("MIGUEL", "miguel", true)]
        public void AreEqualOrdinalIgnoreCase_WhenGivenStrings_ReturnsCorrectResult(string str1, string str2, bool expected)
        {
            var result = stringUtils.AreEqualOrdinalIgnoreCase(str1, str2);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.InstanceOf<bool>());
        }

        [Test]
        [TestCase("HELLO", "HELLO", true)]
        [TestCase("MIGUEL", "miguel", false)]
        public void AreEqualOrdinalCase_WhenGivenStrings_ReturnsCorrectResult(string str1, string str2, bool expected)
        {
            var result = stringUtils.AreEqualOrdinalCase(str1, str2);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.InstanceOf<bool>());
        }

        [Test]
        [TestCase("result", "R", "T", true)]
        [TestCase("fails", "a", "x", false)]
        public void CheckStartEnd_ShouldReturnExpectedResult_WhenStringIsValid(string str, string x, string y, bool expected)
        {
            var result = stringUtils.checkStartEnd(str, x, y);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.InstanceOf<bool>());
        }

        [Test]
        [TestCase("hello", 2)]
        [TestCase("HELLO", 2)]
        [TestCase("world", 1)]
        [TestCase("aeiou", 5)]
        [TestCase("", 0)]
        public void CountVowels_ShouldReturnCorrectCount(string input, int expected)
        {
            var result = stringUtils.CountVowels(input);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.InstanceOf<int>());
        }

        [Test]
        [TestCase("hello world", 2)]
        [TestCase("hello", 1)]
        [TestCase("   ", 0)]
        [TestCase("word1\nword2\tword3", 3)]
        [TestCase("", 0)]
        public void CountWords_ShouldReturnCorrectCount(string input, int expected)
        {
            var result = stringUtils.CountWords(input);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.InstanceOf<int>());
        }

        [Test]
        [TestCase("hello", 'L', 2)]
        [TestCase("HELLO", 'l', 2)]
        [TestCase("hello", 'z', 0)]
        [TestCase("Hello World", ' ', 1)]
        [TestCase("", 'a', 0)]
        public void CountCharacterOccurrences_ShouldReturnCorrectCount(string input, char character, int expected)
        {
            var result = stringUtils.CountCharacterOccurrences(input, character);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.InstanceOf<int>());
        }

        [Test]
        [TestCase("Hello World", "World Hello")]
        [TestCase("Good Morning", "Morning Good")]
        public void ReverseWordsOrder_ShouldReturnReversedWordsCorrectly(string input, string expected)
        {
            var result = stringUtils.ReverseWords(input);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.TypeOf<string>());
        }

        [Test]
        [TestCase("C# is awesome", "#C si emosewa")]
        [TestCase("Unit Testing", "tinU gnitseT")]
        public void ReverseEachWord_ShouldReturnReversedWordsCorrectly(string input, string expected)
        {
            var result = stringUtils.ReverseEachWord(input);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.TypeOf<string>());
        }

        [Test]
        [TestCase("hello", "HELLO")]
        [TestCase("test CASE", "TEST case")]
        public void AlternateCase_ShouldReturnCorrectlyFormattedString(string input, string expected)
        {
            var result = stringUtils.AlternateCase(input);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.TypeOf<string>());
        }
    }
}
