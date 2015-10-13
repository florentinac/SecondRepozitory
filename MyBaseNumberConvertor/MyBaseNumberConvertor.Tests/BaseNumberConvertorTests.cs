using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyBaseNumberConvertor.Tests
{
    [TestClass]
    public class BaseNumberConvertorTests
    {
        [TestMethod]
        public void RisezeArrayTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var oldArray =      new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1, 0 ,0 };
            byte[] newArray = baseNumberConvertor.ResizeArray(ref oldArray,2);
            CollectionAssert.AreEqual(correctResult,newArray);
             
        }

        [TestMethod]
        public void AddToArrayTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var oldArray = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1, 1 };
            byte[] newArray = baseNumberConvertor.AddToArray(ref oldArray, 1);
            CollectionAssert.AreEqual(correctResult, newArray);

        }

        [TestMethod]
        public void ReverseArrayTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var oldArray =      new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 1, 1, 0, 1, 0, 1, 0, 1};
            byte[] newArray = baseNumberConvertor.ReverseArray(ref oldArray);
            CollectionAssert.AreEqual(correctResult, newArray);

        }

        [TestMethod]
        public void OrBytesTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            byte newByte= baseNumberConvertor.Or(0,1);
            Assert.AreEqual(newByte, 1);

        }

        [TestMethod]
        public void NumberConvertorToBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number = baseNumberConvertor.ConvertToBase(100, 36);
            var correctResult = new byte[] { 2, 28 };
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
        public void OrOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte =    new byte[] { 1, 0, 1, 0, 1, 0, 1, 1,};
            var secondByte =    new byte[] { 1, 0, 0, 0, 1, 1, 0, 1 };
            var correctResult = new byte[] { 1, 0, 1, 0, 1, 1, 1, 1 };
            var actualResult = baseNumberConvertor.OrOperator(firestByte, secondByte);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void AndOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte =    new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte =    new byte[] { 1, 0, 0, 0, 1, 1, 0, 1, 1};
            var correctResult = new byte[] { 1, 0, 0, 0, 1, 0, 0, 1, 0};
            var actualResult = baseNumberConvertor.AndOperator(firestByte, secondByte);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void NotOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number =        new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 0, 1, 0, 1, 0, 1, 0, 0 };
            var actualResult = baseNumberConvertor.NotOnArray(number);
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
        public void RightHandShiftByOneTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] {1, 1, 0, 1, 0, 1, 0, 1};
            var actualResult = baseNumberConvertor.RightHandShiftByOne(number);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void RightHandShiftTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number =        new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 0, 1, 1, 1, 0, 1, 0, 1 };
            var actualResult = baseNumberConvertor.RightHandShift(number,3);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void LeftHandShiftByOneTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number =        new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 0, 1, 0, 1, 0, 1, 1, 1 };
            var actualResult = baseNumberConvertor.LeftHandShiftByOne(number);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }
        [TestMethod]
        public void LeftHandShiftTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number =        new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 1, 0, 1, 0, 1, 1, 1, 0 };
            var actualResult = baseNumberConvertor.LeftHandShift(number, 2);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void AddBinaryBytesTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondBytes = new byte[] { 1, 0, 1, 0, 1, 1, 0, 1 };
            var correctResult = new byte[] { 0, 1, 0, 1, 0, 0, 0, 0 };
            var actualResult = baseNumberConvertor.AddBinarNumber(firstBytes,secondBytes);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }
    }
}

