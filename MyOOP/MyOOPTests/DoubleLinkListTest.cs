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
        public void AddFirstItemInEmptyDoubleLinkList()
        {
            var doubleLinkList=new DoubleLinkList<int>();
            doubleLinkList.Add(1);
            doubleLinkList.ShouldContain(1);
        }
        
        [TestMethod]
        public void AddFirstTwoItemInDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(1);
            doubleLinkList.Add(2);
            CollectionAssert.AreEqual(new[] {1, 2 }, doubleLinkList);
            doubleLinkList.ShouldContain(1);
            doubleLinkList.ShouldContain(2);
        }

        [TestMethod]
        public void AddFirstMoreItemInDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(1);
            doubleLinkList.Add(2);
            doubleLinkList.Add(3);

            CollectionAssert.AreEqual(new[] {1,2,3},doubleLinkList);
            doubleLinkList.ShouldContain(1);
            doubleLinkList.ShouldContain(2);
            doubleLinkList.ShouldContain(3);
        }

        [TestMethod]
        public void AddLastItemInEmptyDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();
                     
            doubleLinkList.AddLast(5);

            CollectionAssert.AreEqual(new[] { 5 }, doubleLinkList);          
            doubleLinkList.ShouldContain(5);
        }

        [TestMethod]
        public void AddTwoItemInDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.AddLast(5);
            doubleLinkList.AddLast(3);

            CollectionAssert.AreEqual(new[] { 3, 5 }, doubleLinkList);
            doubleLinkList.ShouldContain(5);
        }

        [TestMethod]
        public void AddLastItemInDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();

            doubleLinkList.Add(5);
            doubleLinkList.Add(2);
            doubleLinkList.Add(1);
            doubleLinkList.AddLast(3);

            CollectionAssert.AreEqual(new[] { 3,5,2, 1 }, doubleLinkList);
            doubleLinkList.ShouldContain(5);
        }




    }
}
