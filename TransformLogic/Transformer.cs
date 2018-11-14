using System;
using System.Linq;
using System.Collections.Generic;

namespace TransformLogic
{
    /// <summary>
    /// Represent a class that works with data set and performs the transforming or filter input data.
    /// </summary>
    public static class Transformer
    {
        /// <summary>
        /// Performs the transforming data set of type <typeparamref name="TInput"/> to type <typeparamref name="TOutput"/> according to <paramref name="transformer"/>. 
        /// </summary>
        /// <param name="collection">
        /// The collection for which the transforming will be executed.</param>
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
        /// The data set of <typeparamref name="TOutput"/> type.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input <paramref name="collection"/> or <paramref name="transformer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="collection"/> is empty.
        /// </exception>
        public static IEnumerable<TOutput> Transform<TInput, TOutput>(this IEnumerable<TInput> collection, ITransformer<TInput, TOutput> transformer)
        {
            CheckInputData(collection, transformer);

            return Transform(collection, transformer.Transform);
        }

        /// <summary>
        /// Performs the transforming data set of type <typeparamref name="TInput"/> to type <typeparamref name="TOutput"/> according to <paramref name="transformer"/>. 
        /// </summary>
        /// <param name="collection">
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
        /// The data set of <typeparamref name="TOutput"/> type.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input <paramref name="collection"/> or <paramref name="transformer"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="collection"/> is empty.
        /// </exception>
        public static IEnumerable<TOutput> Transform<TInput, TOutput>(this IEnumerable<TInput> collection, Func<TInput, TOutput> transformer)
        {
            CheckInputData(collection, transformer);

            return TransformCore(collection, transformer);
        }

        /// <summary>
        /// Filters the input set according to <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="TSource">
        /// Any type.
        /// </typeparam>
        /// <param name="collection">
        /// The data set for filtration.
        /// </param>
        /// <param name="predicate">
        /// Any type that implements IPredicate<typeparamref name="TSource"/>>.
        /// </param>
        /// <returns>
        /// A new data set that matching the condition of predicat.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="collection"/> or <paramref name="predicate"/> is null.
        /// </exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> collection, IPredicate<TSource> predicate)
        {
            CheckInputData(collection, predicate);

            return Filter(collection, predicate.IsMatch);
        }

        /// <summary>
        /// Filters the input set according to <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="TSource">
        /// Any type.
        /// </typeparam>
        /// <param name="collection">
        /// The data set for filtration.
        /// </param>
        /// <param name="predicate">
        /// Delegate for the filtration.
        /// </param>
        /// <returns>
        /// A new data set that matching the condition of predicat.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="collection"/> or <paramref name="predicate"/> is null.
        /// </exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> collection, Predicate<TSource> predicate)
        {
            CheckInputData(collection, predicate);

            return FilterCore(collection, predicate);

        }

        private static IEnumerable<TOutput> TransformCore<TInput, TOutput>(this IEnumerable<TInput> collection, Func<TInput, TOutput> transformer)
        {
            foreach (TInput number in collection)
            {
                yield return transformer(number);
            }
        }

        private static IEnumerable<TSource> FilterCore<TSource>(this IEnumerable<TSource> collection, Predicate<TSource> predicate)
        {
            foreach (TSource input in collection)
            {
                if (predicate(input))
                {
                    yield return input;
                }
            }
        }

        private static void CheckInputData<TInput, TOutput>(IEnumerable<TInput> collection, ITransformer<TInput, TOutput> transformer)
        {
            if (ReferenceEquals(transformer, null))
            {
                throw new ArgumentNullException($"The {nameof(transformer)} is null.");
            }

            CheckInputData(collection);
        }

        private static void CheckInputData<TInput, TOutput>(IEnumerable<TInput> collection, Func<TInput, TOutput> transformer)
        {
            if (ReferenceEquals(transformer, null))
            {
                throw new ArgumentNullException($"The {nameof(transformer)} is null.");
            }

            CheckInputData(collection);
        }

        private static void CheckInputData<TSource>(IEnumerable<TSource> collection, IPredicate<TSource> predicate)
        {
            collection = collection ?? throw new ArgumentNullException($"The {nameof(collection)} can not be null.");

            predicate = predicate ?? throw new ArgumentNullException($"The {nameof(predicate)} can not be null.");
        }

        private static void CheckInputData<TSource>(IEnumerable<TSource> collection, Predicate<TSource> predicate)
        {
            collection = collection ?? throw new ArgumentNullException($"The {nameof(collection)} can not be null.");

            predicate = predicate ?? throw new ArgumentNullException($"The {nameof(predicate)} can not be null.");
        }

        private static void CheckInputData<TInput>(IEnumerable<TInput> collection)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"The {nameof(collection)} is null.");
            }

            if (collection.ToArray().Length <= 0)
            {
                throw new ArgumentException($"The {nameof(collection)} is empty.");
            }
        }
    }
}
