using System.Runtime.InteropServices;

namespace DoubleExtensionLogic
{
    /// <summary>
    /// Represents a class that extends functionality of System.Double
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Performs the converting of double value to IEEE754 format.
        /// </summary>
        /// <param name="number">
        /// Value for converting to IEEE754 format.</param>
        /// <returns>
        /// String of bits from the source number.
        /// </returns>
        public static string DoubleToIEEE754(this double number)
        {
            int sizeDoubleInBits = sizeof(double) * 8;
            DoubleToLong doubleInLong = new DoubleToLong() { PlaceForDouble = number };
            long numberInLong = doubleInLong.PlaceForLong;
            char[] bitsOfNumber = new char[sizeDoubleInBits];

            for (int i = sizeDoubleInBits - 1; i >= 0; i--)
            {
                bitsOfNumber[i] = (numberInLong & 1) == 1 ? '1' : '0';
                numberInLong = numberInLong >> 1;
            }

            return new string(bitsOfNumber);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLong
        {
            [FieldOffset(0)]
            public double PlaceForDouble;

            [FieldOffset(0)]
            public long PlaceForLong;
        }
    }
}
