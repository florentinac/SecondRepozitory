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
            var expectedRezult = 13;
            var actualRezult = RecursivityProblems.GetFibonacciNumber(7);
            Assert.AreEqual(expectedRezult,actualRezult);
        }

        [TestMethod]
        public void ReverseStringTest()
        {
            var expectedResult = "dcba";
            var actualResult = RecursivityProblems.ReverseString("abcd");
            Assert.AreEqual(expectedResult,actualResult);
        }   

        [TestMethod]
        public void ReplaceLeterWithStringTest()
        {
            var expectedResult = "xxxnxxxnxxx";
            var actualResult = RecursivityProblems.ReplaceLeterWithString("anana", 'a', "xxx");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RecursivityTest()
        {
            var expectedResult = 6;
            var actualResult = RecursivityProblems.CalculateRecursiv("+ + + 2.5 3.5 4 7");
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
