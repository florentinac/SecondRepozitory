using System;
using System.Collections.ObjectModel;
using System.Dynamic;
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
        public void QuickSort3WayDifferentLettersTest()
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
            var expectedResult = new char[] { 'a', 'b', 'c', 'd', 'p', 'p', 'p', 'p', 'p', 'v', 'w', 'x', 'y', 'z' };
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
        public void QuickSort3WayDifferentSmallInputTest()
        {
            var text = new char[] { 'v', 'w', 'y', 'z','x'};
            var expectedResult = new char[] { 'v', 'w', 'x', 'y', 'z' };
            SortingAndSearchingAlgorithms.QuickSort3Way(text, 0, text.Length - 1);
            CollectionAssert.AreEqual(text, expectedResult);
        }

        [TestMethod]
        public void QuickSort3WayWithAllElementRandom()
        {
            var text = new char[] {'x', 'r', 'a', 'p', 'i'};
            var expectedResult = new char[] {'a', 'i', 'p', 'r', 'x'};
            SortingAndSearchingAlgorithms.QuickSort3Way(text,0,text.Length-1);
            CollectionAssert.AreEqual(text,expectedResult);
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
            new SortingAndSearchingAlgorithms.Words { Word="ion", NoOccurences=3},
            new SortingAndSearchingAlgorithms.Words { Word="maria", NoOccurences=2},
            new SortingAndSearchingAlgorithms.Words { Word="ana", NoOccurences=1}
        };

        public SortingAndSearchingAlgorithms.Words[] WordsOrdonate = {
            new SortingAndSearchingAlgorithms.Words { Word="ion", NoOccurences=3},
            new SortingAndSearchingAlgorithms.Words { Word="maria", NoOccurences=2},
            new SortingAndSearchingAlgorithms.Words { Word="anb", NoOccurences=1},
            new SortingAndSearchingAlgorithms.Words { Word="aca", NoOccurences=1},
            new SortingAndSearchingAlgorithms.Words { Word="ana", NoOccurences=1},

        };

        public SortingAndSearchingAlgorithms.Words[] WordsOrdonateAlfabetic = {
          new SortingAndSearchingAlgorithms.Words { Word="ion", NoOccurences=3},
          new SortingAndSearchingAlgorithms.Words { Word="maria", NoOccurences=2},
          new SortingAndSearchingAlgorithms.Words { Word="aca", NoOccurences=1},
          new SortingAndSearchingAlgorithms.Words { Word="ana", NoOccurences=1},
          new SortingAndSearchingAlgorithms.Words { Word="anb", NoOccurences=1},
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

        public SortingAndSearchingAlgorithms.CandidateCentralization[] CandidateCentralization =
        {
            new SortingAndSearchingAlgorithms.CandidateCentralization
            {
                Station = new[]
                {
                    new SortingAndSearchingAlgorithms.Candidate {CandidateName = "Vasilescu", Votes = 34},
                    new SortingAndSearchingAlgorithms.Candidate {CandidateName = "Iliescu", Votes = 2},
                    new SortingAndSearchingAlgorithms.Candidate {CandidateName = "Constantinescu", Votes = 23},
                    new SortingAndSearchingAlgorithms.Candidate {CandidateName = "Ceausescu", Votes = 26}
                }
            },
            new SortingAndSearchingAlgorithms.CandidateCentralization
            {
                Station = new[]
                {
                    new SortingAndSearchingAlgorithms.Candidate {CandidateName = "Vasilescu", Votes = 34},
                    new SortingAndSearchingAlgorithms.Candidate {CandidateName = "Iliescu", Votes = 2},
                    new SortingAndSearchingAlgorithms.Candidate {CandidateName = "Constantinescu", Votes = 23},
                    new SortingAndSearchingAlgorithms.Candidate {CandidateName = "Ceausescu", Votes = 26}
                }
            }
        };

        public SortingAndSearchingAlgorithms.VotesCentralization[] VotesCentralization =
       {
            new SortingAndSearchingAlgorithms.VotesCentralization {CandidateName = "Vasilescu", TotalVotes = 68},
            new SortingAndSearchingAlgorithms.VotesCentralization {CandidateName = "Ceausescu", TotalVotes = 52},
            new SortingAndSearchingAlgorithms.VotesCentralization {CandidateName = "Constantinescu", TotalVotes = 46},
            new SortingAndSearchingAlgorithms.VotesCentralization {CandidateName = "Iliescu", TotalVotes = 4}          
            
        };

        [TestMethod]
        public void StructInStructTest()
        {
            var expectedResult = "Constantinescu";
            var actualResult = CandidateCentralization[1].Station[2].CandidateName;
            Assert.AreEqual(expectedResult,actualResult);

        }

        [TestMethod]
        public void OrderedCandidateByNomberOfVotes()
        {
            var expectedResult = VotesCentralization;
            var actualResult = SortingAndSearchingAlgorithms.CentralizationOrderedTotalVotes(CandidateCentralization);
            CollectionAssert.AreEqual(expectedResult,actualResult);
        }

        public SortingAndSearchingAlgorithms.Catalog[] Catalog =
         {   
            new SortingAndSearchingAlgorithms.Catalog
            {
                Students = new []
                {
                    new SortingAndSearchingAlgorithms.Student {Discipline = "Math", Note = 10},
                    new SortingAndSearchingAlgorithms.Student {Discipline = "English", Note = 6},
                    new SortingAndSearchingAlgorithms.Student {Discipline = "Franch", Note = 6}
                },
                StudentName = "Maria"
            },
            new SortingAndSearchingAlgorithms.Catalog
            {
                Students = new []
                {
                    new SortingAndSearchingAlgorithms.Student {Discipline = "Math", Note = 9},
                    new SortingAndSearchingAlgorithms.Student {Discipline = "English", Note = 7},
                    new SortingAndSearchingAlgorithms.Student {Discipline = "Franch", Note = 8}
                },
                StudentName = "Alina"
            }
        };

        public SortingAndSearchingAlgorithms.GeneralAveregeOfStudents[] GeneralAverage =
        {
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Maria", GeneralAverage = 7.33},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Alina", GeneralAverage = 8}
        };
        public SortingAndSearchingAlgorithms.GeneralAveregeOfStudents[] OrderedStudent =
        {
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Alina", GeneralAverage = 8},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Maria", GeneralAverage = 7.33}
            
        };

        [TestMethod]
        public void GeneralAverageOfStudents()
        {
            var expectedResult = GeneralAverage;
            var actualResult = SortingAndSearchingAlgorithms.GetAllGeneralAveragePerStudent(Catalog);
            CollectionAssert.AreEqual(expectedResult,actualResult);

        }

        [TestMethod]
        public void OrderedStudentsByGeneralAverage()
        {
            var expectedResult = OrderedStudent;
            var actualResult = SortingAndSearchingAlgorithms.GetOrderedSudentsByGeneralAverege(Catalog);
            CollectionAssert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetStudentWithGeneralAverage()
        {
            var expectedResult = new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents
            {
                StudentName = "Maria",
                GeneralAverage = 7.33
            };
            var actualResult = SortingAndSearchingAlgorithms.GetStudentWithGeneralAverage(OrderedStudent, 7.33);
            Assert.AreEqual(expectedResult,actualResult);
        }

        [TestMethod]
        public void GetStudentWithGeneralAverageWhenIsNotStudent()
        {
            var expectedResult = new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents
            {
                StudentName = "Null",
                GeneralAverage = 0
            };
            var actualResult = SortingAndSearchingAlgorithms.GetStudentWithGeneralAverage(OrderedStudent, 6);
            Assert.AreEqual(expectedResult, actualResult);
        }

        public SortingAndSearchingAlgorithms.GeneralAveregeOfStudents[] GeneralAveregeOfStudent =
        {
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Alina", GeneralAverage = 10},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Maria", GeneralAverage = 9.5},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Sabina", GeneralAverage = 9.3},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Daria", GeneralAverage = 9.1},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Matei", GeneralAverage = 8.2},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Alexandru", GeneralAverage = 7.33},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Izabela", GeneralAverage = 6.7},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "David", GeneralAverage = 5.3},
            new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents {StudentName = "Nicu", GeneralAverage = 5}
        };

        [TestMethod]
        public void StudentWithGeneralAverageFormALargeRange()
        {
            var expectedResult = new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents
            {
                StudentName = "David",
                GeneralAverage = 5.3
            };
            var actualResult = SortingAndSearchingAlgorithms.GetStudentWithGeneralAverage(GeneralAveregeOfStudent, 5.3);
            Assert.AreEqual(expectedResult, actualResult);
        }

        public void StudentWithSmallestGeneralAverage()
        {
            var expectedResult = new SortingAndSearchingAlgorithms.GeneralAveregeOfStudents
            {
                StudentName = "Nicu",
                GeneralAverage = 5
            };
            var actualResult = SortingAndSearchingAlgorithms.GetStudentWithSmallestGeneralAverage(Catalog, 5);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

 }

