using System;
using System.Diagnostics;

namespace GCDAlgorithmsLogic
{
    /// <summary>
    /// Delegate for the method <see cref="CoreFindGCDBForArray"/>
    /// </summary>
    /// <param name="firstNumber"></param>
    /// <param name="secondNumber"></param>
    /// <returns></returns>
    public delegate int GDBForTwoNumber(int firstNumber, int secondNumber);
   
    /// <summary>
    /// Represents a class for finding the greatest common divisor by Euclide's and Stain's algorithms.
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// Performs finding the greatest common divisor by Euclide's and Stain's algorithms and in result gives the time of their execution.
        /// </summary>
        /// <param name="euclideTime">
        /// The total elapsed time measured in timer ticks for  Euclide's algorithm.</param>
        /// <param name="stainTimeExecution">
        /// The total elapsed time measured  in timer ticks for  Stain's algorithm.</param>
        /// <param name="numbers">
        /// Numbers for for which the time execution will be find.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input data is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when input data contains less than two numbers.
        /// </exception>
        public static void TakeTimeExecutionForTwoAlgorithms(out long euclideTime, out long stainTime, params int[] numbers)
        {
            CheckInputData(numbers);

            var counterEuclideTime = Stopwatch.StartNew();

            CoreFindGCDBForArray(CoreFindGCDByEuclide, numbers);

            euclideTime = counterEuclideTime.ElapsedTicks;

            var counterStainTime = Stopwatch.StartNew();

            CoreFindGCDBForArray(CoreFindGCDByStain, numbers);

            stainTime = counterStainTime.ElapsedTicks;
        }

        /// <summary>
        /// Performs finding the greatest common divisor by Euclide's algorithm.
        /// </summary>
        /// <param name="firstNumber">
        /// The first integer number.
        /// </param>
        /// <param name="secondNumber">
        /// The second integer number.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        public static int FindGCDByEuclide(int firstNumber, int secondNumber)
            => CoreFindGCDByEuclide(firstNumber, secondNumber);

        /// <summary>
        /// Performs finding the greatest common divisor by Euclide's algorithm.
        /// </summary>
        /// <param name="firstNumber">
        /// The first integer number.
        /// </param>
        /// <param name="secondNumber">
        /// The second integer number.
        /// </param>
        /// <param name="timeTicks">
        /// The total elapsed time measured in timer ticks.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        public static int FindGCDByEuclide(int firstNumber, int secondNumber, out long timeTicks)
        {
            var counterTime = Stopwatch.StartNew();
            int result = CoreFindGCDByEuclide(firstNumber, secondNumber);
            timeTicks = counterTime.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// Performs finding the greatest common divisor by Euclide's algorithm.
        /// </summary>
        /// <param name="firstNumber">
        /// The first integer number.
        /// </param>
        /// <param name="secondNumber">
        /// The second integer number.
        /// </param>
        /// <param name="thirdNumber">
        /// The third integer number.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        public static int FindGCDByEuclide(int firstNumber, int secondNumber, int thirdNumber)
            => CoreFindGCDByEuclide(thirdNumber, CoreFindGCDByEuclide(firstNumber, secondNumber));

        /// <summary>
        /// Performs finding the greatest common divisor by Euclide's algorithm.
        /// </summary>
        /// <param name="firstNumber">
        /// The first integer number.
        /// </param>
        /// <param name="secondNumber">
        /// The second integer number.
        /// </param>
        /// <param name="thirdNumber">
        /// The third integer number.
        /// </param>
        /// <param name="timeTicks">
        /// The total elapsed time measured in timer ticks.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        public static int FindGCDByEuclide(int firstNumber, int secondNumber, int thirdNumber, out long timeTicks)
        {
            var counterTime = Stopwatch.StartNew();
            int result = CoreFindGCDByEuclide(thirdNumber, CoreFindGCDByEuclide(firstNumber, secondNumber));
            timeTicks = counterTime.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// Performs finding the greatest common divisor by Euclide's algorithm.
        /// </summary>
        /// <param name="numbers">
        /// Numbers for for which the greatest common divisor will be find.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input data is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when input data contains less than two numbers.
        /// </exception>
        public static int FindGCDByEuclide(params int[] numbers)
        {
            CheckInputData(numbers);

            int result = CoreFindGCDBForArray(FindGCDByEuclide, numbers);

            return result;
        }

        /// <summary>
        /// Performs finding the greatest common divisor by Euclide's algorithm.
        /// </summary>
        /// <param name="numbers">
        /// Numbers for for which the greatest common divisor will be find.
        /// </param>
        /// <param name="timeTicks">
        /// The total elapsed time measured in timer ticks.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input data is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when input data contains less than two numbers.
        /// </exception>
        public static int FindGCDByEuclide(out long timeTicks, params int[] numbers)
        {
            CheckInputData(numbers);

            var counterTime = Stopwatch.StartNew();

            int result = CoreFindGCDBForArray(FindGCDByEuclide, numbers);

            counterTime.Stop();

            timeTicks = counterTime.ElapsedTicks;            

            return result;
        }
        
        /// <summary>
        /// Performs finding the greatest common divisor by Stain's algorithm.
        /// </summary>
        /// <param name="firstNumber">
        /// The first integer number.
        /// </param>
        /// <param name="secondNumber">
        /// The second integer number.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        public static int FindGCDByStain(int firstNumber, int secondNumber)
            => CoreFindGCDByStain(firstNumber, secondNumber);

        /// <summary>
        /// Performs finding the greatest common divisor by Stain's algorithm.
        /// </summary>
        /// <param name="firstNumber">
        /// The first integer number.
        /// </param>
        /// <param name="secondNumber">
        /// The second integer number.
        /// </param>
        /// <param name="timeTicks">
        /// The total elapsed time measured in timer ticks.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        public static int FindGCDByStain(int firstNumber, int secondNumber, out long timeTicks)
        {
            var counterTime = Stopwatch.StartNew();
            int result = CoreFindGCDByStain(firstNumber, secondNumber);
            timeTicks = counterTime.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// Performs finding the greatest common divisor by Stain's algorithm.
        /// </summary>
        /// <param name="firstNumber">
        /// The first integer number.
        /// </param>
        /// <param name="secondNumber">
        /// The second integer number.
        /// </param>
        /// <param name="thirdNumber">
        /// The third integer number.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        public static int FindGCDByStain(int firstNumber, int secondNumber, int thirdNumber)
            => CoreFindGCDByStain(thirdNumber, CoreFindGCDByStain(firstNumber, secondNumber));
        
        /// <summary>
        /// Performs finding the greatest common divisor by Stain's algorithm.
        /// </summary>
        /// <param name="firstNumber">
        /// The first integer number.
        /// </param>
        /// <param name="secondNumber">
        /// The second integer number.
        /// </param>
        /// <param name="thirdNumber">
        /// The third integer number.
        /// </param>
        /// <param name="timeTicks">
        /// The total elapsed time measured in timer ticks.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        public static int FindGCDByStain(int firstNumber, int secondNumber, int thirdNumber, out long timeTicks)
        {
            var counterTime = Stopwatch.StartNew();
            int result = CoreFindGCDByStain(thirdNumber, CoreFindGCDByStain(firstNumber, secondNumber));
            timeTicks = counterTime.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// Performs finding the greatest common divisor by Stain's algorithm.
        /// </summary>
        /// <param name="numbers">
        /// Numbers for for which the greatest common divisor will be find.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input data is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when input data contains less than two numbers.
        /// </exception>
        public static int FindGCDByStain(params int[] numbers)
        {           
            CheckInputData(numbers);

            int result = CoreFindGCDBForArray(FindGCDByStain, numbers);

            return result;
        }
        
        /// <summary>
        /// Performs finding the greatest common divisor by Stain's algorithm.
        /// </summary>
        /// <param name="numbers">
        /// Numbers for for which the greatest common divisor will be find.
        /// </param>
        /// <param name="timeTicks">
        /// The total elapsed time measured in timer ticks.
        /// </param>
        /// <returns>
        /// The greatest common divisor for input numbers.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input data is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when input data contains less than two numbers.
        /// </exception>
        public static int FindGCDByStain(out long timeTicks, params int[] numbers)
        {
            CheckInputData(numbers);

            var counterTime = Stopwatch.StartNew();

            int result = CoreFindGCDBForArray(CoreFindGCDByStain, numbers);         

            counterTime.Stop();

            timeTicks = counterTime.ElapsedTicks;            

            return result;          
        }
                
        private static int CoreFindGCDBForArray(GDBForTwoNumber gbdForTwoNumber, int[] numbers)
        {
            int interimGCD = gbdForTwoNumber(numbers[0], numbers[1]);
            int indexOfNextNumber = 2;

            while (indexOfNextNumber < numbers.Length)
            {
                interimGCD = gbdForTwoNumber(interimGCD, numbers[indexOfNextNumber++]);
            }

            return interimGCD;
        }
        
        #region Core Stain
        private static int CoreFindGCDByStain(int firstNumber, int secondNumber)
        {
            MakeAbsoluteNumbers(ref firstNumber, ref secondNumber);

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

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
        #endregion Core Stain

        #region Core Euclide 
        private static int CoreFindGCDByEuclide(int firstNumber, int secondNumber)
        {
            MakeAbsoluteNumbers(ref firstNumber, ref secondNumber);

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }
            
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
        #endregion Core Euclide

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
        }
    }
}
