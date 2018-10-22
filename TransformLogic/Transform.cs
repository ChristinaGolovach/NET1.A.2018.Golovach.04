using System;
using System.Globalization;
using System.Text;
using System.Threading;
using DoubleExtensionLogic;

namespace TransformLogic
{
    /// <summary>
    /// Represent a class that works with Double type and performs the transforming array of numbers to array of words.
    /// </summary>
    public static class Transform
    {
        /// <summary>
        /// Performs the transforming array of double numbers to string array of words.  
        /// </summary>
        /// <param name="numbers">
        /// The array for which the transforming will be executed</param>
        /// <returns>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the input array is empty.
        /// </exception>
        public static string[] TransformToWords(double[] numbers)
        {
            CheckInputArray(numbers);

            int i = 0;
            string[] numbersInWordsView = new string[numbers.Length];
            
            foreach (double number in numbers)
            {
                numbersInWordsView[i] = TransformDoubleToWord(number);
                i++;
            }

            return numbersInWordsView;
        }

        /// <summary>
        /// Performs the transforming array of double numbers to string array of words in IEEE754 format.  
        /// </summary>
        /// <param name="numbers">
        /// The array for which the transforming will be executed.</param>
        /// <returns>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the input array is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the input array is empty.
        /// </exception>
        public static string[] TransformToIEEEFormat(double[] numbers)
        {
            CheckInputArray(numbers);

            int i = 0;
            string[] numbersInWordsView = new string[numbers.Length];

            foreach (double number in numbers)
            {

                numbersInWordsView[i] = number.DoubleToIEEE754();
                i++;
            }

            return numbersInWordsView;
        }

        private static string TransformDoubleToWord(double number)
        {          
            string specialValueOfDouble = SpecialСaseOfDouble(number);
           
            if (!string.IsNullOrEmpty(specialValueOfDouble))
            {
                return specialValueOfDouble;
            }                

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Us");
            char[] symbolsOfNumber = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'E', '.', '-', '+' };
            string[] wordsOfSymbols = new string[] { "zero ", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine ", "E ", "point ", "minus ", "plus " };
            string numberInStringView = number.ToString();
            StringBuilder numberInWordView = new StringBuilder();

            foreach (char symbol in numberInStringView)
            {
                int index = Array.IndexOf(symbolsOfNumber, symbol);
                numberInWordView.Append(wordsOfSymbols[index]);
            }

            numberInWordView.Remove(numberInWordView.Length - 1, 1);

            return numberInWordView.ToString();
        }

        private static string SpecialСaseOfDouble(double number)
        {
            if (double.IsNaN(number))
            {
                return "Nan";
            }                

            if (double.IsNegativeInfinity(number))
            {
                return "NegativeInfinity";
            }   
            
            if (double.IsPositiveInfinity(number))
            {
                return "PositiveInfinity";
            }                

            return string.Empty;
        }

        private static void CheckInputArray(double[] numbers)
        {
            if (numbers == null)
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
