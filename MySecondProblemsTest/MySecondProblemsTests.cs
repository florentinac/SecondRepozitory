using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MySecondProblems.Tests
{
    [TestClass]
    public class SecondProbemsTests
    {
        [TestMethod]
        public void RemoveSpaceTest()
        {
            var problems = new SecondProblems();
            string myString = problems.RemoveSpace("Nicaieri, nu e ca acasa!");
            Assert.AreEqual(myString, "Nicaierinuecaacasa");
        }

        [TestMethod]
        public void CodingMessageTest()
        {
            var problems = new SecondProblems();
            string messageCoding = problems.CodingMessage("Nicaieri nu e ca acasa", 4);
            Assert.AreEqual(messageCoding, "Neeaircsciaaanamiuca");
        }

        [TestMethod]
        public void DeCodingMessagetTest()
        {
            var problems = new SecondProblems();
            string messageDeCoding = problems.DeCoding("Neeaircsciaaanamiuca", 4);
            Assert.AreEqual(messageDeCoding, "Nicaierinuecaacasama");
        }

        [TestMethod]
        public void CalculateCombinationsTest()
        {
            var problems = new SecondProblems();
            long rezult = problems.CalculateCombinations(49,6);
            Assert.AreEqual(rezult, 13983816);

        }

        [TestMethod]
        public void FactorialTest()
        {
            var problems = new SecondProblems();
            long rezult = problems.Factorial(10);
            Assert.AreEqual(rezult, 3628800);

        }
        [TestMethod]
        public void ProbabilityTest()
        {
            var problems = new SecondProblems();
            double win6of6 = problems.ProbabilityWinLoto(6, 6);
            double win5of6 = problems.ProbabilityWinLoto(6, 5);
            double win4of6 = problems.ProbabilityWinLoto(6, 4);
            Assert.AreEqual(Math.Round(win6of6, 10), 0.0000000715);
            Assert.AreEqual(Math.Round(win5of6, 10), 0.0000184499);
            Assert.AreEqual(Math.Round(win4of6,10), 0.0009686197);

        }


    }
}