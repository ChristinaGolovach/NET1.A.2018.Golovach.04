using System;
using NUnit.Framework;

namespace TransformLogic.Tests
{
    [TestFixture]
    public class TransformTests
    {
        [TestCase(new double[] { -23.809999 }, ExpectedResult = new string[] { "minus two three point eight zero nine nine nine nine" })]
        [TestCase(new double[] { -23.809, 0.295, 15.17, 0 }, ExpectedResult = new string[] { "minus two three point eight zero nine", "zero point two nine five", "one five point one seven", "zero" })]
        public string[] TransformToWords_PassCorrectArrayOfDouble_ReturnArrayOfString(double[] numbers)
            => Transform.TransformToWords(numbers);

        [TestCase(new double[] { double.Epsilon, double.MaxValue, double.MinValue, double.NaN, double.NegativeInfinity, double.PositiveInfinity }, 
                  ExpectedResult = new string[] { "four point nine four zero six five six four five eight four one two four seven E minus three two four",
                                                  "one point seven nine seven six nine three one three four eight six two three two E plus three zero eight",
                                                  "minus one point seven nine seven six nine three one three four eight six two three two E plus three zero eight",
                                                  "Nan", "NegativeInfinity", "PositiveInfinity" })]
        public string[] TransformToWords_PassCorrectArrayOfSpecialСaseOfDouble_ReturnArrayOfString(double[] numbers)
            => Transform.TransformToWords(numbers);
        
        [Test]
        public void TransformToWords_PassNullArray_TrownArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Transform.TransformToWords(null));

        [Test]
        public void TransformToWords_PassEmptyArray_TrownArgumentException()
           => Assert.Throws<ArgumentException>(() => Transform.TransformToWords(new double[0]));
    }
}
