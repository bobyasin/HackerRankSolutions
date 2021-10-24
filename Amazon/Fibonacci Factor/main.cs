using System;
using System.Collections.Generic;

namespace Demos
{
    internal static class Program
    {
        public static ulong[] FibonacciIterative(ulong len)
        {
            List<ulong> fibonacciNubers = new List<ulong>();
            ulong a = 0, b = 1, c = 0;

            for (ulong i = 2; i < len; i++)
            {
                c = a + b;

                a = b;
                b = c;
                fibonacciNubers.Add(c);
            }

            return fibonacciNubers.ToArray();
        }

        private static ulong FindGreatestCommonDivisor(ulong a, ulong b)
        {
            ulong Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }

        public static Tuple<ulong, ulong> FindSmallestFibonacci(ulong number)
        {
            var fibonacciNubers = FibonacciIterative(number);

            var divisors = new List<ulong>();
            ulong divisorInFibonacciNumbers = 0;

            foreach (ulong fNumber in fibonacciNubers)
            {
                var divisor = FindGreatestCommonDivisor(number, fNumber);
                if (divisor > 1 && !divisors.Contains(divisor))
                {
                    divisors.Add(divisor);
                    divisorInFibonacciNumbers = fNumber;

                    break;
                }
            }

            if (divisors.Count == 0)
            {
                divisors.Add(number);
                divisorInFibonacciNumbers = number;
            }

            return Tuple.Create(divisors[0], divisorInFibonacciNumbers);
        }

        private static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim()); // input T

            int[,] inputArr = new int[t, 2]; // 0 = input 1: Smallest Fibonacci Number

            for (int i = 0; i < t; i++)
            {
                var input = Convert.ToInt32(Console.ReadLine().Trim()); // each input

                inputArr[i, 0] = input;
            }

            ulong[,] outputArr = new ulong[t, 2];

            for (int i = 0; i < t; i++)
            {
                var tuple = FindSmallestFibonacci(Convert.ToUInt64(inputArr[i, 0]));
                outputArr[i, 0] = tuple.Item1;
                outputArr[i, 1] = tuple.Item2;
            }

            for (int i = 0; i < t; i++)
            {
                Console.WriteLine($"{outputArr[i, 1]} {outputArr[i, 0]}");
            }

            Console.ReadLine();
        }
    }
}
