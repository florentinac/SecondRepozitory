using System;
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
            var actualResult = RecursivityProblems.CallsRecursivity("* / * + 1 2 3 4 5");
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void ReversePolishNotationWehnIsValueOperandValueTest()
        {
            const double expectedResult = 21;
            var actualResult = RecursivityProblems.CallsRecursivity("* + 1 2 + 3 4");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TowerOfHanoiTest()
        {
            const long expectedResult = 511;
            var index = 0;
            var actualResult = RecursivityProblems.MoveTower(9, 'A', 'B', 'C',  ref index);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
