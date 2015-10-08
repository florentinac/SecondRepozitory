using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;


namespace MySecondProblems.Tests
{
    [TestClass]
    public class SecondProbemsTests
    {
            
        [TestMethod]
        public void NumerLinesTest()
        {
            var problems = new SecondProblems();
            var noLines = problems.GetNumberLines("Nicaieri nu e ca acasa", 4);
            Assert.AreEqual(noLines, 5);
        }
        [TestMethod]
        public void NumerLeterRandomTest()
        {
            var problems = new SecondProblems();
            var noLetersRandom = problems.GetNumberLetersRandom("Nicaieri nu e ca acasa", 4, 5);
            Assert.AreEqual(noLetersRandom, 2);
        }

        [TestMethod]
        public void MessageWithoutSpaceAndSpecialSignTest()
        {
            var problems = new SecondProblems();
            var messageClean = problems.RemoveSpecialCharacters("Nicaieri!#21 nu. e ca acasa*(");
            Assert.AreEqual(messageClean, "Nicaieri21nuecaacasa");
        }

        [TestMethod]
        public void EncryptionMessageWhenNumberOfRandomLetersIsZeroTest()
        {
            var problems = new SecondProblems();
            var noColumns = 4;
            var noLines = problems.GetNumberLines("Nicaieri nu e ca aca", noColumns);
            var noLetersRandom = problems.GetNumberLetersRandom("Nicaieri nu e ca aca", noColumns, noLines);
            var messageEncryption = problems.EncryptionMessage("Nicaieri nu e ca aca", noColumns);

            Assert.AreEqual(noLetersRandom,0);
            Assert.AreEqual(noLines,4);
            Assert.AreEqual(messageEncryption, "Ninaieuacrecaica");                    
        }
        [TestMethod]
        public void EncryptionMessageWhenNumberOfRandomLetersIsOneTest()
        {
            var problems = new SecondProblems();
            var noColumns = 4;
            var noLines = problems.GetNumberLines("Nicaieri nu e ca acasaa", noColumns);
            var noLetersRandom = problems.GetNumberLetersRandom("Nicaieri nu e ca acasaa", noColumns, noLines);
            var messageEncryption = problems.EncryptionMessage("Nicaieri nu e ca acasaa", noColumns);
            var messageEncryptionClean = messageEncryption;
          
            messageEncryptionClean = messageEncryptionClean.Remove(messageEncryptionClean.Length - noColumns * (noLetersRandom - 1) -1 , 1);                    
            
            Assert.AreEqual(noLetersRandom, 1);
            Assert.AreEqual(noLines, 5);
            Assert.AreEqual(messageEncryptionClean, "Neeaircsciaaanaaiuc");
        }

        [TestMethod]
        public void EncryptionMessageWhenNumberOfRandomLetersIsTwoTest()
        {
            var problems = new SecondProblems();
            var noColumns = 4;
            var noLines = problems.GetNumberLines("Nicaieri nu e ca acasa", noColumns);
            var noLetersRandom = problems.GetNumberLetersRandom("Nicaieri nu e ca acasa", noColumns, noLines);
            var messageEncryption = problems.EncryptionMessage("Nicaieri nu e ca acasa", noColumns);
            var messageEncryptionClean = messageEncryption;

            messageEncryptionClean = messageEncryptionClean.Remove(messageEncryptionClean.Length - noColumns * (noLetersRandom - 2) - 1, 1);
            messageEncryptionClean = messageEncryptionClean.Remove(messageEncryptionClean.Length - noColumns * (noLetersRandom - 1), 1);

            Assert.AreEqual(noLetersRandom, 2);
            Assert.AreEqual(noLines, 5);
            Assert.AreEqual(messageEncryptionClean, "Neeaircsciaaanaiuc");
        }
      
    }
}