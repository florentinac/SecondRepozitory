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
        public string RemoveSpace(string message)
        {
            var messageProcessed = Regex.Replace(message, @"\W|_", string.Empty);
            return messageProcessed;
        }

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
            var messageClean = RemoveSpace(message);
            var noLines = (int)Math.Ceiling((double)messageClean.Length / noColumns);
            return noLines;
        }
        public int GetNumberLetersRandom(string message, int noColumns,int noLines)
        {
            var messageClean = RemoveSpace(message);
            var noLetersRandom = noLines * noColumns - messageClean.Length;
            return noLetersRandom;
        }

        public string EncryptionMessage(string message, int noColumns)
        {
            var messageClean = RemoveSpace(message);
            var noLines = GetNumberLines(message, noColumns);
            var noLetersRandom = GetNumberLetersRandom(message, noColumns, noLines);
            var finalMesage = messageClean + RandomChar(noLetersRandom);
            var finalEncryption = "";
            for (var i = 0; i < noLines; i++)
            {
                for (var j = i; j < finalMesage.Length; j = j + noLines)
                {
                    finalEncryption += finalMesage[j];
                }
            }
            return finalEncryption;
        }
        public string DeCryptionMessage(string message, int noColumns)
        {
            var deCryption = "";
            for (var i = 0; i < noColumns; i++)
            {
                for (var j = i; j < message.Length; j = j + noColumns)
                {
                    deCryption += message[j];
                   
                }
            }
            return deCryption;
        }
    }
}
