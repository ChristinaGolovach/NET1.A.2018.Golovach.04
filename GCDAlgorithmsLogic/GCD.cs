using System;
using System.Diagnostics;

namespace GCDAlgorithmsLogic
{
    /// <summary>
    /// Represents a class for finding the greatest common divisor by Euclide's and Stain's algorithms.
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// Performs finding the greatest common divisor by Euclide's algorithm.
        /// </summary>
        /// <param name="numbers">
        /// Numbers for for which the greatest common divisor will be find.
        /// </param>
        /// <returns>
        /// A 2-tuple as a value type with two field:
        /// gcd - the greatest common for input numbers
        /// executionTime - the total elapsed time measured by the current instance, in timer ticks.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input data is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// Input data contains zero.
        /// Input data contains less than two numbers.
        /// </exception>
        public static (int gcd, long executionTime) FindGCDByEuclide(params int[] numbers)
        {
            var counterTime = Stopwatch.StartNew();

            CheckInputData(numbers);

            int interimGCD = FindGCDByEuclide(numbers[0], numbers[1]);
            int indexOfNextNumber = 2;

            while (indexOfNextNumber < numbers.Length)
            {
                interimGCD = FindGCDByEuclide(interimGCD, numbers[indexOfNextNumber++]);
            }

            counterTime.Stop();

            long spendingTime = counterTime.ElapsedTicks;
            var result = (gcd: interimGCD, executionTime: spendingTime);

            return result;
        }

        /// <summary>
        /// Performs finding the greatest common divisor by Stain's algorithm.
        /// </summary>
        /// <param name="numbers">
        /// Numbers for for which the greatest common divisor will be find.
        /// </param>
        /// <returns>
        /// A 2-tuple as a value type with two field:
        /// gcd - the greatest common for input numbers
        /// executionTime - the total elapsed time measured by the current instance, in timer ticks.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input data is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// Input data contains zero.
        /// Input data contains less than two numbers.
        /// </exception>
        public static (int gcd, long executionTime) FindGCDByStain(params int[] numbers)
        {
            var counterTime = Stopwatch.StartNew();

            CheckInputData(numbers);

            int interimGCD = FindGCDByEuclide(numbers[0], numbers[1]);
            int indexOfNextNumber = 2;

            while (indexOfNextNumber < numbers.Length)
            {
                interimGCD = FindGCDByStain(interimGCD, numbers[indexOfNextNumber++]);
            }

            counterTime.Stop();
           
            long spendingTime = counterTime.ElapsedTicks;
            var result = (gcd: interimGCD, executionTime: spendingTime);

            return result;          
        }

        /// <summary>
        /// Performs finding the greatest common divisor by  Euclide's and Stain's algorithms and in result gives the time of their execution.
        /// </summary>
        /// <param name="euclideTimeExecution">
        /// The total elapsed time measured by the current instance, in timer ticks for  Euclide's algorithm.</param>
        /// <param name="stainTimeExecution">
        /// The total elapsed time measured by the current instance, in timer ticks for  Stain's algorithm.</param>
        /// <param name="numbers">
        /// Numbers for for which the time execution will be find.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input data is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when:
        /// Input data contains zero.
        /// Input data contains less than two numbers.
        /// </exception>
        public static void TakeTimeExecution(out long euclideTimeExecution, out long stainTimeExecution, params int[] numbers)
        {
            // TODO ask about this: should I call it? Due to the fact this method will be call again in next two methods.
            CheckInputData(numbers);

            var euclideResult = FindGCDByEuclide(numbers);
            var stainResult = FindGCDByStain(numbers);

            euclideTimeExecution = euclideResult.executionTime;
            stainTimeExecution = euclideResult.gcd;
        }

        private static int FindGCDByStain(int firstNumber, int secondNumber)
        {
            MakeAbsoluteNumbers(ref firstNumber, ref secondNumber);

            int a = firstNumber;
            int b = secondNumber;
            int disparity = 1;

            while (((a ^ 0) != 0) && ((b ^ 0) != 0))
            {
                while (((a & 1) | (b & 1)) == 0)
                {
                    a = a >> 1;
                    b = b >> 1;
                    disparity = disparity << 1;
                }

                while ((a & 1) == 0)
                {
                    a = a >> 1;
                }

                while ((b & 1) == 0)
                {
                    b = b >> 1;
                }

                if (a >= b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return b * disparity;
        }

        private static int FindGCDByEuclide(int firstNumber, int secondNumber)
        {
            MakeAbsoluteNumbers(ref firstNumber, ref secondNumber);

            int a = firstNumber;
            int b = secondNumber;

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }

                if (b > a)
                {
                    b = b - a;
                }
            }

            return a;
        }

        private static void MakeAbsoluteNumbers(ref int firstNumber, ref int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);
        }

        private static void CheckInputData(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException($"The {nameof(numbers)} can not be null.");
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException($"Unable to find GCD for single number. The length of {nameof(numbers)} must be more than 2.");
            }

            if (Array.IndexOf(numbers, 0) != -1)
            {
                throw new ArgumentException($"The {nameof(numbers)} must not contain zero.");
            }
        }
    }
}
