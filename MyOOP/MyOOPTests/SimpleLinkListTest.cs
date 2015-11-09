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
                simpleLinkList.AddLast(j);
            }

            Assert.AreEqual(4,simpleLinkList.GetCount());
        }

        [TestMethod]
        public void SimpleRemoveListLinkTest()
        {

            var simpleLinkList = new SimpleLinkList<int>();

            for (int j = 0; j < 4; j++)
            {
                simpleLinkList.AddLast(j);
            }
            var n = new SimpleLinkList<int>.Node<int>();
            n.next = null;
            n.value = 2;
            simpleLinkList.Delete(1);
            Assert.AreEqual(3, simpleLinkList.GetCount());
        }
    }
}
