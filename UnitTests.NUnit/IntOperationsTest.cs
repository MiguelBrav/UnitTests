using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;

namespace UnitTests.MSTest
{

    public class IntOperationsTest
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
                List<int> primeNumbers = intOperations.FindPrimeNumbers(randomNumbers);
                foreach (int prime in primeNumbers)
                {
                    Assert.IsTrue(intOperations.IsPrime(prime));
                }
            }

            [Test]
            public void TestCalculateFactorial_CalculatesFactorialCorrectly()
            {
                foreach (int num in randomNumbers)
                {
                    long expectedFactorial = 1;
                    for (int i = 1; i <= num; i++)
                    {
                        expectedFactorial *= i;
                    }
                    long calculatedFactorial = intOperations.CalculateFactorial(num);
                    Assert.AreEqual(expectedFactorial, calculatedFactorial);
                }
            }

            [Test]
            public void TestCheckParity_ChecksParityCorrectly()
            {
                Dictionary<int, bool> parityResult = intOperations.CheckParity(randomNumbers);
                foreach (var kvp in parityResult)
                {
                    int num = kvp.Key;
                    bool isEven = kvp.Value;
                    Assert.AreEqual(num % 2 == 0, isEven);
                }
            }

            [Test]
            public void GenerateMultiplicationTable_ReturnsCorrectResults()
            {
                var expectedResults = new List<int>();
                for (int i = 1; i <= 10; i++)
                {
                    expectedResults.Add(ValueMultiplication * i);
                }
                var actualResults = intOperations.GenerateMultiplicationTable(ValueMultiplication);
                Assert.AreEqual(expectedResults, actualResults);
            }
        }
    }
}
