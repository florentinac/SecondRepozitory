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
            var number = baseNumberConvertor.ConvertToBase(11, 2);
            var correctResult = new byte[] {0,0,0,0,1,0,1,1};
            CollectionAssert.AreEqual(correctResult,number);
            //Assert.AreEqual(number, correctResult);
        }

        [TestMethod]
        public void NumberConvertorFromBaseTest()
        {
            var baseNumberConvertor = new BaseNumberConvertor();
            var number = baseNumberConvertor.ConvertFromBase("110", 2);
            Assert.AreEqual(number, 6);
        }
    }
}
