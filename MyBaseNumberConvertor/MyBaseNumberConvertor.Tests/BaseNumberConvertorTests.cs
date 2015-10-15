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
            var correctResult = new byte[] { 0, 0, 1, 0, 1, 0, 1, 0, 1, 1 };
            byte[] newArray = baseNumberConvertor.ResizeArrayAndShiftRight(oldArray,2);
            CollectionAssert.AreEqual(correctResult,newArray);
             
        }

        [TestMethod]
        public void AddToArrayTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var oldArray =      new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] {1, 1, 0, 1, 0, 1, 0, 1, 1 }; 
            byte[] newArray = baseNumberConvertor.AddToArray(ref oldArray, 1);
            CollectionAssert.AreEqual(correctResult, newArray);

        }

        [TestMethod]
        public void ReverseArrayTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var oldArray =      new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 1, 1, 0, 1, 0, 1, 0, 1};
            byte[] newArray = baseNumberConvertor.ReverseArray(oldArray);
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
            var number = baseNumberConvertor.ConvertToBase(6, 2);
            var correctResult = new byte[] { 1, 1, 0 };
            CollectionAssert.AreEqual(correctResult, number);
        }

        [TestMethod]
        public void NumberConvertorFromBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var numberdigit = new byte[] { 1,1};
            var number = baseNumberConvertor.ConvertFromBase(numberdigit, 2);
            Assert.AreEqual(number, 3);
        }

        [TestMethod]
        public void OrOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte =    new byte[] { 1, 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte =       new byte[] { 1, 0, 0, 0, 1, 1, 0, 1 };
            var correctResult = new byte[] { 1, 1, 0, 1, 0, 1, 1, 1, 1 };
            var actualResult = baseNumberConvertor.OrOperator(firestByte, secondByte);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void AndOperatorTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firestByte =       new byte[] { 1, 0, 1, 0, 1, 0, 1, 1};
            var secondByte =    new byte[] { 1, 0, 0, 0, 1, 1, 0, 1, 1};
            var correctResult = new byte[] { 0, 0, 0, 0, 0, 1, 0, 1, 1};
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
            var firestByte =       new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte =    new byte[] { 1, 1, 0, 0, 0, 1, 1, 0, 1 };
            var correctResult = new byte[] { 0, 1, 1, 0, 1, 1, 0, 0, 1 };
            var actualResult = baseNumberConvertor.XorOperator(firestByte, secondByte);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }


        [TestMethod]
        public void RightHandShiftTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number =        new byte[] {1, 0, 1, 0, 1, 0, 1, 1};
            var correctResult = new byte[] {0, 0, 0, 1, 0, 1, 0, 1};
            var actualResult = baseNumberConvertor.RightHandShift(number,3);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }      

        [TestMethod]
        public void LeftHandShitByOneTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number =        new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 0, 1, 0, 1, 0, 1, 1, 0 };
            var actualResult = baseNumberConvertor.LeftHandShift(number,1);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }
        
        [TestMethod]
        public void LeftHandShiftTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number = new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var correctResult = new byte[] { 1, 0, 1, 0, 1, 1, 0, 0 };
            var actualResult = baseNumberConvertor.LeftHandShift(number, 2);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void FirstBytesLessThanSecondBytesTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstByte =  new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondByte = new byte[] { 1, 0, 1, 0, 1, 1, 0, 1 };
            var firstlassthansecond = baseNumberConvertor.LessThanBytes(firstByte, secondByte);
            Assert.AreEqual(firstlassthansecond, true);
        }

        [TestMethod]
        public void FirstBytesGradThanSecondBytesTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstByte =  new byte[] { 1, 0, 1, 0, 1, 1, 1, 1 };
            var secondByte = new byte[] { 1, 0, 1, 0, 1, 1, 0, 1 };
            var secondlassthanfirst = baseNumberConvertor.LessThanBytes(secondByte, firstByte);
            Assert.AreEqual(secondlassthanfirst, true);
        }

        [TestMethod]
        public void EgualBytesTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstByte =  new byte[] { 1, 0, 1, 0, 1, 1, 1, 1 };
            var secondByte = new byte[] { 1, 0, 1, 0, 1, 1, 1, 1 };
            var firstlassthansecond = baseNumberConvertor.LessThanBytes(firstByte, secondByte);
            var secondlassthanfirst = baseNumberConvertor.LessThanBytes(secondByte, firstByte);
            Assert.AreEqual(firstlassthansecond,false);
            Assert.AreEqual(secondlassthanfirst, false);
        }

        [TestMethod]
        public void AddArrayOfBytesInBinaryTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes =       new byte[] { 1, 0, 1, 0, 1, 0, 1, 1 };
            var secondBytes =      new byte[] { 1, 0, 1, 0, 1, 1, 0, 1 };
            var correctResult = new byte[] { 1, 0, 1, 0, 1, 1, 0, 0, 0 };
            var actualResult = baseNumberConvertor.AdditionBaseBytesArray(firstBytes,secondBytes,2);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void AddArrayOfBytesInBaseOctalBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes =    new byte[] {3, 7, 2, 1};
            var secondBytes =   new byte[] {1, 3, 6, 4};
            var correctResult = new byte[] {5, 3, 0, 5};
            var actualResult = baseNumberConvertor.AdditionBaseBytesArray(firstBytes, secondBytes, 8);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void DeductArrayOfByteInOctalBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes =    new byte[] {4, 5, 3};
            var secondBytes =   new byte[] {2, 6, 5};
            var correctResult = new byte[] {1, 6, 6}; 
            var actualResult = baseNumberConvertor.DeductBaseByteArray(firstBytes, secondBytes, 8);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }      

        [TestMethod]
        public void DeductBinaryWehnTheLegthOfArrayIsDifferentTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes = new byte[] {1, 1, 0};
            var secondBytes = new byte[] {1, 1};
            var correctResult = new byte[] {0, 1, 1};
            var actualResult = baseNumberConvertor.DeductBaseNumber(firstBytes, secondBytes, 2);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void DeductArrayOfByteInBinaryTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes =    new byte[] {1, 0, 1, 1, 1, 1, 0, 1};
            var secondBytes =   new byte[] {1, 0, 0, 0, 0, 0, 1, 1};
            var correctResult = new byte[] {0, 0, 1, 1, 1, 0, 1, 0}; 
            var actualResult = baseNumberConvertor.DeductBaseNumber(firstBytes, secondBytes, 2);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void MultiplyArrayOfBytesInOctalBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes =    new byte[] { 2, 3, 7};
            var secondBytes =      new byte[] { 6, 4};
            var correctResult = new byte[] {2, 0, 1, 1, 4}; 
            var actualResult = baseNumberConvertor.MultiplyBaseBytesArray(firstBytes, secondBytes, 8);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }
        [TestMethod]
        public void MultiplyArrayOfBytesInBinaryBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes = new byte[] {1, 0, 0, 0, 0};
            var secondBytes = new byte[] {1, 1, 1};
            var correctResult = new byte[] { 1, 1, 1, 0, 0, 0, 0 };
            var actualResult = baseNumberConvertor.MultiplyBaseBytesArray(firstBytes, secondBytes, 2);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void DivisionArrayOfByteInBinaryTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes = new byte[] {1, 1, 1, 0, 0, 1, 1};
            var secondBytes = new byte[] {1, 1, 1};
            var correctResult = new byte[] {1, 0, 0, 0, 0}; 
            var actualResult = baseNumberConvertor.DivisionBaseBytesArray(ref firstBytes, secondBytes, 2);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }

        [TestMethod]
        public void DivisionArrayOfByteInOctalBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var firstBytes = new byte[] { 2, 3, 7 };
            var secondBytes = new byte[] { 2, 5 };
            var correctResult = new byte[] { 7 };
            var actualResult = baseNumberConvertor.DivisionBaseBytesArray(ref firstBytes, secondBytes, 8);
            CollectionAssert.AreEqual(actualResult, correctResult);
        }
    }
}

