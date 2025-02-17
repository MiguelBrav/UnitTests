﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            private const int ValueMultiplication = 7;
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

            [Fact]
            public void GenerateMultiplicationTable_ReturnsCorrectResults()
            {
                var expectedResults = new List<int>();
                for (int i = 1; i <= 10; i++)
                {
                    expectedResults.Add(ValueMultiplication * i);
                }
                var actualResults = intOperations.GenerateMultiplicationTable(ValueMultiplication);
                Assert.Equal(expectedResults, actualResults);
            }

            [Fact]
            public void SumDigitsInNumber_ReturnsCorrectResult_PositiveNumber()
            {
                int number = 123456;
                int expectedSum = 21;

                int actualSum = intOperations.SumDigitsInNumber(number);

                Assert.Equal(expectedSum, actualSum);
                Assert.IsType<int>(actualSum);
            }

            [Fact]
            public void GetDivisors_ReturnsCorrectDivisors_ForPositiveNumber()
            {
                int number = 36;
                List<int> expectedDivisors = new List<int> { 1, 2, 3, 4, 6, 9, 12, 18, 36 };

                List<int> actualDivisors = intOperations.GetDivisors(number);

                Assert.Equal(expectedDivisors, actualDivisors);
                Assert.All(actualDivisors, item => Assert.IsType<int>(item));
                Assert.NotEmpty(actualDivisors);
            }

            [Fact]
            public void ReverseNumber_ReturnsCorrectResult_ForPositiveNumber()
            {
                double number = 123.45;
                double expected = 321.54;
                double result = intOperations.ReverseNumber(number);

                Assert.IsType<double>(result);
                Assert.True(result > 0);
                Assert.Equal(expected, result, 2); 
            }

            [Fact]
            public void ReverseNumber_ReturnsCorrectResult_ForNegativeNumber()
            {
                double number = -123.45;
                double expected = -321.54;
                double result = intOperations.ReverseNumber(number);

                Assert.IsType<double>(result);
                Assert.True(result < 0);
                Assert.Equal(expected, result, 2); 
            }
        }
    }
}
