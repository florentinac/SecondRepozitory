using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
       
        public static string ReplaceLeterWithString(string s, char leter, string newleter)
        {
            if ((s.Length == 1) && (s[0] == leter))
                return newleter;
            if (((s.Length == 1) && (s[0] != leter)) || s == string.Empty)
                return s;
            return s[0] != leter
                ? s[0] + ReplaceLeterWithString(s.Substring(1, s.Length - 1), leter, newleter)
                : newleter + ReplaceLeterWithString(s.Substring(1, s.Length - 1), leter, newleter);

        }

        public static double CalculateRecursiv(string s)
        {          
            var sClean = s.Split(' ');
            for (int i = 0; i < sClean.Length; i++)
            {
                if (sClean[i] != "+")
                {
                    var rez = Add(double.Parse(sClean[i]), double.Parse(sClean[i+1]));
                    return rez +
                           CalculateRecursiv(string.Concat(string.Concat(s.Substring(0, i - 1), rez.ToString()),
                               s.Substring(i + 2, s.Length - 1)));
                }
            }
            return 0;



        }

        public static double Add(double x, double y)
        {
            return x + y;
        }
        public static double Substraction(double x, double y)
        {
            return x - y;
        }
        public static double Multiplay(double x, double y)
        {
            return x * y;
        }

        public static double Division(double x, double y)
        {
            return x / y;
        }





    }
}
