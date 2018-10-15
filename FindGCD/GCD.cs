using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGCD
{
    public static class GCD
    {
        /// <summary>
        /// Return GCD and the execution time, using Euclid's algorithm for 2 numbers
        /// </summary>
        public static int FindGcd(int number1, int number2, out TimeSpan time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = FindGcd(number1, number2);

            stopWatch.Stop();
            time = stopWatch.Elapsed;

            return result;
        }

        /// <summary>
        /// Return GCD and the execution time, using Euclid's algorithm for 3 numbers
        /// </summary>
        public static int FindGcd(int number1, int number2, int number3, out TimeSpan time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int number = FindGcd(number1, number2);
            int result = FindGcd(number, number3);

            stopWatch.Stop();
            time = stopWatch.Elapsed;

            return result;
        }

        /// <summary>
        /// Return GCD and the execution time, using Euclid's algorithm for any count of numbers
        /// </summary>
        public static int FindGcd(out TimeSpan time, params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Stack<int> stack = new Stack<int>(numbers);

            while (stack.Count > 1)
            {
                stack.Push(FindGcd(stack.Pop(), stack.Pop()));
            }

            int result = stack.Pop();

            stopWatch.Stop();
            time = stopWatch.Elapsed;

            return result;
        }

        /// <summary>
        /// Return GCD, using Euclid's algorithm for 2 numbers
        /// </summary>
        private static int FindGcd(int number1, int number2)
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
        /// Return GCD and the execution time, using Stein's algorithm for 2 numbers
        /// </summary>
        public static int FindGcdStein(int number1, int number2, out TimeSpan time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = FindGcdStein(number1, number2);

            stopWatch.Stop();
            time = stopWatch.Elapsed;

            return result;

        }

        /// <summary>
        /// Return GCD and the execution time, using Stein's algorithm for 3 numbers
        /// </summary>
        public static int FindGcdStein(int number1, int number2, int number3, out TimeSpan time)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int number = FindGcdStein(number1, number2);
            int result = FindGcdStein(number, number3);

            stopWatch.Stop();
            time = stopWatch.Elapsed;

            return result;
        }

        /// <summary>
        /// Return GCD and the execution time, using Stein's algorithm for any count of numbers
        /// </summary>
        public static int FindGcdStein(out TimeSpan time, params int[] numbers)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Stack<int> stack = new Stack<int>(numbers);

            while (stack.Count > 1)
            {
                stack.Push(FindGcdStein(stack.Pop(), stack.Pop()));
            }

            int result = stack.Pop();

            stopWatch.Stop();
            time = stopWatch.Elapsed;

            return result;
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

            } while (number2 != 0);

            return number1 << shift;
        }

    }
}
