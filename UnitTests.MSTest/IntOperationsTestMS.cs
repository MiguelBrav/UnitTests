using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
