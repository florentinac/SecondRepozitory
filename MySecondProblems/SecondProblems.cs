using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MySecondProblems
{
    public class SecondProblems
    {
        public static void Main()
        {
            string message = "Oriunde e ca acasa!";
            int noColumns = 4;
            var encryption = new SecondProblems();
            string messageCoding = encryption.EncryptionMessage(message, noColumns);
            Console.WriteLine(messageCoding);
            double rezult = encryption.CalculateCombinations(49, 6);
            long factorial = encryption.Factorial(49);

        }
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

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        public int[] ParametersMessage(string message, int noColumns)
        {
            string messageClean = RemoveSpace(message);
            int noLines = (int)Math.Ceiling((double)messageClean.Length / noColumns);
            int noRandom = noLines * noColumns - messageClean.Length;
            var parametres = new int[] { noLines, noRandom };
            return parametres;
        }

        public string EncryptionMessage(string message, int noColumns)
        {
            string messageClean = RemoveSpace(message);
            var parameters = ParametersMessage("Nicaieri nu e ca acasa", 4);
            string finalMesage = messageClean + RandomChar(parameters[1]);
            string finalEncryption = "";
            for (int i = 0; i < parameters[0]; i++)
            {
                for (int j = i; j < finalMesage.Length; j = j + parameters[0])
                {
                    finalEncryption += finalMesage[j];
                }
            }
            //for (int i=finalCoding.Length; i<=no_c*(noRandom-1)+1;i--)
            //    for(j=i)
            return finalEncryption;
        }
        public string DeCryptionMessage(string message, int noColumns)
        {
            string deCryptiong = "";
            for (int i = 0; i < noColumns; i++)
            {
                for (int j = i; j < message.Length; j = j + noColumns)
                {
                    deCryptiong += message[j];
                   
                }
            }
            return deCryptiong;
        }
        public long CalculateCombinations(int n, int k)
        {
            long numerator;
            long denuminator;
            if ((n - k) > k) {
                numerator = PartialFactorial(n, n - k + 1);
                denuminator = Factorial(k);
            }
            else {
                numerator = PartialFactorial(n, k + 1);
                denuminator = Factorial(n - k);
            }           
            return numerator/denuminator;

        }

        public long Factorial(long number)
        {
           long result=1;
           for (int i = 1; i <= number; i++)
              result *= i;
           return result;
        }

        public long PartialFactorial(int number, int k)
        {
            long result = 1;
            for (int i = k; i <= number; i++)
                result *= i;
            return  result;
        }

        public double ProbabilityWinLoto(int n, int k)
        {
            double probability;
            probability = (double)CalculateCombinations(n, k) * (double)CalculateCombinations(49 - n, n - k) / (double)CalculateCombinations(49, n);
            return probability;
        }
    }
}
