﻿using System;
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

            doubleLinkList.ShouldContain(1);
            doubleLinkList.ShouldContain(2);
            doubleLinkList.ShouldContain(3);
        }

        [TestMethod]
        public void AddLastItemInEmptyDoubleLinkList()
        {
            var doubleLinkList = new DoubleLinkList<int>();
            doubleLinkList.Add(2);
            doubleLinkList.AddLast(1);
            doubleLinkList.ShouldContain(1);
            doubleLinkList.ShouldContain(2);
        }

    }
}
