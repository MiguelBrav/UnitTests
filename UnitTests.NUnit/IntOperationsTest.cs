using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.NUnit
{
    [TestFixture]
    public class IntOperationsTests
    {
        private List<int> randomNumbers;
        private IntOperations intOperations;
        private const int MaxRandomNumber = 100;
        private const int NumbersToGenerate = 10;
        private const int ValueMultiplication = 7;

        [SetUp]
        public void Setup()
        {
            Random rand = new Random();
            randomNumbers = new List<int>();

            while (randomNumbers.Count < NumbersToGenerate)
            {
                int randomNumber = rand.Next(1, MaxRandomNumber + 1);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            intOperations = new IntOperations();
        }

        [Test]
        public void TestFindPrimeNumbers_ReturnsPrimeNumbers()
        {
            var primeNumbers = intOperations.FindPrimeNumbers(randomNumbers);

            Assert.That(primeNumbers, Is.All.Matches<int>(p => intOperations.IsPrime(p)));
        }

        [Test]
        public void TestCalculateFactorial_CalculatesFactorialCorrectly()
        {
            foreach (int num in randomNumbers)
            {
                long expectedFactorial = 1;
                for (int i = 1; i <= num; i++)
                    expectedFactorial *= i;

                long actual = intOperations.CalculateFactorial(num);
                Assert.That(actual, Is.EqualTo(expectedFactorial));
            }
        }

        [Test]
        public void TestCheckParity_ChecksParityCorrectly()
        {
            var result = intOperations.CheckParity(randomNumbers);

            foreach (var kvp in result)
                Assert.That(kvp.Value, Is.EqualTo(kvp.Key % 2 == 0));
        }

        [Test]
        public void GenerateMultiplicationTable_ReturnsCorrectResults()
        {
            var expected = Enumerable.Range(1, 10)
                                     .Select(x => x * ValueMultiplication)
                                     .ToList();

            var actual = intOperations.GenerateMultiplicationTable(ValueMultiplication);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void SumDigitsInNumber_ReturnsCorrectResult_PositiveNumber()
        {
            int number = 123456;
            int expected = 21;

            int result = intOperations.SumDigitsInNumber(number);

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(result, Is.TypeOf<int>());
        }

        [Test]
        public void GetDivisors_ReturnsCorrectDivisors_ForPositiveNumber()
        {
            int number = 36;
            var expected = new List<int> { 1, 2, 3, 4, 6, 9, 12, 18, 36 };

            var actual = intOperations.GetDivisors(number);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual, Is.All.InstanceOf<int>());
        }

        [Test]
        public void ReverseNumber_ReturnsCorrectResult_ForPositiveNumber()
        {
            double number = 123.45;
            double expected = 321.54;

            double result = intOperations.ReverseNumber(number);

            Assert.That(result, Is.TypeOf<double>());
            Assert.That(result, Is.GreaterThan(0));
            Assert.That(result, Is.EqualTo(expected).Within(0.01));
        }

        [Test]
        public void ReverseNumber_ReturnsCorrectResult_ForNegativeNumber()
        {
            double number = -123.45;
            double expected = -321.54;

            double result = intOperations.ReverseNumber(number);

            Assert.That(result, Is.TypeOf<double>());
            Assert.That(result, Is.LessThan(0));
            Assert.That(result, Is.EqualTo(expected).Within(0.01));
        }
    }
}
