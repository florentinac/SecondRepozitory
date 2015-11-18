using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;
using Should;

namespace MyOOPTests
{
    [TestClass]
    public class DoubleLinkListTest
    {
        [TestMethod]
        public void EmptyDoubleLinkList()
        {
            var doubleLinkList=new DoubleLinkList<int>();
            doubleLinkList.ShouldBeEmpty();
        }

        [TestMethod]
        public void AddItemInEmptyDoubleLinkList()
        {
            var doubleLinkList=new DoubleLinkList<int>();
            doubleLinkList.Add(1);
            doubleLinkList.ShouldContain(1);
        }
        
        [TestMethod]
        public void AddTwoItemInDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(1);
            doubleLinkList.Add(2);
            CollectionAssert.AreEqual(new[] {2, 1}, doubleLinkList);          
        }

        [TestMethod]
        public void AddThreeItemInDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(1);
            doubleLinkList.Add(2);
            doubleLinkList.Add(3);

            CollectionAssert.AreEqual(new[] {3,2,1},doubleLinkList);
            doubleLinkList.ShouldContain(1);
            doubleLinkList.ShouldContain(2);
            doubleLinkList.ShouldContain(3);
        }

        [TestMethod]
        public void InsertItemInEmptyDoubleLinkListBeforeTheReferanceElement()
        {
            var doubleLinkList = new DoubleLinkList<int?>();
                     
            doubleLinkList.InsertBefore(null,5);

            CollectionAssert.AreEqual(new[] { 5 }, doubleLinkList);          
            doubleLinkList.ShouldContain(5);
        }

        [TestMethod]
        public void InsertItemInDoubleLinkListBeforeTheReferanceElement()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.InsertBefore(5, 3);

            CollectionAssert.AreEqual(new[] { 3, 5 }, doubleLinkList);
            doubleLinkList.ShouldContain(5);
        }

        [TestMethod]
        public void InsertItemInAListWithThreeItemBeforeTheReferanceElement()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.Add(2);
            doubleLinkList.Add(3);
            doubleLinkList.InsertBefore(5, 7);

            CollectionAssert.AreEqual(new[] { 3, 2,7,5 }, doubleLinkList);
            doubleLinkList.ShouldContain(5);
            doubleLinkList.Count.ShouldEqual(4);
        }

        [TestMethod]
        public void InsertItemInDoubleLinkListAfterTheReferanceElement()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.InsertAfter(5, 3);

            CollectionAssert.AreEqual(new[] { 5, 3 }, doubleLinkList);
            doubleLinkList.ShouldContain(5);
        }

        [TestMethod]
        public void ShouldHaveAReverseEnumerableForAListWithOneItem()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            var enumerable = doubleLinkList.GetReverseEnumerable();

            enumerable.ShouldContain(5);
        }

        [TestMethod]
        public void ShouldHaveAReverseEnumerableForAListWithTwoItem()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.Add(7);

            var enumerable = doubleLinkList.GetReverseEnumerable();

            enumerable.ShouldContain(7);
        }

        [TestMethod]
        public void DeleteItemFromAnEmptyList()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Remove(2).ShouldBeFalse();
            doubleLinkList.Count.ShouldEqual(0);
        }

        [TestMethod]
        public void DeleteItemFromAListWithOneItem()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.ShouldContain(5);
            doubleLinkList.Remove(5);
            doubleLinkList.ShouldNotContain(5);
        }

        [TestMethod]
        public void DeleteItemFromAListWithThreeItem()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.Add(2);
            doubleLinkList.Add(7);
            doubleLinkList.ShouldContain(2);
            doubleLinkList.Remove(2);
            doubleLinkList.ShouldNotContain(2);
        }

        [TestMethod]
        public void VerifyIfAListContainAnItem()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.Add(2);
            doubleLinkList.Add(7);
            doubleLinkList.Contains(2).ShouldBeTrue();
            doubleLinkList.Contains(7).ShouldBeTrue();
            doubleLinkList.Contains(8).ShouldBeFalse();
        }

        [TestMethod]
        public void VerifyCopyToInList()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(2);
            doubleLinkList.Add(3);
            doubleLinkList.Add(4);

            var array = new[] { 1, 2, 3, 0, 0, 0 };
            var expectedResult = new[] { 1, 2, 3, 4, 3, 2 };

            doubleLinkList.CopyTo(array, 3);
            CollectionAssert.AreEqual(expectedResult, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifyIndexOutOfRangeForCopyToArray()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(2);
            doubleLinkList.Add(3);          
            var array = new[] { 1, 2, 0 };

            doubleLinkList.CopyTo(array, 2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyArgumentNullExceptionForCopyToArray()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(2);
            doubleLinkList.Add(3);
            int[] array = null;

            doubleLinkList.CopyTo(array, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VerifyArgumentOutOfRangeExceptionForCopyToArray()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(2);
            doubleLinkList.Add(3);
            var array = new[] { 1, 2, 0 };

            doubleLinkList.CopyTo(array, -1);
        }


    }
}
