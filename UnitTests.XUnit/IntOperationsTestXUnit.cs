using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.InitialProject.TestExercise;
using Xunit;

namespace UnitTests.XUnit
{

    public class IntOperationsTestXUnit
    {
        public class IntOperationsTests
        {
            private List<int> randomNumbers;
            private IntOperations intOperations;
            private const int MaxRandomNumber = 100;
            private const int NumbersToGenerate = 10;

            public IntOperationsTests()
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

            [Fact]
            public void TestFindPrimeNumbers_ReturnsPrimeNumbers()
            {
                List<int> primeNumbers = intOperations.FindPrimeNumbers(randomNumbers);
                foreach (int prime in primeNumbers)
                {
                    Assert.True(intOperations.IsPrime(prime));
                }
            }

            [Fact]
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
                    Assert.Equal(expectedFactorial, calculatedFactorial);
                }
            }

            [Fact]
            public void TestCheckParity_ChecksParityCorrectly()
            {
                Dictionary<int, bool> parityResult = intOperations.CheckParity(randomNumbers);
                foreach (var kvp in parityResult)
                {
                    int num = kvp.Key;
                    bool isEven = kvp.Value;
                    Assert.Equal(num % 2 == 0, isEven);
                }
            }
        }
    }
}
