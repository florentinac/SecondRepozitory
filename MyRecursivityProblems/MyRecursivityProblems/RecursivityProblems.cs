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
       
        public static string ReplaceLeterWithString(string oldString, char letter, string newString)
        {
            var returnLeterForBasicCases = " ";
            if (ReturnLeterForBasicCases(oldString, letter, newString, ref returnLeterForBasicCases)) return returnLeterForBasicCases;
            var recursion = ReplaceLeterWithString(oldString.Substring(1, oldString.Length - 1), letter, newString);

            return ReplaceCharWithString(oldString[0], letter, newString) + recursion;            

        }

        private static bool ReturnLeterForBasicCases(string oldString, char letter, string newString, ref string returnLeterForBasicCases)
        {
            if ((oldString.Length == 1) && (oldString[0] == letter))
            {
                returnLeterForBasicCases = newString;
                return true;
            }
            if (((oldString.Length == 1) && (oldString[0] != letter)) || oldString == string.Empty)
            {
                returnLeterForBasicCases = oldString;
                return true;
            }
            return false;
        }

        private static string ReplaceCharWithString(char oldString, char leter, string newString)
        {
            return oldString != leter ? oldString.ToString() : newString;
        }


        public static double CallsReversePolishNotation(string s)
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
            var number = double.Parse(sArray[indexArray]);
            indexArray++;

            return number;
        }      

        public static List<int> MoveTower(int howManyDisk, List<int> source, List<int> dest, List<int> help, ref int index)
        {
            if (howManyDisk == 1)
            {
                dest.Add(source.Last());
                source.RemoveAt(source.Count-1);
                index++;

                return dest;
            }
            MoveTower(howManyDisk-1, source, help, dest, ref index);
            dest.Add(source.Last());
            source.RemoveAt(source.Count-1);
            index++;
            MoveTower(howManyDisk - 1, help, dest, source, ref index);

            return dest;
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

        public static int GetValueForPascalTriangle(int row, int col)
        {
            var valueForPascalTriangle=0;
            if (GetValueForBasicCases(row, col, ref valueForPascalTriangle)) return valueForPascalTriangle;
            return GetValueForPascalTriangle(row - 1, col - 1) + GetValueForPascalTriangle(row - 1, col);
        }

        private static bool GetValueForBasicCases(int row, int col, ref int valueForPascalTriangle)
        {
            if (col == 0 || col == row)
            {
                valueForPascalTriangle = 1;
                return true;
            }
            if (col == 1 || (col + 1) == row)
            {
                valueForPascalTriangle = row;
                return true;
            }
            return false;
        }

        public static int[] GetRowFromPascalTriangle(int nrRow, int nrCol)
        {
            var result = new int[nrCol+1];
            for (var i = 0; i <= nrCol; i++)
                result[i] = GetValueForPascalTriangle(nrRow, i);
            return result;
        }
    }
}
