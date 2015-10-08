using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilitiesLoto
{
    public class ProbabilitesLoto
    {
        public ulong CalculateCombinations(ulong n, ulong k)
        {
            ulong numerator;
            ulong denuminator;
            if ((n - k) > k)
            {
                numerator = PartialFactorial(n, n - k + 1);
                denuminator = Factorial(k);
            }
            else
            {
                numerator = PartialFactorial(n, k + 1);
                denuminator = Factorial(n - k);
            }
            return numerator / denuminator;

        }

        public ulong Factorial(ulong number)
        {
            ulong result = 1;
            for (ulong i = 1; i <= number; i++)
                result *= i;
            return result;
        }

        public ulong PartialFactorial(ulong number, ulong k)
        {
            ulong result = 1;
            for (var i = k; i <= number; i++)
                result *= i;
            return result;
        }

        public double ProbabilityWinLoto(ulong n, ulong k)
        {
            var probability = (double)CalculateCombinations(n, k) * (double)CalculateCombinations(49 - n, n - k) / (double)CalculateCombinations(49, n);
            return probability;
        }


    }
}
