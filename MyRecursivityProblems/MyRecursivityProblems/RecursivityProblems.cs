using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyRecursivityProblems
{
    public class RecursivityProblems
    {
        public static long GetFibonacciNumber(int n)
        {
            if (n == 0) return 0;           
            if (n == 1) return 1;
            
            return GetFibonacciNumber(n - 1) + GetFibonacciNumber(n - 2);

        }

        public static string ReverseString(string s)
        {
            if (s.Length == 1||s== string.Empty) return s;         
            return s[s.Length - 1] + ReverseString(s.Substring(0, s.Length - 1));
        }
       
        public static string ReplaceLeterWithString(string s, char leter, string newString)
        {
            if ((s.Length == 1) && (s[0] == leter))
                return newString;
            if (((s.Length == 1) && (s[0] != leter)) || s == string.Empty)
                return s;
            return s[0] != leter
                ? s[0] + ReplaceLeterWithString(s.Substring(1, s.Length - 1), leter, newString)
                : newString + ReplaceLeterWithString(s.Substring(1, s.Length - 1), leter, newString);

        }

        public static double CallsRecursivity(string s)
        {
            var sArray = s.Split();
            var indexArrayParcurs = 0;
            var result = CalculateReversePolishNotation(sArray,ref indexArrayParcurs);
            return result;
        }

        public static double CalculateReversePolishNotation(string[] sArray, ref int indexArray)
        {
            const string operands = "*/+-";
            if (operands.Contains(sArray[indexArray]))
            {
                var operand = sArray[indexArray];
                indexArray++;
                var val1 = CalculateReversePolishNotation(sArray, ref indexArray);              
                var val2 = CalculateReversePolishNotation(sArray, ref indexArray);

                return ApplyOperand(operand, val1, val2);               
            }
            var nr = double.Parse(sArray[indexArray]);
            indexArray++;

            return nr;
        }      

        public static long MoveTower(int nrDisk, char source, char dest, char help, ref int index)
        {
            if (nrDisk < 1) return index;
            MoveTower(nrDisk - 1, source, help, dest,ref index);          
            index++;                
            MoveTower(nrDisk - 1, help, dest, source,ref index);
            return index;

        }

        public static double ApplyOperand(string op, double x, double y)
        {
            if (op == "+")
                return x + y;
            if (op == "*")
                return x * y;
            if (op == "-")
                return x - y;
            return x / y;
        }

    }
}
