using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;

namespace MyOOPTests
{
    [TestClass]
    public class TestVector
    {
        [TestMethod]
        public void AddIntElementInObjectArray()
        {
            var intArray = new object[] { 1, 2, 3 };
            var newElement = 1;
            var expectedResult = new object[] {1, 2, 3, 1, null, null, null, null};
            var array = new ArrayClass(intArray);
            var newArray = array.Add(newElement);

            CollectionAssert.AreEqual(expectedResult,newArray);
        }

        [TestMethod]
        public void AddStringElementInObjectArray()
        {
            var intArray = new object[] { "ana", "are", "mere" };
            var newElement = "pere";
            var expectedResult = new object[] { "ana", "are", "mere", "pere", null, null, null, null };
            var array = new ArrayClass(intArray);
            var newArray = array.Add(newElement);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }

        [TestMethod]
        public void AddIntElementInObjectArrayWithLenght9()
        {
            var intArray = new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var newElement = 10;
            var expectedResult = new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, null, null, null, null, null, null};
            var array = new ArrayClass(intArray);
            var newArray = array.Add(newElement);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }
        [TestMethod]
        public void AddIntElementInObjectArrayWithLenght17()
        {
            var intArray = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,10,11,12,13,14,15,16,17 };
            var newElement = 18;
            var expectedResult = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,null,null,null,null, null, null, null, null, null, null,null,null,null,null };
            var array = new ArrayClass(intArray);
            var newArray = array.Add(newElement);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }
    }
}
