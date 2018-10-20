using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GCDAlgorithmsLogic.Tests
{
    [TestFixture]
    public class GCDTests
    {
        #region FindGCDByEuclide tests

        [TestCase(945, 301, ExpectedResult = 7)]
        [TestCase(594, 7920, 22374, ExpectedResult = 198)]
        [TestCase(1044, 1512, 2436, ExpectedResult = 12)]
        public int FindGCDByEuclide_PassCorrectNonRepeatingNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByEuclide(numbers).gcd;

        [TestCase(945, 301, 945, 945, ExpectedResult = 7)]
        [TestCase(1044, 1512, 1512, 2436, 1044, 2436, ExpectedResult = 12)]
        public int FindGCDByEuclide_PassCorrectRepeatingNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByEuclide(numbers).gcd;


        [TestCase(945, -301, ExpectedResult = 7)]
        [TestCase(-1044, -1512,  -2436, ExpectedResult = 12)]
        public int FindGCDByEuclide_PassCorrectNegativeNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByEuclide(numbers).gcd;

        [TestCase()]
        public void FindGCDByEuclide_PassNullValue_ThrownArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GCD.FindGCDByEuclide(numbers));
        }             

        [TestCase(945)]
        public void FindGCDByEuclide_PassOneNumber_ThrownArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GCD.FindGCDByEuclide(numbers));

        [TestCase(945, 0, 45)]
        public void FindGCDByEuclide_PassZeroNumbers_ThrownArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GCD.FindGCDByEuclide(numbers));

        #endregion

        #region FindGCDByStain tests
        [TestCase(945, 301, ExpectedResult = 7)]
        [TestCase(594, 7920, 22374, ExpectedResult = 198)]
        [TestCase(1044, 1512, 2436, ExpectedResult = 12)]
        public int FindGCDByStaine_PassCorrectNonRepeatingNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByStain(numbers).gcd;

        [TestCase(945, 301, 945, 945, ExpectedResult = 7)]
        [TestCase(1044, 1512, 1512, 2436, 1044, 2436, ExpectedResult = 12)]
        public int FindGCDByStain_PassCorrectRepeatingNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByStain(numbers).gcd;


        [TestCase(945, -301, ExpectedResult = 7)]
        [TestCase(-1044, -1512, -2436, ExpectedResult = 12)]
        public int FindGCDByStain_PassCorrectNegativeNumbers_ReturnedGCD(params int[] numbers)
            => GCD.FindGCDByStain(numbers).gcd;

        [TestCase()]
        public void FindGCDByStain_PassNullValue_ThrownArgumentException(params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => GCD.FindGCDByEuclide(numbers));
        }

        [TestCase(945)]
        public void FindGCDByStain_PassOneNumber_ThrownArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GCD.FindGCDByStain(numbers));

        [TestCase(945, 0, 45)]
        public void FindGCDByStain_PassZeroNumbers_ThrownArgumentException(params int[] numbers)
            => Assert.Throws<ArgumentException>(() => GCD.FindGCDByStain(numbers));
        #endregion

        #region TakeTimeExecution test

        [TestCase(945, 45)]
        public void TakeTimeExecution_PassCorrectNumbers_ReturnedTimerTicks(params int[] numbers)
        {
            // Arange
            long euclideTimeExecution = 0;
            long stainTimeExecution = 0;

            // Act
            GCD.TakeTimeExecution(out euclideTimeExecution,out stainTimeExecution, numbers);

            // Assert
            Assert.IsTrue(euclideTimeExecution > 0);
            Assert.IsTrue(stainTimeExecution > 0);
        }

        #endregion
    }
}
