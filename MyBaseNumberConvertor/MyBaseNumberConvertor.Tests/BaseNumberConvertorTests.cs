using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyBaseNumberConvertor.Tests
{
    [TestClass]
    public class BaseNumberConvertorTests
    {
        [TestMethod]
        public void NumberConvertorToBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number = baseNumberConvertor.ConvertToBase(128, 2, 12);
            var correctResult = new byte[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
            CollectionAssert.AreEqual(correctResult, number);
        }

        [TestMethod]
        public void NumberConvertorFromBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var numberdigit = new byte[] { 1, 0, 0, 0, 0, 0, 0, 0 };
            var number = baseNumberConvertor.ConvertFromBase(numberdigit, 2);
            Assert.AreEqual(number, 128);
        }
        [TestMethod]
        public void AndOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var numberNumberDigitX = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var numberNumberDigitY = new byte[] { 1, 0, 0, 0, 1, 1, 0, 1 };
            var correctRezult = new byte[] { 1, 0, 1, 0, 1, 1, 1, 1 };
            var actualRezult = baseNumberConvertor.AndOperator(numberNumberDigitX, numberNumberDigitY);
            CollectionAssert.AreEqual(actualRezult, correctRezult);
        }
        [TestMethod]
        public void OrOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var numberNumberDigitX = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var numberNumberDigitY = new byte[] { 1, 0, 0, 0, 1, 1, 0, 1 };
            var correctRezult = new byte[] { 1, 0, 0, 0, 1, 0, 0, 1 };
            var actualRezult = baseNumberConvertor.OrOperator(numberNumberDigitX, numberNumberDigitY);
            CollectionAssert.AreEqual(actualRezult, correctRezult);
        }


    }
}

