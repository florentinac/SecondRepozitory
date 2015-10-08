using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilitiesLoto;

namespace Loto
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CalculateCombinationsTest()
        {
            var problems = new Probabilites();
            ulong rezult = problems.CalculateCombinations(49, 6);
            Assert.AreEqual(rezult, (UInt64)13983816);

        }

        [TestMethod]
        public void FactorialTest()
        {
            var problems = new Probabilites();
            ulong rezult = problems.Factorial(6);
            Assert.AreEqual(rezult, (UInt64)720);
            //Assert.AreEqual(rezult, 2432902008176640000);

        }
        [TestMethod]
        public void ProbabilityTest()
        {
            var problems = new Probabilites();
            var win6of6 = problems.ProbabilityWinLoto(6, 6, 49);
            var win5of6 = problems.ProbabilityWinLoto(6, 5, 49);
            var win4of6 = problems.ProbabilityWinLoto(6, 4, 49);
            var win5of40 = problems.ProbabilityWinLoto(5, 5, 40);

            Assert.AreEqual(Math.Round(win6of6, 10), 0.0000000715);
            Assert.AreEqual(Math.Round(win5of6, 10), 0.0000184499);
            Assert.AreEqual(Math.Round(win4of6, 10), 0.0009686197);
            Assert.AreEqual(Math.Round(win5of40, 10), 0.0000015197);


        }
   
        [TestMethod]
        public void PartialFactorialTest()
        {
            var problems = new Probabilites();
            ulong rezult = problems.PartialFactorial(49, 43);
            Assert.AreEqual(rezult, (UInt64)432938943360);
        }
    }
}
