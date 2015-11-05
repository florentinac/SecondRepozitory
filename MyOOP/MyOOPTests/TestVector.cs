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
            var newElement = 1;         

            var array = new ArrayClass();
            array.Add2(newElement);
            var count = array.GetCount();
         
            Assert.AreEqual(1, count);
        }
        [TestMethod]
        public void AddEightIntElementInObjectArray()
        {        
            var array = new ArrayClass();

            for (var i = 1; i <= 11; i++)
            {
                array.Add2(i);
            }
            var count = array.GetCount();
            
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
        
        public void InsertIntElementInObjectArrayWithIndexOutOfRAnge()
        {
            var intArray = new object[] { 1, 2, 3, null, null, null, null, null };
            var newElement = 5;

            var array = new ArrayClass(intArray, 3);
            array.Insert(newElement, 10);
            var count = array.GetCount();

            Assert.AreEqual(3, count);
        }
        [TestMethod]
        public void InsertIntElementInObjectArrayWithLength8()
        {
            var data = new object[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var newElement = 1;
            
            var array = new ArrayClass(data, 8);
            array.Insert(newElement, 2);
            var count = array.GetCount();
           
            Assert.AreEqual(9, count);          
        }

        [TestMethod]
        public void RemoveIntElementInObjectArray()
        {
            var data = new object[] { 1, 2, 3, 4, 5, 6, null };
            object elementToRemove = 1;
 
            var array = new ArrayClass(data, 6);
            array.Remove(elementToRemove);          
            var count = array.GetCount();

            Assert.AreEqual(5, count);
           
        }
        [TestMethod]
        public void RemoveNonExistentElementInObjectArray()
        {
            var data = new object[] { 1, 2, 3, 4, 5, 6, null };
            object elementToRemove = 7;

            var array = new ArrayClass(data, 6);
            array.Remove(elementToRemove);
            var count = array.GetCount();

            Assert.AreEqual(6, count);

        }
        [TestMethod]
        public void RemoveElementFromIndexInObjectArray()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            array.Remove(6);
            var count = array.GetCount();

            Assert.AreEqual(6, count);
        }

        [TestMethod]
        public void RemoveElementFromOutOfBoundIndexInObjectArray()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };                

            var array = new ArrayClass(data, 7);
            array.Remove(8);
            var count = array.GetCount();

            Assert.AreEqual(7, count);            
        }

        [TestMethod]
        public void TestMoveNextGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var enumerator = array.GetEnumerator();
            enumerator.Reset();
                       
            Assert.AreEqual(true,enumerator.MoveNext());           
        }
        [TestMethod]
        public void TestCurrentElementFromGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var enumerator = array.GetEnumerator();
            enumerator.Reset();

            Assert.AreEqual(true, enumerator.MoveNext());
            Assert.AreEqual(7, enumerator.Current);
        }
    }

}