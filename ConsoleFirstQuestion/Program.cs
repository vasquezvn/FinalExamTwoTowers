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

        /// <summary>
        /// PSEUDOCODE:
        /// Set tracker to get first value from array
        /// Create a new list to add missing numbers in array
        /// iterate over array
        ///     if tracker is different than value get from array, means that's missing number
        ///         add missing number to array
        ///         tracker get value from array in correct position
        ///     tracker increment it's value in one
        /// 
        /// </summary>
        /// <param name="numbers">Array to verify missing numbers IT SHOULD BE SORTED</param>
        /// <returns>Array with missing numbers in array from parameter</returns>
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

        /// <summary>
        /// PSEUDOCODE:
        /// Define a value as false to check if there is a prime number in array
        /// iterate over array from parameter
        ///     check if number is prime
        ///         update boolean value to true
        ///         get out from iterator
        /// 
        /// </summary>
        /// <param name="numbers">Set of numbers to check</param>
        /// <returns>True if there is a primer number in array</returns>
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

        /// <summary>
        /// PSEUDOCODE:
        /// return false if number is exactly to one
        /// return true if number is exactly two
        /// Get square root number and round it to minimun value if there is decimals for it to determine limit for iterator
        /// iterate over possible values that could be set as primes
        ///     if number is module from number iterator then return false
        /// if iteration ends and module has not been found for number, it will return true
        /// 
        /// </summary>
        /// <param name="number">Number to check if it's prime</param>
        /// <returns>True if there isn'tnot found a module number in iterator</returns>
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
