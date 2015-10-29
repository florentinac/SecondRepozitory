using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
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
            var expectedResult = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'm' };
            var text = new char[] { 'd', 'a', 'b', 'c', 'f', 'm', 'e' };
            SortingAndSearchingAlgorithms.QuickSortForOrderAscendingText(text, 0, text.Length - 1);
            CollectionAssert.AreEqual(text, expectedResult);
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
        public void QuickSort3WayTest()
        {
            var text = new char[] { 'p', 'd', 'a', 'z', 'w', 'p', 'p', 'v', 'p', 'd', 'p', 'd', 'q', 'x' };
            var expectedResult = new char[] { 'a', 'd', 'd', 'd', 'p', 'p', 'p', 'p', 'p', 'q', 'v', 'w', 'x', 'z' };
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length - 1);
            CollectionAssert.AreEqual(text, expectedResult);
        }
        [TestMethod]
        public void LessStringTest()
        {
            var actualResult = SortingAndSearchingAlgorithms.Less("maria", "mariaa");
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
            var text = new char[] { 'a', 'a', 'd', 'e', 'c', 'g', 'b', 'h' };
            var expectedResult = new char[] { 'a', 'a', 'g', 'b', 'h', 'd', 'e', 'c' };
            SortingAndSearchingAlgorithms.Swap(text, 2, 4, 5, 7);
            CollectionAssert.AreEqual(text, expectedResult);
        }
        [TestMethod]
        public void EnumTest()
        {

            var myPriority = new SortingAndSearchingAlgorithms.Priority[]
            {
                SortingAndSearchingAlgorithms.Priority.Low, SortingAndSearchingAlgorithms.Priority.Medium,
                SortingAndSearchingAlgorithms.Priority.Low, SortingAndSearchingAlgorithms.Priority.High,
                SortingAndSearchingAlgorithms.Priority.Low, SortingAndSearchingAlgorithms.Priority.High,
                SortingAndSearchingAlgorithms.Priority.Medium, SortingAndSearchingAlgorithms.Priority.High
            };
            var expectedResult = new SortingAndSearchingAlgorithms.Priority[]
            {
                SortingAndSearchingAlgorithms.Priority.Low, SortingAndSearchingAlgorithms.Priority.Low,
                SortingAndSearchingAlgorithms.Priority.Low, SortingAndSearchingAlgorithms.Priority.Medium,
                SortingAndSearchingAlgorithms.Priority.Medium, SortingAndSearchingAlgorithms.Priority.High,
                SortingAndSearchingAlgorithms.Priority.High, SortingAndSearchingAlgorithms.Priority.High
            };
            var actualResult = SortingAndSearchingAlgorithms.BubbleSortPriority(myPriority);


            CollectionAssert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void QuickSort3Way2Test()
        {
            var text = new char[] { 'p', 'a', 'd', 'y', 'w', 'p', 'p', 'v', 'p', 'a', 'p', 'c', 'z', 'q' };
            var expectedResult = new char[] { 'a', 'a', 'c', 'd', 'p', 'p', 'p', 'p', 'p', 'q', 'v', 'w', 'y', 'z' };
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length - 1);
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
            var text = new char[] { 'p', 'x', 'a', 'a' };
            var expectedResult = new char[] { 'a', 'a', 'p', 'x' };
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length - 1);
            CollectionAssert.AreEqual(text, expectedResult);
        }

        [TestMethod]
        public void QuickSort3WayTwoCharInputTest()
        {
            var text = new char[] { 'x', 'p' };
            var expectedResult = new char[] { 'p', 'x' };
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length - 1);
            CollectionAssert.AreEqual(text, expectedResult);
        }

        [TestMethod]
        public void InsertionSortForLotoNumberTest()
        {
            var number = new int[] { 5, 2, 4, 3, 7, 6 };
            var expectedResult = new int[] { 2, 3, 4, 5, 6, 7 };
            SortingAndSearchingAlgorithms.InsertionSort(number);
            CollectionAssert.AreEqual(number, expectedResult);
        }

        public SortingAndSearchingAlgorithms.Words[] SimpleWordsOrdonate = {
            new SortingAndSearchingAlgorithms.Words { Word="ion", NrApparition=3},
            new SortingAndSearchingAlgorithms.Words { Word="maria", NrApparition=2},
            new SortingAndSearchingAlgorithms.Words { Word="ana", NrApparition=1}
        };

        public SortingAndSearchingAlgorithms.Words[] WordsOrdonate = {
            new SortingAndSearchingAlgorithms.Words { Word="ion", NrApparition=3},
            new SortingAndSearchingAlgorithms.Words { Word="maria", NrApparition=2},
            new SortingAndSearchingAlgorithms.Words { Word="anb", NrApparition=1},
            new SortingAndSearchingAlgorithms.Words { Word="aca", NrApparition=1},
            new SortingAndSearchingAlgorithms.Words { Word="ana", NrApparition=1},

        };

        public SortingAndSearchingAlgorithms.Words[] WordsOrdonateAlfabetic = {
          new SortingAndSearchingAlgorithms.Words { Word="ion", NrApparition=3},
          new SortingAndSearchingAlgorithms.Words { Word="maria", NrApparition=2},
          new SortingAndSearchingAlgorithms.Words { Word="aca", NrApparition=1},
          new SortingAndSearchingAlgorithms.Words { Word="ana", NrApparition=1},
          new SortingAndSearchingAlgorithms.Words { Word="anb", NrApparition=1},
      };

        [TestMethod]
        public void SimpleOrderedWordsTest()
        {
            var inputText = new string[] { "ion", "maria", "ion", "maria", "ion", "ana" };
            var expectedResult = SimpleWordsOrdonate;
            var actualResult = SortingAndSearchingAlgorithms.GetDistinctWordsAndNumberOfWords(inputText);
            CollectionAssert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void OrderedWordsTest()
        {
            var inputText = new string[] { "ion", "maria", "ion", "maria", "ion", "aca", "anb", "ana" };
            var expectedResult = WordsOrdonateAlfabetic;
            var wordsOrdonate = SortingAndSearchingAlgorithms.GetOrderlyWords(inputText);
            CollectionAssert.AreEqual(wordsOrdonate, expectedResult);
        }

       

        public SortingAndSearchingAlgorithms.CandidateStation[] CentruPolling =
       {
            new SortingAndSearchingAlgorithms.CandidateStation {Station = "StationOne", CandidateName = "Iliescu", Votes = 235},
            new SortingAndSearchingAlgorithms.CandidateStation {Station = "StationOne", CandidateName = "Vasilescu", Votes = 235},
            new SortingAndSearchingAlgorithms.CandidateStation {Station = "StationOne", CandidateName = "Constantinescu", Votes = 235},
            new SortingAndSearchingAlgorithms.CandidateStation {Station = "StationOne", CandidateName = "Ceausescu", Votes = 235},
            new SortingAndSearchingAlgorithms.CandidateStation {Station = "StatioTwo", CandidateName = "Iliescu", Votes =520},
            new SortingAndSearchingAlgorithms.CandidateStation {Station = "StatioTwo", CandidateName = "Vasilescu", Votes = 715},
            new SortingAndSearchingAlgorithms.CandidateStation {Station = "StatioTwo", CandidateName = "Constantinescu", Votes = 54},
            new SortingAndSearchingAlgorithms.CandidateStation {Station = "StatioTwo", CandidateName = "Ceausescu", Votes = 12}
        };

        public SortingAndSearchingAlgorithms.CentralizationVotes[] CentralizationTotalVotes =
       {
            new SortingAndSearchingAlgorithms.CentralizationVotes {CandidateName = "Vasilescu", TotalVotes = 950},
            new SortingAndSearchingAlgorithms.CentralizationVotes {CandidateName = "Iliescu", TotalVotes = 755},            
            new SortingAndSearchingAlgorithms.CentralizationVotes {CandidateName = "Constantinescu", TotalVotes = 289},
            new SortingAndSearchingAlgorithms.CentralizationVotes {CandidateName = "Ceausescu", TotalVotes = 247},            
        };


        [TestMethod]
        public void CentralizationTotalVotesTest()
        {          
            var expectedResult = CentralizationTotalVotes;
            var actualResult = SortingAndSearchingAlgorithms.CentralizationOrderlyTotalVotes(CentruPolling);
            CollectionAssert.AreEqual(expectedResult,actualResult);
        }

    }

 }

