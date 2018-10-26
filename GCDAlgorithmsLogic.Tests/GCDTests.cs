using System;
using NUnit.Framework;

namespace GCDAlgorithmsLogic.Tests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(-1044, -1512, -2436)]
        [TestCase(-1512, -456, -45, -789)]
        [TestCase(-1512, 0, 0, -45, 0, -789)]
        public void TTakeTimeExecutionForTwoAlgorithms_PassCorrectNumbers_ReturnedTimeTiksForTwoAlgorithmsMoreThanZero(params int[] numbers)
        {
            // Arrange
            long euclideTime = 0;
            long stainTime = 0;

            // Act
            GCD.TakeTimeExecutionForTwoAlgorithms(out euclideTime, out stainTime, numbers);

            // Assert
            Assert.IsTrue(stainTime > 0 && stainTime > 0);
        }


        #region FindGCDByEuclide tests
        [TestCase(945, 301, ExpectedResult = 7)]
        [TestCase(945, -301, ExpectedResult = 7)]
        public int FindGCDByEuclide_PasstwoCorrectNumbers_ReturnedGCD(int firstNumber, int secondNumber)
            => GCD.FindGCDByEuclide(firstNumber, secondNumber);

        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -301, ExpectedResult = 301)]
        public int FindGCDByEuclide_PassNumberAndZero_ReturnedAbsNumber(int firstNumber, int secondNumber)
            => GCD.FindGCDByEuclide(firstNumber, secondNumber);

        [TestCase(945, 301, 7)]
        [TestCase(0, -301, 301)]
        public void FindGCDByEuclide_PasstwoCorrectNumbers_ReturnedAbsNumberAndCountTicksMoreZero(int firstNumber, int secondNumber, int expectedResult)
        {
            // Arrange
            long timeTicks = 0;
            int result = 0;

            // Act
            result = GCD.FindGCDByEuclide(firstNumber, secondNumber, out timeTicks);

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.IsTrue(timeTicks > 0);
        }            
        
        [TestCase(594, 7920, 22374, ExpectedResult = 198)]
        [TestCase(1044, 1512, 2436, ExpectedResult = 12)]
        [TestCase(0, 1512, -456, ExpectedResult = 24)]
        public int FindGCDByEuclide_PassThreeCorrectNonRepeatingNumbers_ReturnedGCD(int firstNumber, int secondNumber, int thirdNumber)
            => GCD.FindGCDByEuclide(firstNumber, secondNumber, thirdNumber);        

        [TestCase(945, 301, 945, 945, ExpectedResult = 7)]
        [TestCase(1044, 1512, 1512, 2436, 1044, 2436, ExpectedResult = 12)]
        public int FindGCDByEuclide_PassCorrectRepeatingNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByEuclide(numbers);
                
        [TestCase(-1044, -1512,  -2436,  ExpectedResult = 12)]
        [TestCase(-1512, -456, -45, -789, ExpectedResult = 3)]
        [TestCase(-1512, 0, 0, -45, 0, -789, ExpectedResult = 3)]
        public int FindGCDByEuclide_PassCorrectNegativeNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByEuclide(numbers);

        [TestCase]
        public void FindGCDByEuclide_PassNullValue_ThrownArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GCD.FindGCDByEuclide(null));
        }             

        [TestCase(945)]
        public void FindGCDByEuclide_PassOneNumber_ThrownArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GCD.FindGCDByEuclide(numbers));

        #endregion FindGCDByEuclide tests

        #region FindGCDByStain tests
        [TestCase(945, 301, ExpectedResult = 7)]
        [TestCase(945, -301, ExpectedResult = 7)]
        public int FindGCDByStain_PasstwoCorrectNumbers_ReturnedGCD(int firstNumber, int secondNumber)
            => GCD.FindGCDByStain(firstNumber, secondNumber);

        [TestCase(945, 0, ExpectedResult = 945)]
        [TestCase(0, -301, ExpectedResult = 301)]
        public int FindGCDByStain_PassNumberAndZero_ReturnedAbsNumber(int firstNumber, int secondNumber)
            => GCD.FindGCDByStain(firstNumber, secondNumber);

        [TestCase(945, 301, 7)]
        [TestCase(0, -301, 301)]
        public void FindGCDByStain_PasstwoCorrectNumbers_ReturnedAbsNumberAndCountTicksMoreZero(int firstNumber, int secondNumber, int expectedResult)
        {
            // Arrange
            long timeTicks = 0;
            int result = 0;

            // Act
            result = GCD.FindGCDByStain(firstNumber, secondNumber, out timeTicks);

            // Assert
            Assert.AreEqual(expectedResult, result);
            Assert.IsTrue(timeTicks > 0);
        }

        [TestCase(594, 7920, 22374, ExpectedResult = 198)]
        [TestCase(1044, 1512, 2436, ExpectedResult = 12)]
        [TestCase(0, 1512, -456, ExpectedResult = 24)]
        public int FindGCDByStain_PassThreeCorrectNonRepeatingNumbers_ReturnedGCD(int firstNumber, int secondNumber, int thirdNumber)
            => GCD.FindGCDByStain(firstNumber, secondNumber, thirdNumber);

        [TestCase(945, 301, 945, 945, ExpectedResult = 7)]
        [TestCase(1044, 1512, 1512, 2436, 1044, 2436, ExpectedResult = 12)]
        public int FindGCDByStain_PassCorrectRepeatingNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByStain(numbers);
        
        [TestCase(-1044, -1512, -2436, ExpectedResult = 12)]
        [TestCase(-1512, -456, -45, -789, ExpectedResult = 3)]
        [TestCase(-1512, 0, 0, -45, 0, -789, ExpectedResult = 3)]
        public int FindGCDByStain_PassCorrectNegativeNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByStain(numbers);
        
        [TestCase]
        public void FindGCDByStain_PassNullValue_ThrownArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GCD.FindGCDByStain(null));
        }

        [TestCase(945)]
        public void FindGCDByStain_PassOneNumber_ThrownArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GCD.FindGCDByStain(numbers));
        #endregion FindGCDByStain tests
    }
}
