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
        public void InsertItemInEmptyDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int?>();
                     
            doubleLinkList.Insert(null,5);

            CollectionAssert.AreEqual(new[] { 5 }, doubleLinkList);          
            doubleLinkList.ShouldContain(5);
        }

        [TestMethod]
        public void InsertItemInDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.Insert(5, 3);

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

            doubleLinkList.Remove(2);
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
    }
}
