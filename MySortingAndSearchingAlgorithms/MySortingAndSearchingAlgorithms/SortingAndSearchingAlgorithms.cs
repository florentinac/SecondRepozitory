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
            Low,
            Medium,
            High
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
            if (lowIndex < highIndex)
            {
                var pivot = letters[lowIndex];
                var i = lowIndex;
                var k = lowIndex;
                var p = highIndex;

                Partition(letters, ref i, ref p, pivot, ref k);

                QuickSort3Way(letters, lowIndex, k - 1);

                QuickSort3Way(letters, p, highIndex);

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
            if (letters[p] == pivot)
                p++;
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
            for (var i = 1; i < number.Length; i++)
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

        public static Priority[] BubbleSortPriority(Priority[] number)
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

        public static void Swap(ref Priority x, ref Priority y)
        {
            var temp = y;
            y = x;
            x = temp;
        }

        public struct Words
        {
            public string Word;
            public int NrApparition;
        }

        public static Words[] GetDistinctWordsAndNumberOfWords(string[] text)
        {
            var structOrdonate = new Words[0];           
            for (var i = 0; i < text.Length; i++)
            {
                SearchElementStruct(ref structOrdonate, text[i]);
            }

            return structOrdonate;
        }

        public static Words[] SearchElementStruct(ref Words[] structOrdonate, string word)
        {
            var newValue = new Words { Word = word, NrApparition = 1 };   
                    
            for (var i = 0; i <= structOrdonate.Length - 1; i++)
                if (string.CompareOrdinal(word, structOrdonate[i].Word) == 0)
                {
                    structOrdonate[i].NrApparition++;
                    return structOrdonate;
                }

            AddToArray(ref structOrdonate, newValue);
                
            return structOrdonate;
        }

        public static Words[] GetOrderlyWords(string[] text)
        {
            var wordsdistinct = GetDistinctWordsAndNumberOfWords(text);
            
            GetOrderlyWordsByNumberOfAparition(wordsdistinct);

            return wordsdistinct;
        }
      
        public static void GetOrderlyWordsByNumberOfAparition(Words[] words)
        {
            for (var i = 0; i < words.Length; i++)
                for (var k = i; k > 0; k--)
                {
                    if ((words[k].NrApparition > words[k - 1].NrApparition)||
                       ((words[k].NrApparition==words[k-1].NrApparition)&& (string.CompareOrdinal(words[k].Word, words[k - 1].Word) < 0)))
                    {
                        Swap(ref words[k], ref words[k - 1]);
                    }
                }                     
        }

        public static void Swap(ref Words x, ref Words y)
        {
            var temp = y;
            y = x;
            x = temp;
        }

        public static Words[] AddToArray(ref Words[] array, Words newValue)
        {
            array = ResizeArray(array, 1);
            array[array.Length - 1] = newValue;
            return array;
        }

        public static Words[] ResizeArray(Words[] oldArray, int difference)
        {
            var newArray = new Words[oldArray.Length + difference];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
            return newArray;
        }        
      
        public struct CentralizationVotes
        {
            public string CandidateName;
            public long TotalVotes;
        }

        public struct Candidate
        {
            public string CandidateName;
            public long Votes;
        }

        public struct CentralizationCandidate
        {
            public Candidate[] Station;
        }

        public static CentralizationVotes[] CentralizationOrderlyTotalVotes(CentralizationCandidate[] candidates)
        {
            var totalOrderedVotes = new CentralizationVotes[0];
            for (var i = 0; i < candidates.Length; i++)
            {
                for (var k = 0; k < candidates[i].Station.Length; k++)
                    SearchCandidateVotes(ref totalOrderedVotes, candidates[i].Station[k].CandidateName,
                        candidates[i].Station[k].Votes);

            }
            GetOrderlyCandidatesByNumberOfVotes(totalOrderedVotes);

            return totalOrderedVotes;
        }

        public static CentralizationVotes[] SearchCandidateVotes(ref CentralizationVotes[] candidate, string candidateName, long votes)
        {
            var newValue = new CentralizationVotes { CandidateName = candidateName, TotalVotes = votes };
           
            for (var k = 0; k < candidate.Length; k++)
            {
                if (string.CompareOrdinal(candidateName, candidate[k].CandidateName) == 0)
                {
                    candidate[k].TotalVotes += votes;
                    return candidate;
                }

            }
            AddToArray(ref candidate, newValue);

            return candidate;

        }

        public static void GetOrderlyCandidatesByNumberOfVotes(CentralizationVotes[] candidate)
        {
            for (var i = 0; i < candidate.Length; i++)
                for (var k = i; k > 0; k--)
                {
                    if (candidate[k].TotalVotes > candidate[k - 1].TotalVotes)
                    {
                        Swap(ref candidate[k], ref candidate[k - 1]);
                    }
                }
        }

        public static void Swap(ref CentralizationVotes x, ref CentralizationVotes y)
        {
            var temp = y;
            y = x;
            x = temp;
        }

        public static CentralizationVotes[] AddToArray(ref CentralizationVotes[] array, CentralizationVotes newValue)
        {
            array = ResizeArray(array, 1);
            array[array.Length - 1] = newValue;

            return array;
        }

        public static CentralizationVotes[] ResizeArray(CentralizationVotes[] oldArray, int difference)
        {
            var newArray = new CentralizationVotes[oldArray.Length + difference];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];

            return newArray;
        }

        
       

    }
}