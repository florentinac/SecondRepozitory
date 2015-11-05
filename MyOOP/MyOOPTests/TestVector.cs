using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;

namespace MyOOPTests
{
    [TestClass]
    public class TestVector
    {
        [TestMethod]
        public void AddOneIntElementInObjectArray()
        {
            var data = new object[8];
            var newElement = 1;
            var expectedResult = new object[] { 1, null, null, null, null, null, null, null };

            var array = new ArrayClass();
            array.Add2(newElement);
            var count = array.GetCount();

            CollectionAssert.AreEqual(expectedResult, data);
            Assert.AreEqual(1, count);
        }
        [TestMethod]
        public void AddEightIntElementInObjectArray()
        {
            var expectedData = new object[]
            {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, null, null, null, null, null};
            var array = new ArrayClass();

            for (var i = 1; i <= 11; i++)
            {
                array.Add2(i);
            }
            var count = array.GetCount();
            var data = array.GetData();
            CollectionAssert.AreEqual(expectedData, data);
            Assert.AreEqual(11, count);


        }
        [TestMethod]
        public void AddIntElementInObjectArray()
        {
            var data = new object[] { 1, 2, 3, null, null, null, null, null };
            var newElement = 1;

            var array = new ArrayClass(data, 3);
            array.Add2(newElement);
            var count = array.GetCount();

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void AddStringElementInObjectArray()
        {
            var data = new object[] { "ana", "are", "mere", null, null, null, null, null };
            var newElement = "pere";

            var array = new ArrayClass(data, 3);
            array.Add2(newElement);
            var count = array.GetCount();

            Assert.AreEqual(4, count);

        }
        [TestMethod]
        public void AddIntElementInObjectArrayWithLength17()
        {
            var data = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            var newElement = 17;

            var array = new ArrayClass(data, 16);
            array.Add2(newElement);
            var count = array.GetCount();

            Assert.AreEqual(17, count);

        }
        [TestMethod]
        public void InsertIntElementInObjectArray()
        {
            var intArray = new object[] { 1, 2, 3, null, null, null, null, null };
            var newElement = 1;

            var array = new ArrayClass(intArray, 3);
            array.Insert(newElement, 2);
            var count = array.GetCount();

            Assert.AreEqual(4, count);
        }
        [TestMethod]
        public void InsertIntElementInObjectArrayWithLength8()
        {
            var data = new object[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var newElement = 1;
            var expectedResult = new object[] { 1, 2, 1, 3, 4, 5, 6, 7, 8, null, null, null, null, null, null, null };

            var array = new ArrayClass(data, 8);
            array.Insert(newElement, 2);
            var count = array.GetCount();
            data = array.GetData();

            Assert.AreEqual(9, count);
            CollectionAssert.AreEqual(expectedResult, data);
        }

        [TestMethod]
        public void RemoveIntElementInObjectArray()
        {
            var data = new object[] { 1, 2, 3, 4, 5, 6, null };
            object elementToRemove = 1;
            var expectedResult = new object[] { 2, 3, 4, 5, 6, null, null };
            var array = new ArrayClass(data, 6);
            array.Remove(elementToRemove);
            data = array.GetData();
            var count = array.GetCount();

            Assert.AreEqual(5, count);
            CollectionAssert.AreEqual(expectedResult, data);
        }

        [TestMethod]
        public void RemoveElementFromIndexInObjectArray()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };
            int elementToRemove = 2;
            var expectedResult = new object[] { 7, 6, 4, 3, 2, 1, null };

            var array = new ArrayClass(data, 7);
            array.Remove(elementToRemove);
            data = array.GetData();
            var count = array.GetCount();

            Assert.AreEqual(6, count);
            CollectionAssert.AreEqual(expectedResult, data);
        }

        [TestMethod]
        public void TestGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };
            var expectedResult = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var i = 0;
            foreach (ArrayClass a in array)
                data[i++] = a;
            CollectionAssert.AreEqual(expectedResult,data );

        }


    }

}