using System.Text;
using System.Globalization;
using System.Threading;

namespace TransformLogic
{
    public class TransformerToWord : ITransformer<double, string>
    {
        public string TransformTo(double number)
        {
            return number.TransformDoubleToWord();
        }
    }

    /// <summary>
    /// Represent a class that works with Double type and performs the transforming double number to string of words.
    /// </summary>
    public static class DoubleExtensionToWord
    {
        /// <summary>
        /// Extension method for double.
        /// </summary>
        /// <param name="number">
        /// Input number.
        /// </param>
        /// <returns>
        /// String of words.
        /// </returns>
        public static string TransformDoubleToWord(this double number)
        {
            string specialValueOfDouble = SpecialСaseOfDouble(number);

            if (!string.IsNullOrEmpty(specialValueOfDouble))
            {
                return specialValueOfDouble;
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Us");
            string symbolsOfNumber = "0123456789E.-+";
            string[] wordsOfSymbols = new string[] { "zero ", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine ", "E ", "point ", "minus ", "plus " };
            string numberInStringView = number.ToString();
            StringBuilder numberInWordView = new StringBuilder();

            foreach (char symbol in numberInStringView)
            {
                int index = symbolsOfNumber.IndexOf(symbol);
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
    }
}
