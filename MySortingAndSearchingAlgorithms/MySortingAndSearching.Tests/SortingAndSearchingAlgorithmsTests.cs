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
        public void QuickSort3WayTest()
        {
            var text = new char[] { 'a', 'c', 'b', 'c', 'a'};
            var expectedResult = new char[] { 'a', 'a', 'b', 'c', 'c'};
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, expectedResult.Length-1);
            CollectionAssert.AreEqual(text, expectedResult);
        }
        [TestMethod]
        public void LessStringTest()
        {           
            var actualResult = SortingAndSearchingAlgorithms.Less("maria","mariaa");
            Assert.AreEqual(actualResult, true);
        }

        [TestMethod]
        public void MultilplySwapTest()
        {
            var text = new char[] { 'a', 'a', 'd', 'e', 'c', 'g', 'b' };
            var expectedResult = new char[] { 'a', 'a', 'c', 'g', 'd', 'e', 'b' };
            SortingAndSearchingAlgorithms.Swap(text, 2, 3, 4, 5);
            CollectionAssert.AreEqual(text, expectedResult);
        }

        [TestMethod]
        public void Multilply3SwapTest()
        {
            var text = new char[] { 'a', 'a', 'd', 'e', 'c', 'g', 'b','h' };
            var expectedResult = new char[] { 'a', 'a', 'g', 'b', 'h', 'd', 'e','c' };
            SortingAndSearchingAlgorithms.Swap(text, 2, 4, 5, 7);
            CollectionAssert.AreEqual(text, expectedResult);
        }

    }
}
