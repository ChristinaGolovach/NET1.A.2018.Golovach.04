using System;
using NUnit.Framework;
using DoubleExtensionLogic;
using TransformLogic.Implementations;

namespace TransformLogic.Tests
{
    [TestFixture]
    public class TransformTests
    {
        [TestCase(new double[] { -23.809999 }, ExpectedResult = new string[] { "minus two three point eight zero nine nine nine nine" })]
        [TestCase(new double[] { -23.809, 0.295, 15.17, 0 }, ExpectedResult = new string[] { "minus two three point eight zero nine", "zero point two nine five", "one five point one seven", "zero" })]
        public string[] TransformDoube_PassCorrectArrayOfDouble_ReturnArrayOfString(double[] numbers)
           => Transform.TransformTo(numbers, new TransformerToWord());

        [TestCase(new double[] { double.Epsilon, double.MaxValue, double.MinValue, double.NaN, double.NegativeInfinity, double.PositiveInfinity }, 
                  ExpectedResult = new string[] { "four point nine four zero six five six four five eight four one two four seven E minus three two four",
                                                  "one point seven nine seven six nine three one three four eight six two three two E plus three zero eight",
                                                  "minus one point seven nine seven six nine three one three four eight six two three two E plus three zero eight",
                                                  "Nan", "NegativeInfinity", "PositiveInfinity" })]
        public string[] TransformDoube_PassCorrectArrayOfSpecialСaseOfDouble_ReturnArrayOfString(double[] numbers)
            => Transform.TransformTo(numbers, new TransformerToWord());

        [Test]
        public void TransformDoube_PassNullArray_TrownArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Transform.TransformTo(null, new TransformerToWord()));

        [Test]
        public void TransformDoube_PassEmptyArray_TrownArgumentException()
           => Assert.Throws<ArgumentException>(() => Transform.TransformTo(new double[0], new TransformerToWord()));

        [TestCase(new double[] { -255.255 }, ExpectedResult = new string[] { "1100000001101111111010000010100011110101110000101000111101011100" })]
        [TestCase(new double[] { 255.255 }, ExpectedResult = new string[] { "0100000001101111111010000010100011110101110000101000111101011100" })]
           public string[] TransformDoube_PassDoubleValue_ReturnedStringOfBits(double[] numbers)
            => Transform.TransformTo(numbers, new TransformerToIEEE());

        [TestCase(new double[] { -255.255 })]
        [TestCase(new double[] { 255.255 })]
        public void TransformDoube_PassDoubleValueAndNullTransdormer_TrownArgumentNullException(double[] numbers)
            => Assert.Throws<ArgumentNullException>(() => Transform.TransformTo(numbers, (ITransformer<double, string>) null));

        #region Tests for method with delegate              

        [TestCase(new double[] { -23.809999 }, ExpectedResult = new string[] { "minus two three point eight zero nine nine nine nine" })]
        [TestCase(new double[] { -23.809, 0.295, 15.17, 0 }, ExpectedResult = new string[] { "minus two three point eight zero nine", "zero point two nine five", "one five point one seven", "zero" })]
        public string[] TransformDoubeWithDelegateVersion_ReturnArrayOfString(double[] numbers)
                => Transform.TransformTo(numbers, DoubleExtensionToWord.TransformDoubleToWord);

        [TestCase(new double[] { double.Epsilon, double.MaxValue, double.MinValue, double.NaN, double.NegativeInfinity, double.PositiveInfinity },
                  ExpectedResult = new string[] { "four point nine four zero six five six four five eight four one two four seven E minus three two four",
                                                  "one point seven nine seven six nine three one three four eight six two three two E plus three zero eight",
                                                  "minus one point seven nine seven six nine three one three four eight six two three two E plus three zero eight",
                                                  "Nan", "NegativeInfinity", "PositiveInfinity" })]
        public string[] TransformDoubeWithDelegateVersion_PassCorrectArrayOfSpecialСaseOfDouble_ReturnArrayOfString(double[] numbers)
            => Transform.TransformTo(numbers, DoubleExtensionToWord.TransformDoubleToWord);

        [TestCase(new double[] { -255.255 }, ExpectedResult = new string[] { "1100000001101111111010000010100011110101110000101000111101011100" })]
        [TestCase(new double[] { 255.255 }, ExpectedResult = new string[] { "0100000001101111111010000010100011110101110000101000111101011100" })]
        public string[] TransformDoubeWithDelegateVersion_PassDoubleValue_ReturnedStringOfBits(double[] numbers)
                => Transform.TransformTo(numbers, DoubleExtension.DoubleToIEEE754);

        //private delegate string[] TransformDelegate(double[] numbers);
        //TransformDelegate transformdelegate = null;

        //[TestCase(new double[] { -255.255 })]
        //[TestCase(new double[] { 255.255 })]
        //public void TransformDoubeWithDelegateVersion_PassDoubleValueAndNullTransdormer_TrownArgumentNullException(double[] numbers)
        //        => Assert.Throws<ArgumentNullException>(() => Transform.TransformTo(numbers, transformdelegate));

        #endregion Tests for method with delegate 

        #region Filter with IPredicate
        [TestCase(new int[] { 1, 26, 24, 5, -78, 1 }, ExpectedResult = new int[] { 26, 24, -78 })]
        public int[] Filter_PassIntArrayAndIPredicate_ReturnArrayOnlyEvenNumbers(int[] source)
            => Transform.Filter(source, new IntEvenPredicate());

        #endregion
    }
}
