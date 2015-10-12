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
            var number = baseNumberConvertor.ConvertToBase(100, 36, 8);
            var correctResult = new byte[] { 0, 0, 0, 0, 0, 0, 2, 28 };
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
            var firestByte = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte = new byte[] { 1, 0, 0, 0, 1, 1, 0, 1 };
            var correctResult = new byte[] { 1, 0, 1, 0, 1, 1, 1, 1 };
            var actualResult = baseNumberConvertor.AndOperator(firestByte, secondByte);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AndOperatorExceptionTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte = new byte[] { 1, 0, 1, 0, 0, 0, 1, 1, 0, 1 };
            var result = baseNumberConvertor.AndOperator(firestByte, secondByte);
        }

        public void OrOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte = new byte[] { 1, 0, 0, 0, 1, 1, 0, 1 };
            var correctResult = new byte[] { 1, 0, 0, 0, 1, 0, 0, 1 };
            var actualResult = baseNumberConvertor.OrOperator(firestByte, secondByte);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrOperatorExceptionTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte = new byte[] { 0, 1, 1, 0, 0, 0, 1, 1, 0, 1 };
            var result = baseNumberConvertor.OrOperator(firestByte, secondByte);
        }

        [TestMethod]
        public void NotOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number =        new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 0, 1, 0, 1, 0, 1, 0, 0 };
            var actualResult = baseNumberConvertor.Not(number);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void XorOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte =    new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte =    new byte[] { 1, 0, 0, 0, 1, 1, 0, 1 };
            var correctResult = new byte[] { 1, 1, 0, 1, 1, 0, 0, 1 };
            var actualResult = baseNumberConvertor.XorOperator(firestByte, secondByte);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void XorOperatorExceptionTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte = new byte[] { 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1 };
            var actualResult = baseNumberConvertor.XorOperator(firestByte, secondByte);
        }

        [TestMethod]
        public void RightHandShiftTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 1, 1, 0, 1, 0, 1, 0, 1 };
            var actualResult = baseNumberConvertor.RightHandShift(number,1);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void LeftHandShiftTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number =        new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 0, 1, 0, 1, 0, 1, 1, 1 };
            var actualResult = baseNumberConvertor.LeftHandShift(number, 1);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }
    }
}

