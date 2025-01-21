using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.MSTest
{
    [TestClass]
    public class IntOperationsTestMS
    {
        private List<int> numbers;
        private IntOperations intOperations;
        private const int MaxRandomNumber = 100;
        private const int NumbersToGenerate = 10;
        private const int ValueMultiplication = 7;

        [TestInitialize]
        public void Setup()
        {
            Random rand = new Random();
            numbers = new List<int>();
            while (numbers.Count < NumbersToGenerate)
            {
                int randomNumber = rand.Next(1, MaxRandomNumber + 1); 
                if (!numbers.Contains(randomNumber))
                {
                    numbers.Add(randomNumber);
                }
            }
            intOperations = new IntOperations();
        }

        [TestMethod]
        public void TestFindPrimeNumbers_ReturnsPrimeNumbers()
        {
            List<int> primes = intOperations.FindPrimeNumbers(numbers);
            foreach (int prime in primes)
            {
                Assert.IsTrue(intOperations.IsPrime(prime));
            }
        }

        [TestMethod]
        public void TestCalculateFactorial_CalculatesFactorialCorrectly()
        {
            foreach (int num in numbers)
            {
                long expected = 1;
                for (int i = 1; i <= num; i++)
                {
                    expected *= i;
                }
                long result = intOperations.CalculateFactorial(num); 
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void TestCheckParity_ChecksParityCorrectly()
        {
            Dictionary<int, bool> parityResult = intOperations.CheckParity(numbers);
            foreach (var kvp in parityResult)
            {
                int num = kvp.Key;
                bool isEven = kvp.Value;
                Assert.AreEqual(num % 2 == 0, isEven); 
            }
        }

        [TestMethod]
        public void GenerateMultiplicationTable_ReturnsCorrectResults()
        {
            var expectedResults = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                expectedResults.Add(ValueMultiplication * i);
            }

            var actualResults = intOperations.GenerateMultiplicationTable(ValueMultiplication);

            CollectionAssert.AreEqual(expectedResults, actualResults);
        }


        [TestMethod]
        public void SumDigitsInNumber_ReturnsCorrectResult_PositiveNumber()
        {
            int number = 123456;
            int expectedSum = 21; 

            int actualSum = intOperations.SumDigitsInNumber(number);

            Assert.AreEqual(expectedSum, actualSum);
            Assert.IsInstanceOfType(actualSum, typeof(int));
        }

        [TestMethod]
        public void GetDivisors_ReturnsCorrectDivisors_ForPositiveNumber()
        {
            int number = 36;
            List<int> expectedDivisors = new List<int> { 1, 2, 3, 4, 6, 9, 12, 18, 36 };

            List<int> actualDivisors = intOperations.GetDivisors(number);

            CollectionAssert.AreEqual(expectedDivisors, actualDivisors);            
            CollectionAssert.AllItemsAreInstancesOfType(actualDivisors,typeof(int));
            Assert.IsTrue(actualDivisors.Count > 0);
        }

        [TestMethod]
        public void ReverseNumber_ReturnsCorrectResult_ForPositiveNumber()
        {
            double number = 123.45;
            double expected = 321.54;
            double result = intOperations.ReverseNumber(number);
            Assert.IsInstanceOfType(result, typeof(double));
            Assert.IsTrue(result > 0);
            Assert.AreEqual(expected, result, "The reversed number is not correct for a positive number.");
        }

        [TestMethod]
        public void ReverseNumber_ReturnsCorrectResult_ForNegativeNumber()
        {
            double number = -123.45;
            double expected = -321.54;
            double result = intOperations.ReverseNumber(number);
            Assert.IsInstanceOfType(result, typeof(double));
            Assert.IsTrue(result < 0);
            Assert.AreEqual(expected, result, "The reversed number is not correct for a negative number.");
        }
    }
}
