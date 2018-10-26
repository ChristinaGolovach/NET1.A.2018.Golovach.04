using System;

namespace TransformLogic
{
    /// <summary>
    /// Represent a class that works with Double type and performs the transforming array of numbers according to transformer.
    /// </summary>
    public static class Transform
    {
        /// <summary>
        /// Performs the transforming array of double numbers to string array of words.  
        /// </summary>
        /// <param name="numbers">
        /// The array for which the transforming will be executed</param>
        /// <param name="transformer">
        /// Type that implements ITransformer array.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input <paramref name="numbers"/> or <paramref name="transformer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the input array is empty.
        /// </exception>
        public static string[] TransformDoube(double[] numbers, ITransformer transformer)
        {
            CheckInputData(numbers, transformer);

            int i = 0;
            string[] numbersInWordsView = new string[numbers.Length];
            
            foreach (double number in numbers)
            {
                numbersInWordsView[i] = transformer.TransformTo(number);
                i++;
            }

            return numbersInWordsView;
        }

        private static void CheckInputData(double[] numbers, ITransformer transformer)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException($"The {nameof(numbers)} is null.");
            }

            if (transformer == null)
            {
                throw new ArgumentNullException($"The {nameof(transformer)} is null.");
            }

            if (numbers.Length < 1)
            {
                throw new ArgumentException($"The {nameof(numbers)} is empty.");
            }
        }
    }
}
