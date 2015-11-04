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
    }
}
