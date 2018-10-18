using System;
using System.Text;
using System.Threading;
using System.Globalization;

namespace TransformLogic
{
    /// <summary>
    /// 
    /// </summary>
    public static class Transform
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string[] TransformToWords(double[] numbers)
        {
            int i = 0;
            string[] numbersInWordsView = new string[numbers.Length];
            
            foreach(double number in numbers)
            {
                numbersInWordsView[i] = TransformDoubleToWord(number);
                i++;
            }

            return numbersInWordsView;
        }

        private static string TransformDoubleToWord(double number)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Us");

            char[] symbolsOfNumber = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'E', '.', '-', '+' };
            string[] wordsOfSymbols = new string[] { "zero ", "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine ", "E ", "point ", "minus ", "plus "};
            string numberInStringView = number.ToString();
            StringBuilder numberInWordView = new StringBuilder();

            foreach(char symbol in numberInStringView)
            {
                int index = Array.IndexOf(symbolsOfNumber, symbol);
                numberInWordView.Append(wordsOfSymbols[index]);
            }

            numberInWordView.Remove(numberInWordView.Length-1, 1);
            return numberInWordView.ToString();
        }
    }
}
