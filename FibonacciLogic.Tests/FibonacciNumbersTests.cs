using System;
using System.Numerics;
using System.Linq;
using NUnit.Framework;

namespace FibonacciLogic.Tests
{
    [TestFixture]
    public class FibonacciNumbersTests
    {
        [TestCase(25)]
        public void GenerateSequence_Pass25CountOfNumbres_ReturnFibanacciSequence(int count)
        {
            // Arrange
            BigInteger[] expectedResult = new BigInteger[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025 };

            // Act 
            BigInteger[] actualResult = FibonacciNumbers.GenerateSequence(count).ToArray();

            // Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
          
        [TestCase(0)]
        [TestCase(-1)]
        public void GenerateSequence_PassCountOfNumbersLessThanOne_ThrowArgumentException(int count)
            => Assert.Throws<ArgumentException>(() => FibonacciNumbers.GenerateSequence(count));
    }
}
