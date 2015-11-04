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
        public void AddIntElementInObjectArrayWithLength9()
        {
            var intArray = new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var newElement = 10;
            var expectedResult = new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, null, null, null, null, null, null};
            var array = new ArrayClass(intArray);
            var newArray = array.Add(newElement);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }
        [TestMethod]
        public void AddIntElementInObjectArrayWithLength17()
        {
            var intArray = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,10,11,12,13,14,15,16,17 };
            var newElement = 18;
            var expectedResult = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,null,null,null,null, null, null, null, null, null, null,null,null,null,null };
            var array = new ArrayClass(intArray);
            var newArray = array.Add(newElement);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }
        [TestMethod]
        public void InsertIntElementInObjectArray()
        {
            var intArray = new object[] { 1, 2, 3 };
            var newElement = 1;
            var expectedResult = new object[] { 1, 2, 1, 3, null, null, null, null };
            var array = new ArrayClass(intArray);
            var newArray = array.Insert(newElement,2);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }
        [TestMethod]
        public void InsertIntElementInObjectArrayWithLength8()
        {
            var intArray = new object[] {1, 2, 3, 4, 5, 6, 7, 8};
            var newElement = 1;
            var expectedResult = new object[] {1, 2, 1, 3, 4, 5, 6, 7, 8, null, null, null, null, null, null, null};
            var array = new ArrayClass(intArray);
            var newArray = array.Insert(newElement, 2);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }

        [TestMethod]
        public void RemoveIntElementInObjectArray()
        {
            var intArray = new object[] { 1, 2, 3, 4, 5, 6, 7 };
            object elementToRemove = 1;
            var expectedResult = new object[] { 2, 3, 4, 5, 6, 7, null };
            var array = new ArrayClass(intArray);
            var newArray = array.Remove(elementToRemove);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }

        [TestMethod]
        public void RemoveElementFromIndexInObjectArray()
        {
            var intArray = new object[] { 7, 6, 5, 4, 3, 2, 1 };
            int elementToRemove = 2;
            var expectedResult = new object[] {7, 6, 4, 3, 2, 1, null};
            var array = new ArrayClass(intArray);
            var newArray = array.Remove(elementToRemove);

            CollectionAssert.AreEqual(expectedResult, newArray);
        }



    }
}
