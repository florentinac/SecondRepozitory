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

        [TestMethod]
        public void PriorityTest()
        {
            var expectedResult = new int[] {2, 2, 1, 1, 1, 0, 0};
            var priority = new string[] { "High", "High", "Medium", "Medium", "Medium", "Low", "Low" };
            var actualResult = SortingAndSearchingAlgorithms.GetPriorities(priority);
            CollectionAssert.AreEqual(actualResult, expectedResult);
        }
        [TestMethod]
        public void QuickSort3WayTest()
        {
            var text = new char[] { 'p', 'a', 'd', 'y', 'w','p','p','v','p','a','p','c','z','q'};
            var expectedResult = new char[] { 'a', 'a', 'c', 'd', 'p','p','p','p','p','q','v','w','y','z'};
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length-1);
            CollectionAssert.AreEqual(text, expectedResult);
        }

        [TestMethod]
        public void QuickSort3WayDifferentInputTest()
        {
            var text = new char[] { 'p', 'a', 'b', 'x', 'w', 'p', 'p', 'v', 'p', 'd', 'p', 'c', 'y', 'z' };
            var expectedResult = new char[] { 'a', 'b', 'c', 'd', 'p', 'p', 'p', 'p', 'p', 'v', 'x', 'y', 'w', 'z' };
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length - 1);
            CollectionAssert.AreEqual(text, expectedResult);
        }

        [TestMethod]
        public void QuickSort3WaySmallInputTest()
        {
            var text = new char[] { 'p', 'x', 'a', 'a'};
            var expectedResult = new char[] { 'a', 'a', 'p', 'x' };
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length - 1);
            CollectionAssert.AreEqual(text, expectedResult);
        }

        [TestMethod]
        public void QuickSort3WayTwoCharInputTest()
        {
            var text = new char[] { 'x','p' };
            var expectedResult = new char[] {'p', 'x' };
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length - 1);
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

        [TestMethod]
        public void InsertionSortForLotoNumberTest()
        {
            var number = new int[] {5, 2, 4, 3, 7, 6};
            var expectedResult = new int[] {2, 3, 4, 5, 6, 7};
            SortingAndSearchingAlgorithms.InsertionSort(number);
            CollectionAssert.AreEqual(number, expectedResult);
        }



    }
}
