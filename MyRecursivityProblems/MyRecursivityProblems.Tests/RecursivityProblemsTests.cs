using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyRecursivityProblems.Tests
{
    [TestClass]
    public class RecursivityProblemsTests
    {
        [TestMethod]
        public void FibonacciTest()
        {
            const int expectedRezult = 13;
            var actualRezult = RecursivityProblems.GetFibonacciNumber(7);
            Assert.AreEqual(expectedRezult,actualRezult);
        }

        [TestMethod]
        public void ReverseStringTest()
        {
            const string expectedResult = "dcba";
            var actualResult = RecursivityProblems.ReverseString("abcd");
            Assert.AreEqual(expectedResult,actualResult);
        }   

        [TestMethod]
        public void ReplaceLeterWithStringTest()
        {
            const string expectedResult = "xxxnxxxnxxx";
            var actualResult = RecursivityProblems.ReplaceLeterWithString("anana", 'a', "xxx");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReversePolishNotationTest()
        {
            const double expectedResult = 11.25;
            var actualResult = RecursivityProblems.CallsReversePolishNotation("* / * + 1 2 3 4 5");
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ReversePolishNotationWehnIsValueOperandValueTest()
        {
            const double expectedResult = 21;
            var actualResult = RecursivityProblems.CallsReversePolishNotation("* + 1 2 + 3 4");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TowerOfHanoiTest()
        {
            var source = new List<int>() {5, 4, 3, 2, 1}; 
            var index = 0;
            var dest = new List<int>();
            var help = new List<int>();
            var expectedResult = new int[] {5, 4, 3, 2, 1}; 
            var actualResult = RecursivityProblems.MoveTower(source.Count, source, dest, help, ref index);       
            Assert.AreEqual(index,31);    
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ValueForPascalTriangleTest()
        {
            const long expectedResult = 6;
            var actualResult = RecursivityProblems.GetValueForPascalTriangle(4,2);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RowXForPascalTriangle()
        {
            var expectedResult = new int[] {1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1};
            var actualResult = RecursivityProblems.GetRowFromPascalTriangle(10, 10);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CalculateArrangementsTest()
        {
            const long expectedResult = 12;
            var actualResult = RecursivityProblems.CalculateArrangements(4, 2);
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void PlayGameTest()
        {
            const long expectedResult = 8;
            var startGame = new char[,] { {'-','-', '-', '-'}, { '-' , '-', '-', '-'}, {'-', '-', '-', '-'}, {'-', '-', '-', '-' }};
            var finalGame = new char[,] { { 'X', '-', 'X', '-'}, { '-', 'X', '-', 'X'}, { 'X', '-', 'X', '-'}, {'-', 'X', '-', 'X'}};
            var actualResult = RecursivityProblems.PlayGame(ref startGame);
            CollectionAssert.AreEqual(startGame,finalGame);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
