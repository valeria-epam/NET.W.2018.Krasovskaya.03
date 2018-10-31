using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FindGCD
{
    public static class GCD
    {
        /// <summary>
        /// Return GCD and the execution time, using Euclid's algorithm for 2 numbers
        /// </summary>
        public static int FindGcdEuclid(int number1, int number2, out TimeSpan time) =>
            FindGcdWithTime(() => FindGcdEuclid(number1, number2), out time);

        /// <summary>
        /// Return GCD and the execution time, using Stein's algorithm for 2 numbers
        /// </summary>
        public static int FindGcdStein(int number1, int number2, out TimeSpan time) =>
            FindGcdWithTime(() => FindGcdStein(number1, number2), out time);

        /// <summary>
        /// Return GCD and the execution time, using Stein's algorithm for 3 numbers
        /// </summary>
        public static int FindGcdStein(int number1, int number2, int number3, out TimeSpan time) =>
            FindGcdWithTime(() => FindGcdStein(FindGcdStein(number1, number2), number3), out time);

        /// <summary>
        /// Return GCD and the execution time, using Euclid's algorithm for 3 numbers
        /// </summary>
        public static int FindGcdEuclid(int number1, int number2, int number3, out TimeSpan time) =>
            FindGcdWithTime(() => FindGcdEuclid(FindGcdEuclid(number1, number2), number3), out time);

        /// <summary>
        /// Return GCD and the execution time, using Stein's algorithm for any count of numbers
        /// </summary>
        public static int FindGcdStein(out TimeSpan time, params int[] numbers) =>
            FindGcdWithTime(() => FindGcdForManyNumbers(FindGcdStein, numbers), out time);

        /// <summary>
        /// Return GCD and the execution time, using Euclid's algorithm for any count of numbers
        /// </summary>
        public static int FindGcdEuclid(out TimeSpan time, params int[] numbers) =>
            FindGcdWithTime(() => FindGcdForManyNumbers(FindGcdEuclid, numbers), out time);

        private static int FindGcdWithTime(Func<int> findGcd, out TimeSpan time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = findGcd();

            stopWatch.Stop();
            time = stopWatch.Elapsed;

            return result;
        }

        private static int FindGcdForManyNumbers(Func<int, int, int> func, int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("The array must contains at least two elements");
            }

            int result = numbers[0];
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                result = func(numbers[i], result);
            }

            return result;
        }

        /// <summary>
        /// Return GCD, using Euclid's algorithm for 2 numbers
        /// </summary>
        private static int FindGcdEuclid(int number1, int number2)
        {
            if (number1 == 0)
            {
                return number2;
            }

            if (number2 == 0)
            {
                return number1;
            }

            if (number1 < 0)
            {
                number1 = Math.Abs(number1);
            }

            if (number2 < 0)
            {
                number2 = Math.Abs(number2);
            }

            while (number1 != number2)
            {
                if (number1 > number2)
                {
                    number1 = number1 - number2;
                }
                else
                {
                    number2 = number2 - number1;
                }
            }

            return number1;
        }

        /// <summary>
        /// Return GCD, using Stein's algorithm for 2 numbers
        /// </summary>
        private static int FindGcdStein(int number1, int number2)
        {
            int shift;

            if (number1 == 0)
            {
                return number2;
            }

            if (number2 == 0)
            {
                return number1;
            }

            if (number1 < 0)
            {
                number1 = Math.Abs(number1);
            }

            if (number2 < 0)
            {
                number2 = Math.Abs(number2);
            }

            for (shift = 0; ((number1 | number2) & 1) == 0; ++shift)
            {
                number1 >>= 1;
                number2 >>= 1;
            }

            while ((number1 & 1) == 0)
            {
                number1 >>= 1;
            }

            do
            {
                while ((number2 & 1) == 0)
                {
                    number2 >>= 1;
                }

                if (number1 > number2)
                {
                    int t = number2;
                    number2 = number1;
                    number1 = t;
                }

                number2 = number2 - number1;
            }
            while (number2 != 0);

            return number1 << shift;
        }
    }
}
