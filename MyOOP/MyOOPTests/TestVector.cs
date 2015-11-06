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
            var data = new object[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            var newElement = 17;

            var array = new ArrayClass(data, 16);
            array.Add2(newElement);
            var count = array.GetCount();

            Assert.AreEqual(17, count);
        }

        [TestMethod]
        public void ShiftLeftElement()
        {
            var data = new object[] { 1, 2, 3, 4, null,null,null,null };
            var array = new ArrayClass(data, 4);
            array.ShiftRight(1);
            var actualResult = array.GetData(2);          
            Assert.AreEqual(2, actualResult);
        }
        [TestMethod]
        public void ShiftLeft0Element()
        {
            var data = new object[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var array = new ArrayClass(data, 8);
            array.ShiftRight(1);
            var actualResult = array.GetData(2);
            Assert.AreEqual(3, actualResult);
        }

        [TestMethod]
        public void InsertIntElementInObjectArray()
        {
            var intArray = new object[] { 1, 2, 3, null, null, null, null, null };
            var newElement = 1;

            var array = new ArrayClass(intArray, 3);
            array.Insert(newElement, 2);
            var count = array.GetCount();
            var data = array.GetData(2);

            Assert.AreEqual(4, count);
            Assert.AreEqual(1,data);

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

        public void InsertIntElementInObjectArrayWithElementOfIndexNull()
        {
            var intArray = new object[] { 1, 2, 3, null, null, null, null, null };
            var newElement = 5;

            var array = new ArrayClass(intArray, 3);
            array.Insert(newElement, 4);
            var count = array.GetCount();

            Assert.AreEqual(4, count);
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
        public void InsertStringElementInObjectArrayWithLength8()
        {
            var data = new object[] { "a", "b", "d", "c", "f", 6, 7, 8 };
            var newElement = "m";

            var array = new ArrayClass(data, 8);
            array.Insert(newElement, 2);
            var count = array.GetCount();

            Assert.AreEqual(9, count);
        }        

        [TestMethod]
        public void InsertOneElementInObjectArrayWithDefaltConstructor()
        {
            var newElement = "m";

            var array = new ArrayClass();
            var count = array.GetCount();
            array.Insert(newElement, count);
            count = array.GetCount();            
     
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void InsertTwoElementInObjectArrayWithDefaltConstructor()
        {
          
            var array = new ArrayClass();
            var count = array.GetCount();
            array.Insert("m", count);
            count = array.GetCount();
            Assert.AreEqual(1, count);

            array.Insert("c", count);
            count = array.GetCount();

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetElementAtPosition()
        {
            var data = new object[] { "a", "b", "d", "c", "f", 6, 7, 8 };
            var array = new ArrayClass(data, 8);

            Assert.AreEqual("d", array.GetElemenetAt(2));
        }

        [TestMethod]
        public void GetElementAtInvalidPosition()
        {
            var data = new object[] { "a", "b", "d", "c", "f", 6, 7, 8 };
            var array = new ArrayClass(data, 8);

            Assert.AreEqual(null, array.GetElemenetAt(10));
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
        public void RemoveNullElementInObjectArray()
        {
            var data = new object[] { 1, 2, 3, 4, 5, 6, null };         

            var array = new ArrayClass(data, 6);
            array.Remove(null);
            var count = array.GetCount();

            Assert.AreEqual(6, count);
        }


        [TestMethod]
        public void RemoveMoreIntElementInObjectArray()
        {
            var data = new object[] { 1, 2, 1, 4, 5, 6, null };
            object elementToRemove = 1;

            var array = new ArrayClass(data, 6);
            array.Remove(elementToRemove);
            array.Remove(elementToRemove);
            var count = array.GetCount();

            Assert.AreEqual(4, count);
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
                       
            Assert.AreEqual(true,enumerator.MoveNext());           
        }

        [TestMethod]
        public void TestCurrentElementFromGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var enumerator = array.GetEnumerator();

            Assert.AreEqual(true, enumerator.MoveNext());
            Assert.AreEqual(7, enumerator.Current);
        }

        [TestMethod]
        public void TestCurrentElementWhenForMoveNext5FromGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var enumerator = array.GetEnumerator();
            for (var i = 0; i < 4; i++)
                enumerator.MoveNext();

            Assert.AreEqual(true, enumerator.MoveNext());
            Assert.AreEqual(3, enumerator.Current);
        }

        [TestMethod]
        public void TestMoveNextLimitFromGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var enumerator = array.GetEnumerator();         

            for (var i = 0; i < 7; i++)
                Assert.AreEqual(true,enumerator.MoveNext());
            Assert.AreEqual(false, enumerator.MoveNext());
            Assert.AreEqual(null, enumerator.Current);
        }

        [TestMethod]
        public void TestCurrentNullElementFromGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var enumerator = array.GetEnumerator();
               
            Assert.AreEqual(null, enumerator.Current);
        }

        [TestMethod]
        public void TestResetFromGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var enumerator = array.GetEnumerator();
            for (var i = 0; i < 4; i++)
                enumerator.MoveNext();         
              
            Assert.AreEqual(4, enumerator.Current);
            enumerator.Reset();
            Assert.AreEqual(null,enumerator.Current);
        }

        [TestMethod]
        public void TestLastCurrentElementFromGetEnumerator()
        {
            var data = new object[] { 7, 6, 5, 4, 3, 2, 1 };

            var array = new ArrayClass(data, 7);
            var enumerator = array.GetEnumerator();
            for (var i = 0; i < 7; i++)
                enumerator.MoveNext();
     
            Assert.AreEqual(1, enumerator.Current);
        }
        [TestMethod]
        public void TestGetEnumeratorWithDefaltConstructor()
        {
            var array = new ArrayClass();
            var enumerator = array.GetEnumerator();
           
            Assert.AreEqual(false,enumerator.MoveNext());
            Assert.AreEqual(null, enumerator.Current);
        }

    }

}