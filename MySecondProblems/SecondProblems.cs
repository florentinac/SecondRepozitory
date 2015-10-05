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
            int no_c = 4;
            var coding = new SecondProblems();
            string messageCoding = coding.CodingMessage(message, no_c);
            Console.WriteLine(messageCoding);
            double rezult = coding.CalculateCombinations(49, 6);
            long factorial = coding.Factorial(49);


        }
        public string RemoveSpace(string message)
        {
            var messageProcessed = Regex.Replace(message, @"\W|_", string.Empty);
            return messageProcessed;
        }

        public string RandomChar(int n)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[n];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public string CodingMessage(string message, int no_c)
        {
            string messageClean = RemoveSpace(message);
            int no_l = (int)Math.Ceiling((double)messageClean.Length / no_c);
            int noRandom = no_l * no_c - messageClean.Length;
            string finalMesage = messageClean + RandomChar(noRandom);
            string finalCoding = "";
            for (int i = 0; i < no_l; i++)
            {
                for (int j = i; j < finalMesage.Length; j = j + no_l)
                {
                    finalCoding += finalMesage[j];
                }
            }
            return finalCoding;
        }
        public string DeCoding(string message, int no_c)
        {
            int no_l = (int)Math.Ceiling((double)message.Length / no_c);
            string deCoding = "";
            for (int i = 0; i < no_c; i++)
            {
                for (int j = i; j < message.Length; j = j + no_c)
                {
                    deCoding += message[j];
                   
                }
            }
            return deCoding;
        }
        public long CalculateCombinations(int n, int k)
        {
            var problems = new SecondProblems();
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
