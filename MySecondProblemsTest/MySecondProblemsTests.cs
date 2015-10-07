using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;


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
        public void ParametersTest()
        {
            var problems = new SecondProblems();
            var parameters = problems.ParametersMessage("Nicaieri nu e ca acasa", 4);
            Assert.AreEqual(parameters[0], 5);
            Assert.AreEqual(parameters[1], 2);
        }


        [TestMethod]
        public void EncryptionMessageTest()
        {
            var problems = new SecondProblems();
            int noColumns = 4;
            var parameters = problems.ParametersMessage("Nicaieri nu e ca acasa", noColumns);
            string messageEncryption = problems.EncryptionMessage("Nicaieri nu e ca acasa", noColumns);
            string messageEncryptionClean = messageEncryption;

            if(parameters[1] < 1)
            {
                messageEncryptionClean = messageEncryption;
            }
            else
            {                
                for (int i =1; i<= parameters[1]; i++)
                {
                    messageEncryptionClean = messageEncryptionClean.Remove(messageEncryptionClean.Length - noColumns * (parameters[1] - i) -1 , 1);                    
                }
            }
            Assert.AreEqual(parameters[0], 5);
            Assert.AreEqual(parameters[1], 2);
            Assert.AreEqual(messageEncryption.Length, 20);
            Assert.AreEqual(messageEncryptionClean, "Neeaircsciaaanaiuc");                    
        }

        [TestMethod]
        public void DeCodingMessagetTest()
        {
            var problems = new SecondProblems();
            string messageEncryption = problems.EncryptionMessage("Nicaieri nu e ca acasa", 4);
            string messageDeCryption = problems.DeCryptionMessage(messageEncryption, 4);
            messageDeCryption = Regex.Replace(messageDeCryption, @"\W|_", string.Empty);
            Assert.AreEqual(messageDeCryption, "Nicaierinuecaacasa");
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