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
            //string deCodingMessage = DeCoding(messageCoding, no_c);
            //Console.WriteLine(deCodingMessage);
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
            //Console.WriteLine(finalString);
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
                    //Console.Write(finalMesage[i]);

                }
            }
            return deCoding;
        }
        public double CalculateCombinations(int n, int k)
        {
            var problems = new SecondProblems();
            int val = n - k;
            double rezult = problems.Factorial(n) / (problems.Factorial(k) * problems.Factorial(val));
            return rezult;

        }
        public long Factorial(long number)
        {
            if (number <= 1)
                return 1;
            else
                return number*Factorial(number-1);

        }
        public double ProbabilityWinLoto(int n, int k)
        {
            double probability = 0;
            probability = CalculateCombinations(n, k) * CalculateCombinations(49 - n, n - k) / CalculateCombinations(49, n);
            return probability;
        }
    }
}
