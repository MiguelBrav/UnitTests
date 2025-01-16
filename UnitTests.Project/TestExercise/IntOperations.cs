using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.InitialProject.TestExercise
{
    public class IntOperations
    {
        public List<int> FindPrimeNumbers(List<int> numbers)
        {
            return numbers.Where(n => IsPrime(n)).ToList();
        }

        public bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num <= 3) return true;
            if (num % 2 == 0 || num % 3 == 0) return false;
            int i = 5;
            while (i * i <= num)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                    return false;
                i += 6;
            }
            return true;
        }

        public long CalculateFactorial(int num)
        {
            if (num == 0)
                return 1;
            long factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        public Dictionary<int, bool> CheckParity(List<int> numbers)
        {
            return numbers.ToDictionary(num => num, num => num % 2 == 0);
        }

        public List<int> GenerateMultiplicationTable(int number)
        {
            List<int> table = new List<int>();

            foreach (int i in Enumerable.Range(1, 10))
            {
                int result = number * i;
                table.Add(result);
            }

            return table;
        }

        public int SumDigitsInNumber(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        public List<int> GetDivisors(int number)
        {
            List<int> divisors = new List<int>();
            int sqrt = (int)Math.Sqrt(number);

            for (int i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                    if (i != number / i) 
                    {
                        divisors.Add(number / i);
                    }
                }
            }

            divisors.Sort(); 
            return divisors;
        }

    }
}
