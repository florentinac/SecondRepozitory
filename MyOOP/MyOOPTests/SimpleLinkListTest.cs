﻿using System;
using Should;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;

namespace MyOOPTests
{
    [TestClass]
    public class SimpleLinkListTest
    {

        [TestMethod]
        public void EmptyList()
        {
            var simpleLinkList=new SimpleLinkList<int>();
            simpleLinkList.ShouldBeEmpty();
        }

        [TestMethod]
        public void AddOneElementInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
        
            simpleLinkList.ShouldContain(2);
        }

        [TestMethod]
        public void AddMoreElementInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);

            simpleLinkList.ShouldContain(2);
        }

        [TestMethod]
        public void VerifyCountInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);

            simpleLinkList.Count.ShouldEqual(3);
        }

        [TestMethod]
        public void AddLastElementsInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.AddLast(2);
            simpleLinkList.AddLast(3);
            simpleLinkList.AddLast(4);

            simpleLinkList.ShouldContain(2);
        }

        [TestMethod]
        public void VerifyRemoveANonExistentElementInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.ShouldContain(2);
            simpleLinkList.Remove(3);

            simpleLinkList.ShouldContain(2);
            simpleLinkList.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void VerifyRemoveFirstElementEndResutAnEmptyLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.ShouldContain(2);         
            simpleLinkList.Remove(2);

            simpleLinkList.ShouldBeEmpty();
        }

        [TestMethod]
        public void VerifyRemoveElementInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.Remove(3);

            simpleLinkList.ShouldNotContain(3);
        }

        [TestMethod]
        public void VerifyRemoveFirstElementInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.Remove(4);

            simpleLinkList.ShouldNotContain(4);
        }

        [TestMethod]
        public void VerifyCountWhenRemoveAnElementInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.Remove(4);
           
            simpleLinkList.Count.ShouldEqual(2);
        }

        [TestMethod]
        public void VerifyUpdateElementInEmptyLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
           
            simpleLinkList.Update(3, 5);

            simpleLinkList.ShouldNotContain(5);
        }

        [TestMethod]
        public void VerifyUpdateAnNonExistentElementInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);        
            simpleLinkList.Update(3, 5);
          
            simpleLinkList.ShouldNotContain(5);
        }

        [TestMethod]
        public void VerifyUpdateElementInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.Update(2,5);

            simpleLinkList.ShouldContain(5);
            simpleLinkList.ShouldNotContain(2);
        }

        [TestMethod]
        public void VerifyClearLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.Clear();

            simpleLinkList.ShouldBeEmpty();           
        }

        [TestMethod]
        public void VerifyContainsItemLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);

            simpleLinkList.Contains(2).ShouldBeTrue();           
        }

        [TestMethod]
        public void VerifyInsertRightInAnEmptyLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int?>();

            simpleLinkList.InsertAfter(null, 5);

            simpleLinkList.ShouldContain(5);
            simpleLinkList.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void VerifyInsertRightItemInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.InsertAfter(3,5);

            simpleLinkList.ShouldContain(5);
            simpleLinkList.Count.ShouldEqual(4);
        }

        [TestMethod]
        public void VerifyInsertRightLastItemInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.InsertAfter(2, 5);

            simpleLinkList.ShouldContain(5);
            simpleLinkList.Count.ShouldEqual(4);
        }

        [TestMethod]
        public void VerifyInsertDelegateBeforeItemInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            Insert<int> del = new Insert<int>(simpleLinkList.InsertItem);
            del(2, 5, true);

            CollectionAssert.AreEqual(new[] { 4, 3, 5, 2 }, simpleLinkList);
            
        }
        [TestMethod]
        public void VerifyInsertDelegateAfterItemInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int> {2, 3, 4};
            var del = new Insert<int>(simpleLinkList.InsertItem);
            del(2, 5, false);

            CollectionAssert.AreEqual(new[] {4, 3, 2, 5}, simpleLinkList);
           
        }

        [TestMethod]
        public void VerifyInsertLeftInAnEmptyLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int?>();
            
            simpleLinkList.InsertBefore(null, 5);

            simpleLinkList.ShouldContain(5);
            simpleLinkList.Count.ShouldEqual(1);
        }

        [TestMethod]
        public void VerifyInsertLeftFirstItemInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.InsertBefore(4, 5);

            simpleLinkList.ShouldContain(5);
            simpleLinkList.Count.ShouldEqual(4);
        }

        [TestMethod]
        public void VerifyInsertLeftItemInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);
            simpleLinkList.InsertBefore(3, 5);

            simpleLinkList.ShouldContain(5);
            simpleLinkList.Count.ShouldEqual(4);
        }

        [TestMethod]
        public void VerifyCopyToInLinkList()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            simpleLinkList.Add(4);

            var array = new[] {1, 2, 3, 0, 0, 0};
            var expectedResult = new[] {1, 2, 3, 4, 3, 2};

            simpleLinkList.CopyTo(array, 3);
            CollectionAssert.AreEqual(expectedResult,array);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void VerifyIndexOutOfRangeForCopyToArray()
        {
            var simpleLinkList=new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            var array = new[] { 1, 2, 0 };        

            simpleLinkList.CopyTo(array,2);
                     
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyArgumentNullExceptionForCopyToArray()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            int[] array = null;

            simpleLinkList.CopyTo(array, 2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyArgumentOutOfRangeExceptionForCopyToArray()
        {
            var simpleLinkList = new SimpleLinkList<int>();
            simpleLinkList.Add(2);
            simpleLinkList.Add(3);
            var array = new[] { 1, 2, 0 };

            simpleLinkList.CopyTo(array, -1);

        }

    }
}
