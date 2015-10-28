using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MySortingAndSearchingAlgorithms
{
    public class SortingAndSearchingAlgorithms
    {
        public enum Priority
        {
            Low = 0,
            Medium = 1,
            High = 2
        }

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

        public static int Partition(char[] text, int lowIndex, int highIndex)
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
            var textDescending = text.Reverse();
            return ToArrayString(textDescending);

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
        
        public static void QuickSort3Way(char[] letters, int lowIndex, int highIndex)
        {
            if (letters.Length <= 1)
                return;
            if ((lowIndex + 1) == highIndex)
            {
                if (letters[lowIndex] >= letters[highIndex])
                {
                    Swap(ref letters[lowIndex], ref letters[highIndex]);
                    return;
                }
                else return;
            }           
            if (lowIndex < highIndex)
            {
                var pivot = letters[lowIndex];
                var i = lowIndex;
                var k = lowIndex;
                var p = highIndex;

                Partition(letters, ref i, ref p, pivot, ref k);

                QuickSort3Way(letters, lowIndex, k -1);

                QuickSort3Way(letters, p-1 , highIndex);

            }
        }

        private static void Partition(char[] letters, ref int i, ref int p, char pivot, ref int k)
        {
            while (i <= p)
            {
                if (letters[i] < pivot)
                    Swap(ref letters[i++], ref letters[k++]);
                else if (letters[i] > pivot)
                    Swap(ref letters[i], ref letters[p--]);
                else i++;
            }
        }

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

        public static void Swap(char[] letters, int xStart, int xEnd, int yStart, int yEnd)
        {
            if (xStart < xEnd)
            {
                while (xEnd >= xStart)
                {
                    Swap(ref letters[xStart], ref letters[yStart]);
                  
                    xStart++;
                    yStart++;
                }
            }
        }

        public static int GetMinim(int x, int y)
        {
            return (x < y) ? x : y;
        }

        public static void InsertionSort(int[] number)
        {
            for(var i=1;i<number.Length;i++)
                for (var k = i; k > 0; k--)
                {
                    if (number[k] < number[k - 1])
                    {
                        Swap(ref number[k], ref number[k - 1]);
                    }
                }
        }
        public static void Swap(ref int x, ref int y)
        {
            var temp = y;
            y = x;
            x = temp;
        }

        public static int[] GetPriorities(string[] priority)
        {
            var result = new int[priority.Length];
            for (var i = 0; i < priority.Length; i++)
            {
                if (priority[i] == Priority.High.ToString())
                    result[i] = 2;
                else if (priority[i] == Priority.Medium.ToString())
                    result[i] = 1;
                else result[i] = 0;
            }
            return result;
        }
    }
}