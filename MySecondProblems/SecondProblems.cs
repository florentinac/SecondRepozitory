using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MySecondProblems
{
    public class SecondProblems
    {
        
        public string RandomChar(int n)
        {
            var chars = @"\|~!@#$%^&*_+-=`?.,\/><[]{}";
            var stringChars = new char[n];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public string RemoveSpecialCharacters(string message)
        {
            var messageClean = new StringBuilder();
            foreach (var c in message.Where(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
            {
                messageClean.Append(c);
            }

            return messageClean.ToString();
        }

        public int GetNumberLines(string message, int noColumns)
        {
            var noLines = (int)Math.Ceiling((double)message.Length / noColumns);
            return noLines;
        }
        public int GetNumberLetersRandom(string message, int noColumns,int noLines)
        {
            var noLetersRandom = noLines * noColumns - message.Length;
            return noLetersRandom;
        }

        public string EncryptionMessage(string message, int noColumns)
        {
            var messageClean = RemoveSpecialCharacters(message);
            var noLines = GetNumberLines(messageClean, noColumns);
            var noLetersRandom = GetNumberLetersRandom(messageClean, noColumns, noLines);
            var finalMesage = messageClean + RandomChar(noLetersRandom);
            var finalEncryptionMessage = "";
            for (var i = 0; i < noLines; i++)
            {
                for (var j = i; j < finalMesage.Length; j = j + noLines)
                {
                    finalEncryptionMessage += finalMesage[j];
                }
            }
            return finalEncryptionMessage;
        }
        public string DeCryptionMessage(string message, int noColumns)
        {
            var deCryptionMessage = "";
            for (var i = 0; i < noColumns; i++)
            {
                for (var j = i; j < message.Length; j = j + noColumns)
                {
                    deCryptionMessage += message[j];
                   
                }
            }
            return deCryptionMessage;
        }
    }
}
