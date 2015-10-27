using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySortingAndSearchingAlgorithms
{
    public class SortingAndSearchingAlgorithms
    {

        public static void QuickSortForOrderAscendingText(char[] text, int left, int right)
        {           
            if (text.Length <= 1)
                return;
            if (left < right)
            {
                var pivot = Partition(text, left, right);

                if (pivot > 1)
                   QuickSortForOrderAscendingText(text, left, pivot - 1);
                if (pivot + 1 < right)
                   QuickSortForOrderAscendingText(text, pivot + 1, right);
            }           
        }

        public static int Partition(char[] text,int lowIndex ,int highIndex)
        {
            int pivot = text[lowIndex];
            while (true)
            {
                while (text[lowIndex] < pivot)
                    lowIndex++;
                while (text[highIndex] > pivot)
                    highIndex--;
                if (lowIndex < highIndex)
                {
                    Swap(ref text[lowIndex], ref text[highIndex]);
                }
                else return highIndex;

            }
        }
        public static void Swap(ref char x, ref char y)
        {
            var temp = y;
            y = x;
            x = temp;
        }

        public static string GetDescendingText(char[] text, int lowIndex, int highIndex)
        {
            QuickSortForOrderAscendingText(text, lowIndex, highIndex);
            var textDescending=text.Reverse();
            return  ToArrayString(textDescending);

        }

        public static string ToArrayString(IEnumerable<char> charSequence)
        {
            return new string(charSequence.ToArray());
        }

        public static char[] BubbleSort(char[] number)
        {
            var isSorted = false;
            while (!isSorted) 
            {
                isSorted = true;
                for (var i = 0; i < number.Length - 1; i++)
                {
                    if (number[i] > number[i + 1])
                    {
                        Swap(ref number[i], ref number[i + 1]);
                        isSorted = false;
                    }
                }
            }
            return number;
        }

        //public static void QuickSort3Way(string[] priority, int lowIndex, int highIndex)
        //{
        //    if (highIndex <= lowIndex) return;

        //    var i = lowIndex + 1;
        //    var pivot = priority[lowIndex];

        //    while (i <= highIndex)
        //    {
        //        if (Less(priority[i],pivot))
        //            Swap(priority[i++], priority[lowIndex++]);
        //        if(Less(pivot, input[i]))
        //            Swap(priority[i], priority[higtIndex--]);
        //        else i++;
        //    }
        //   QuickSort3Way(priority, lowIndex, lowIndex-1);
        //   QuickSort3Way(priority, highIndex+1, highIndex);
        //}

        public static bool Less(string x, string y)
        {
            var isLess = false;
            for (var i = 0; i < x.Length; i++)
                if (x[i] <= y[i])
                    isLess = true;
                else    
                {
                    isLess = false;
                    break;
                }
            return isLess;
        }
    }
}
