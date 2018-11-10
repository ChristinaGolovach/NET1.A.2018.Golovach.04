using System;
using System.Collections.Generic;

namespace TransformLogic
{
    /// <summary>
    /// Represent a class that works with data set and performs the transforming or filter input data.
    /// </summary>
    public static class Transform
    {
        /// <summary>
        /// Performs the transforming data set of type <typeparamref name="TInput"/> to type <typeparamref name="TOutput"/> according to <paramref name="transformer"/>. 
        /// </summary>
        /// <param name="inputSet">
        /// The array for which the transforming will be executed.</param>
        /// <param name="transformer">
        /// Type that implements ITransformer.
        /// </param>
        /// <typeparam name="TInput">
        /// The type of input data set.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// The type of output data set.
        /// </typeparam>
        /// <returns>
        /// Array of <typeparamref name="TOutput"/> type.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input <paramref name="numbers"/> or <paramref name="transformer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="inputSet"/> is empty.
        /// </exception>
        public static TOutput[] TransformTo<TInput, TOutput>(this TInput[] inputSet, ITransformer<TInput, TOutput> transformer)
        {
            CheckInputData(inputSet, transformer);

            return TransformTo(inputSet, transformer.TransformTo);
        }

        /// <summary>
        /// Performs the transforming data set of type <typeparamref name="TInput"/> to type <typeparamref name="TOutput"/> according to <paramref name="transformer"/>. 
        /// </summary>
        /// <param name="inputSet">
        /// The array for which the transforming will be executed.</param>
        /// <param name="transformer">
        /// Delegate for the transformation.
        /// </param>
        /// <typeparam name="TInput">
        /// The type of input data set.
        /// </typeparam>
        /// <typeparam name="TOutput">
        /// The type of output data set.
        /// </typeparam>
        /// <returns>
        /// Array of <typeparamref name="TOutput"/> type.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input <paramref name="numbers"/> or <paramref name="transformer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="inputSet"/> is empty.
        /// </exception>
        public static TOutput[] TransformTo<TInput, TOutput>(this TInput[] inputSet, Func<TInput, TOutput> transformer)
        {
            CheckInputData(inputSet, transformer);

            int i = 0;
            TOutput[] numbersInNewView = new TOutput[inputSet.Length];

            foreach (TInput number in inputSet)
            {
                numbersInNewView[i] = transformer(number);
                i++;
            }

            return numbersInNewView;
        }

        /// <summary>
        /// Filters the input set according to <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="TSource">
        /// Any type.
        /// </typeparam>
        /// <param name="inputSet">
        /// The data set for filtration.
        /// </param>
        /// <param name="predicate">
        /// Any type that implements IPredicate<typeparamref name="TSource"/>>.
        /// </param>
        /// <returns>
        /// A new data set that matching the condition of predicat.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="inputSet"/> or <paramref name="predicate"/> is null.
        /// </exception>
        public static TSource[] Filter<TSource>(this TSource[] inputSet, IPredicate<TSource> predicate)
        {
            CheckInputData(inputSet, predicate);

            return Filter(inputSet, predicate.IsMatch);
        }

        /// <summary>
        /// Filters the input set according to <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="TSource">
        /// Any type.
        /// </typeparam>
        /// <param name="inputSet">
        /// The data set for filtration.
        /// </param>
        /// <param name="predicate">
        /// Delegate for the filtration.
        /// </param>
        /// <returns>
        /// A new data set that matching the condition of predicat.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="inputSet"/> or <paramref name="predicate"/> is null.
        /// </exception>
        public static TSource[] Filter<TSource>(this TSource[] inputSet, Predicate<TSource> predicate) 
        {
            CheckInputData(inputSet, predicate);

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

        private static void CheckInputData<TInput, TOutput>(TInput[] inputSet, ITransformer<TInput, TOutput> transformer)
        {
            if (ReferenceEquals(transformer, null))
            {
                throw new ArgumentNullException($"The {nameof(transformer)} is null.");
            }

            CheckInputData(inputSet);
        }

        private static void CheckInputData<TInput, TOutput>(TInput[] inputSet, Func<TInput, TOutput> transformer)
        {
            if (ReferenceEquals(transformer, null))
            {
                throw new ArgumentNullException($"The {nameof(transformer)} is null.");
            }

            CheckInputData(inputSet);
        }

        private static void CheckInputData<TSource>(TSource[] inputSet, IPredicate<TSource> predicate)
        {
            inputSet = inputSet ?? throw new ArgumentNullException($"The {nameof(inputSet)} can not be null.");

            predicate = predicate ?? throw new ArgumentNullException($"The {nameof(predicate)} can not be null.");
        }

        private static void CheckInputData<TSource>(TSource[] inputSet, Predicate<TSource> predicate)
        {
            inputSet = inputSet ?? throw new ArgumentNullException($"The {nameof(inputSet)} can not be null.");

            predicate = predicate ?? throw new ArgumentNullException($"The {nameof(predicate)} can not be null.");
        }

        private static void CheckInputData<TInput>(TInput[] inputSet)
        {
            if (ReferenceEquals(inputSet, null))
            {
                throw new ArgumentNullException($"The {nameof(inputSet)} is null.");
            }

            if (inputSet.Length < 1)
            {
                throw new ArgumentException($"The {nameof(inputSet)} is empty.");
            }
        }
    }
}
