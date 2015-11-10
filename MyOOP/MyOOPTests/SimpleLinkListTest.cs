using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyOOP;

namespace MyOOPTests
{
    [TestClass]
    public class SimpleLinkListTest
    {
        [TestMethod]
        public void SimpleAddTest()
        {

            var simpleLinkList = new SimpleLinkList<int>();
           
            for (int j = 0; j < 4; j++)
            {
                simpleLinkList.Add(j);
            }

            Assert.AreEqual(4,simpleLinkList.GetCount());
        }

        [TestMethod]
        public void SimpleRemoveListLinkTest()
        {   
            var simpleLinkList = new SimpleLinkList<int>();

            for (int j = 0; j < 4; j++)
            {
                simpleLinkList.Add(j);
            }       
            simpleLinkList.Delete(2);
            Assert.AreEqual(3, simpleLinkList.GetCount());
        }

        [TestMethod]
        public void SimpleRemoveFirstElementFromListLinkTest()
        {            
            var simpleLinkList = new SimpleLinkList<int>();

            for (int j = 1; j < 5; j++)
            {
                simpleLinkList.Add(j);
            }
            simpleLinkList.Delete(1);
            Assert.AreEqual(3, simpleLinkList.GetCount());
        }

        [TestMethod]
        public void SimpleUpdateListLinkTest()
        {
            var ni = 3;
            var simpleLinkList = new SimpleLinkList<int>();

            for (int j = 0; j < 4; j++)
            {
                simpleLinkList.Add(j);
            }
            simpleLinkList.Update(2,5);
            Assert.AreEqual(4, simpleLinkList.GetCount());
        }

        [TestMethod]
        public void SimpleInsertListLinkTest()
        {
            var ni = 3;
            var simpleLinkList = new SimpleLinkList<int>();

            for (int j = 0; j < 4; j++)
            {
                simpleLinkList.Add(j);
            }
            simpleLinkList.Insert(2, 5);
            Assert.AreEqual(5, simpleLinkList.GetCount());
        }
    }
}
