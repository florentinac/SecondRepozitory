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
            string myString = problems.RemoveSpace("nicaieri nu este ca acasa");
            Assert.AreEqual(myString, "nicaierinuestecaacasa");
        }

        [TestMethod]
        public void CodingMessageTest()
        {
            var problems = new SecondProblems();
            string messageCoding = problems.CodingMessage("Nicaieri nu este ca acasa", 4);
            Assert.AreEqual(messageCoding, "NicaierinuecaacasaiT");
        }

        [TestMethod]
        public void DeCodingMessagetTest()
        {
            var problems = new SecondProblems();
            string messageDeCoding = problems.DeCoding("NicaierinuecaacasaiT", 4);
            Assert.AreEqual(messageDeCoding, "NicaierinuecaacasaiT");
        }

        [TestMethod]
        public void CalculateCombinationsTest()
        {
            var problems = new SecondProblems();
            float rezult = problems.CalculateCombinations(49, 43);
            Assert.AreEqual(rezult, 1);

        }

        [TestMethod]
        public void FactorialTest()
        {
            var problems = new SecondProblems();
            long rezult = problems.Factorial(0);
            Assert.AreEqual(rezult, 1);

        }
        [TestMethod]
        public void ProbabilityTest()
        {
            var problems = new SecondProblems();
            float rezult = problems.ProbabilityWinLoto(6, 6);
            Assert.AreEqual(rezult, 24);

        }


    }
}