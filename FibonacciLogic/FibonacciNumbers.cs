using System;
using System.Numerics;
using System.Collections.Generic;

namespace FibonacciLogic
{
    /// <summary>
    /// Class for the generation of Fibonacci numbers.
    /// </summary>
    public static class FibonacciNumbers
    {
        /// <summary>
        /// Generate the sequence of Fibonacci numbers.
        /// </summary>
        /// <param name="count">
        /// The length of result sequence.
        /// </param>
        /// <returns>
        /// Array of Fibonacci numbers.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the value of <paramref name="count"/> less then one.
        /// </exception>
        public static  IEnumerable<BigInteger> GenerateSequence(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"The {nameof(count)} must be more than one.");
            }

            if (count == 1)
            {
                return new BigInteger[] { 1 };
            }

            return GenerateSequenceCore(count);

            IEnumerable<BigInteger> GenerateSequenceCore(int numberCount)
            {
                BigInteger number1 = 1;
                BigInteger number2 = 1;

                for (int i = 0; i < numberCount; i++)
                {
                    yield return number1;
                    BigInteger temp = number2;
                    number2 = number2 + number1;
                    number1 = temp;
                }         
            }
        }
    }
}
