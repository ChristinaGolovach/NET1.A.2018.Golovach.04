using System;
using System.Collections.Generic;

namespace TransformLogic
{
    /// <summary>
    /// Represent a class that works with Double type and performs the transforming array of numbers according to transformer.
    /// </summary>
    public static class Transform
    {
        /// <summary>
        /// Performs the transforming array of double numbers to string array. 
        /// </summary>
        /// <param name="numbers">
        /// The array for which the transforming will be executed.</param>
        /// <param name="transformer">
        /// Type that implements ITransformer array.
        /// </param>
        /// <returns>
        /// Array of strings.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input <paramref name="numbers"/> or <paramref name="transformer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the input array is empty.
        /// </exception>
        public static TOutput[] TransformTo<TInput, TOutput>(TInput[] numbers, ITransformer<TInput, TOutput> transformer)
        {
            CheckInputData(numbers, transformer);

            return TransformTo(numbers, transformer.TransformTo);
        }

        /// <summary>
        /// Performs the transforming array of double numbers to string array.  
        /// </summary>
        /// <param name="numbers">
        /// The array for which the transforming will be executed.</param>
        /// <param name="transformer">
        /// Method which corresponds to signature of <see cref="Transformer"/>.
        /// </param>
        /// <returns>
        /// Array of strings.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input <paramref name="numbers"/> or <paramref name="transformer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the input array is empty.
        /// </exception>
        public static TOutput[] TransformTo<TInput, TOutput>(TInput[] numbers, Func<TInput, TOutput> transformer)
        {
            CheckInputData(numbers, transformer);

            int i = 0;
            TOutput[] numbersInNewView = new TOutput[numbers.Length];

            foreach (TInput number in numbers)
            {
                numbersInNewView[i] = transformer(number);
                i++;
            }

            return numbersInNewView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="inputSet"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static TSource[] Filter<TSource>(this TSource[] inputSet, IPredicate<TSource> predicate)
        {
            return Filter(inputSet, predicate.IsMatch);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="inputSet"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static TSource[] Filter<TSource>(this TSource[] inputSet, Predicate<TSource> predicate) 
        {
            List<TSource> resultSet = new List<TSource>();

            foreach(TSource input in inputSet)
            {
                if (predicate(input))
                {
                    resultSet.Add(input);
                }
            }

            return resultSet.ToArray();
        }

        private static void CheckInputData<TInput, TOutput>(TInput[] numbers, ITransformer<TInput, TOutput> transformer)
        {
            if (ReferenceEquals(transformer, null))
            {
                throw new ArgumentNullException($"The {nameof(transformer)} is null.");
            }

            CheckInputData(numbers);
        }

        private static void CheckInputData<TInput, TOutput>(TInput[] numbers, Func<TInput, TOutput> transformer)
        {
            if (ReferenceEquals(transformer, null))
            {
                throw new ArgumentNullException($"The {nameof(transformer)} is null.");
            }

            CheckInputData(numbers);
        }

        private static void CheckInputData<TInput>(TInput[] numbers)
        {
            if (ReferenceEquals(numbers, null))
            {
                throw new ArgumentNullException($"The {nameof(numbers)} is null.");
            }

            if (numbers.Length < 1)
            {
                throw new ArgumentException($"The {nameof(numbers)} is empty.");
            }
        }
    }
}
