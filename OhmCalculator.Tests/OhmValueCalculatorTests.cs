using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OhmCalculator.Tests
{
    [TestClass]
    public class OhmValueCalculatorTests
    {
        [TestMethod]
        public void CalculateOhmValue_GoodTest()
        {
            IOhmValueCalculator ohmCal = new OhmValueCalculator();
            int returnValue = ohmCal.CalculateOhmValue("Red", "Violet", "Yellow", "Gold");

            Assert.AreEqual(27 * 10000, returnValue);
        }

        [TestMethod]
        public void CalculateOhmValue_BadBandColor()
        {
            IOhmValueCalculator ohmCal = new OhmValueCalculator();
            int returnValue = ohmCal.CalculateOhmValue("Grayish", "Violet", "Yellow", "Gold");

            Assert.AreEqual(-1, returnValue);
        }
    }
}
