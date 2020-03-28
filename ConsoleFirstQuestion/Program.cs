using System;
using System.Collections.Generic;

namespace ConsoleFirstQuestion
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            int[] array1 = new int[] { 1, 2, 3, 4 };
            int[] array2 = new int[] { 4, 5, 7, 8, 10};
            int[] array3 = new int[] { 3, 4, 6, 7, 9 };

            int[] result = p.GetMissingNumbers(array3);

            var isPrime = p.IsTherePrimeNumbers(result);
        }

        public int[] GetMissingNumbers(int[] numbers)
        {
            var tracker = numbers[0];
            List<int> missingNumb = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (tracker != numbers[i])
                {
                    missingNumb.Add(tracker);
                    tracker = numbers[i];
                }

                tracker++;
            }

            return missingNumb.ToArray();
        }

        public bool IsTherePrimeNumbers(int[] numbers)
        {
            var result = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (isPrime(numbers[i]))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private bool isPrime(int number)
        {

            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number));

            for (int i = 2; i <= limit; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;

        }
    }
}
