using System;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySortingAndSearchingAlgorithms;

namespace MySortingAndSearching.Tests
{
    [TestClass]
    public class SortingAndSearchingAlgorithmsTests
    {
        [TestMethod]
        public void QuickSortAscedingTest()
        {
            var expectedResult = new char[] {'a', 'b','c', 'd','e','f','m'};
            var text = new char[] { 'd', 'a', 'b','c', 'f', 'm', 'e' };
            SortingAndSearchingAlgorithms.QuickSortForOrderAscendingText(text, 0, text.Length-1);
            CollectionAssert.AreEqual(text,expectedResult);
        }
        [TestMethod]
        public void QuickSortDescendingTest()
        {
            var expectedResult = "mfedcba";
            var text = new char[] { 'd', 'a', 'b', 'c', 'f', 'm', 'e' };
            var actualResult = SortingAndSearchingAlgorithms.GetDescendingText(text, 0, text.Length - 1);
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void BubbleSortAscedingTest()
        {
            var expectedResult = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'm' };
            var text = new char[] { 'a', 'b', 'd', 'c', 'e', 'm', 'f' };
            var actualResult = SortingAndSearchingAlgorithms.BubbleSort(text);
            CollectionAssert.AreEqual(actualResult, expectedResult);
        }

        //[TestMethod]
        //public void QuickSortThreeWayPartitionTest()
        //{
        //    var expectedResult = new string[] { "medium", "medium", "high", "low", "high", "low", "medium" };
        //    var text = new string[] { "high","high","medium","medium","medium", "low","low"};
        //    var actualResult = SortingAndSearchingAlgorithms.QuickSortThreeWayPartition(text);
        //    CollectionAssert.AreEqual(actualResult, expectedResult);
        //}

        [TestMethod]
        public void LessStringTest()
        {           
            var actualResult = SortingAndSearchingAlgorithms.Less("maria","mariaa");
            Assert.AreEqual(actualResult, true);
        }

    }
}
