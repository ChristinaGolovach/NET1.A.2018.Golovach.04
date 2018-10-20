using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDAlgorithmsLogic
{
    /// <summary>
    /// 
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int FindGCDByEuclide(params int[] numbers)
        {
            CheckInputData(numbers);

            int interimGCD = FindGCDByEuclide(numbers[0], numbers[1]);
            int indexOfNextNumber = 2;

            while (indexOfNextNumber < numbers.Length)
            {
                interimGCD = FindGCDByEuclide(interimGCD, numbers[indexOfNextNumber++]);
            }

            return interimGCD;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int FindGCDByStain(params int[] numbers)
        {
            CheckInputData(numbers);

            int interimGCD = FindGCDByEuclide(numbers[0], numbers[1]);
            int indexOfNextNumber = 2;

            while (indexOfNextNumber < numbers.Length)
            {
                interimGCD = FindGCDByStain(interimGCD, numbers[indexOfNextNumber++]);
            }

            return interimGCD;
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

        private static void CheckInputData(int[] numbers)
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
