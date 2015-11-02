using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
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
            public int NoOccurences;
        }

        public static Words[] GetOrderlyWords(string[] text)
        {
            var distinctWords = GetDistinctWordsAndNumberOfWords(text);

            GetOrderedWordsByNumberOfOccurrencesAndAlphabetic(distinctWords);

            return distinctWords;
        }

        public static Words[] GetDistinctWordsAndNumberOfWords(string[] text)
        {
            var distinctWords = new Words[0];           
            for (var i = 0; i < text.Length; i++)
            {
                SearchElementStruct(ref distinctWords, text[i]);
            }

            return distinctWords;
        }

        public static Words[] SearchElementStruct(ref Words[] distinctWords, string word)
        {
            var newValue = new Words { Word = word, NoOccurences = 1 };   
                    
            for (var i = 0; i <= distinctWords.Length - 1; i++)
                if (string.CompareOrdinal(word, distinctWords[i].Word) == 0)
                {
                    distinctWords[i].NoOccurences++;
                    return distinctWords;
                }

            AddToArray(ref distinctWords, newValue);
                
            return distinctWords;
        }
        
        public static void GetOrderedWordsByNumberOfOccurrencesAndAlphabetic(Words[] words)
        {
            for (var i = 0; i < words.Length; i++)
                for (var k = i; k > 0; k--)
                {
                    if ((words[k].NoOccurences > words[k - 1].NoOccurences)||
                       ((words[k].NoOccurences==words[k-1].NoOccurences)&& (string.CompareOrdinal(words[k].Word, words[k - 1].Word) < 0)))
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
      
        public struct VotesCentralization
        {
            public string CandidateName;
            public long TotalVotes;
        }

        public struct Candidate
        {
            public string CandidateName;
            public long Votes;
        }

        public struct CandidateCentralization
        {
            public Candidate[] Station;
        }

        public static VotesCentralization[] CentralizationOrderedTotalVotes(CandidateCentralization[] candidates)
        {
            var totalOrderedVotes = new VotesCentralization[0];
            for (var i = 0; i < candidates.Length; i++)
            {
                for (var k = 0; k < candidates[i].Station.Length; k++)
                    SearchCandidate(ref totalOrderedVotes, candidates[i].Station[k].CandidateName,
                        candidates[i].Station[k].Votes);

            }
            GetOrderlyCandidatesByNumberOfVotes(totalOrderedVotes);

            return totalOrderedVotes;
        }

        public static VotesCentralization[] SearchCandidate(ref VotesCentralization[] candidate, string candidateName, long votes)
        {
            var newValue = new VotesCentralization { CandidateName = candidateName, TotalVotes = votes };
           
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

        public static void GetOrderlyCandidatesByNumberOfVotes(VotesCentralization[] candidate)
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

        public static void Swap(ref VotesCentralization x, ref VotesCentralization y)
        {
            var temp = y;
            y = x;
            x = temp;
        }

        public static VotesCentralization[] AddToArray(ref VotesCentralization[] array, VotesCentralization newValue)
        {
            array = ResizeArray(array, 1);
            array[array.Length - 1] = newValue;

            return array;
        }

        public static VotesCentralization[] ResizeArray(VotesCentralization[] oldArray, int difference)
        {
            var newArray = new VotesCentralization[oldArray.Length + difference];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];

            return newArray;
        }

        public struct Student
        {            
            public string Discipline;
            public int Mark;
        }

        public struct Catalog
        {
            public string StudentName;
            public Student[] Students;
        }

        public struct GeneralAveregeOfStudents
        {
            public string StudentName ;
            public double GeneralAverage;

        }

        public static GeneralAveregeOfStudents[] GetOrderedSudentsByGeneralAverege(Catalog[] catalog)
        {
            var students = GetAllGeneralAveragePerStudent(catalog);
            for(var i=0;i< students.Length;i++)
                for (var k = i; k > 0; k--)
                {
                    if (students[k].GeneralAverage > students[k - 1].GeneralAverage)
                        Swap(ref students[k], ref students[k - 1]);
                }

            return students;

        } 

        public static GeneralAveregeOfStudents[] GetAllGeneralAveragePerStudent(Catalog[] catalog)
        {
            var generalAverage = new GeneralAveregeOfStudents[0];
            for (var i = 0; i < catalog.Length ; i++)
            {
                var newValue = GetGeneralAverage(catalog[i]);
                AddToArray(ref generalAverage, newValue);
            }
            return generalAverage;

        }

        public static GeneralAveregeOfStudents GetGeneralAverage(Catalog student)
        {
                      
            var totalMark = GetTotalNote(student);
            var generalAverage = Math.Round((double) totalMark / student.Students.Length, 2);
           
            return new GeneralAveregeOfStudents
            {
                StudentName = student.StudentName,
                GeneralAverage = generalAverage
            }; 
        }

        private static int GetTotalNote(Catalog student)
        {
            var totalMark = 0;
            for (var i = 0; i < student.Students.Length; i++)
            {
                totalMark += student.Students[i].Mark;
            }
            return totalMark;
        }

        public static GeneralAveregeOfStudents[] GetStudentWithGeneralAverage(GeneralAveregeOfStudents[] students,
            double generalAverage)
        {
            var min = 0;
            var max = students.Length-1;
            var studentWithGeneralAverage=new GeneralAveregeOfStudents[0];

            while (min <= max)
            {
                var middle = (min + max)/2;
                if (generalAverage == students[middle].GeneralAverage)
                    AddToArray(ref studentWithGeneralAverage, students[middle]);
                if (generalAverage > students[middle].GeneralAverage)
                    max = middle - 1;
                else
                {
                    min = middle + 1;
                }
            }
            return studentWithGeneralAverage;
        }

        public static GeneralAveregeOfStudents[] GetStudentWithSmallestGeneralAverage(Catalog[] catalog,
            double generalAverage)
        {
            var studentsWithSmallestGeneralAverege = new GeneralAveregeOfStudents[0];
           
             var orderedStudents = GetOrderedSudentsByGeneralAverege(catalog);

            for(var i=0;i<orderedStudents.Length;i++)
                if (orderedStudents[i].GeneralAverage == generalAverage)
                    AddToArray(ref studentsWithSmallestGeneralAverege, orderedStudents[i]);
                

            return studentsWithSmallestGeneralAverege;
        }

        public static GeneralAveregeOfStudents[] GetStudentWithMostMarkOfTen(Catalog[] catalog)
        {           
            var studentsWithNoMax = new GeneralAveregeOfStudents[0];

            var generalAverage = GetAllGeneralAveragePerStudent(catalog);
            var arrayNoMark = GetNoOfMarkPerStudent(catalog);
            var noMax = GetMaxVaule(arrayNoMark);

            for(var i=0;i<arrayNoMark.Length-1;i++)
                if (arrayNoMark[i] == noMax)
                    AddToArray(ref studentsWithNoMax, generalAverage[i]);

            return studentsWithNoMax;

        }

        private static int GetMaxVaule(int[] arrayNoNote)
        {
            var noMax = arrayNoNote[0];
            for (var i = 0; i < arrayNoNote.Length - 1; i++)
                if (noMax < arrayNoNote[i])
                    noMax = arrayNoNote[i];
            return noMax;
        }

        private static int[] GetNoOfMarkPerStudent(Catalog[] catalog)
        {
            var arrayNoNote = new int[0];
            for (var i = 0; i < catalog.Length; i++)
            {
                var noNote = GetNoMarkOfTen(catalog, i);
                AddToArray(ref arrayNoNote, noNote);
            }
            return arrayNoNote;
        }

        private static int GetNoMarkOfTen(Catalog[] catalog, int i)
        {
            var noNote = 0;
            for (var k = 0; k < catalog[i].Students.Length; k++)
                if (catalog[i].Students[k].Mark == 10)
                    noNote++;
            return noNote;
        }

        public static void Swap(ref GeneralAveregeOfStudents x, ref GeneralAveregeOfStudents y)
        {
            var temp = y;
            y = x;
            x = temp;
        }
        public static GeneralAveregeOfStudents[] AddToArray(ref GeneralAveregeOfStudents[] array, GeneralAveregeOfStudents newValue)
        {
            array = ResizeArray(array, 1);
            array[array.Length - 1] = newValue;
            return array;
        }

        public static GeneralAveregeOfStudents[] ResizeArray(GeneralAveregeOfStudents[] oldArray, int difference)
        {
            var newArray = new GeneralAveregeOfStudents[oldArray.Length + difference];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
            return newArray;
        }

        public static int[] AddToArray(ref int[] array, int newValue)
        {
            array = ResizeArray(array, 1);
            array[array.Length - 1] = newValue;
            return array;
        }

        public static int[] ResizeArray(int[] oldArray, int difference)
        {
            var newArray = new int[oldArray.Length + difference];
            for (var i = 0; i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
            return newArray;
        }

        public static int[] GetDigitsFromANumber(int number)
        {
            var digitsNumber = new int[0];
            int i = 0;
            while (number > 0)
            {
                var digits = number % 10;
                number = number / 10;
                digits = (int) (digits * (Math.Pow(10 ,i)));
                i++;
                AddToArray(ref digitsNumber, digits);
            }
            return digitsNumber;
        }

        public static string ConversionsFromNumbersIntoRomanNumerals(int number)
        {
            if (number > 44000 || number < 0) return "Insert value betwheen 1 and 43999";
            if (number >= 40000) return "XL" + ConversionsFromNumbersIntoRomanNumerals(number - 40000);
            if (number >= 10000) return "X" + ConversionsFromNumbersIntoRomanNumerals(number - 10000);
            if (number >= 9000) return "MX" + ConversionsFromNumbersIntoRomanNumerals(number - 9000);
            if (number >= 5000) return "V" + ConversionsFromNumbersIntoRomanNumerals(number - 5000);
            if (number >= 4000) return "MV" + ConversionsFromNumbersIntoRomanNumerals(number - 4000);
            if (number >= 1000) return "M" + ConversionsFromNumbersIntoRomanNumerals(number - 1000);
            if (number >= 900) return "CM" + ConversionsFromNumbersIntoRomanNumerals(number - 900);
            if (number >= 500) return "D" + ConversionsFromNumbersIntoRomanNumerals(number - 500);
            if (number >= 400) return "CD" + ConversionsFromNumbersIntoRomanNumerals(number - 400);
            if (number >= 100) return "C" + ConversionsFromNumbersIntoRomanNumerals(number - 100);
            if (number >= 90) return "XC" + ConversionsFromNumbersIntoRomanNumerals(number - 90);
            if (number >= 50) return "L" + ConversionsFromNumbersIntoRomanNumerals(number - 50);
            if (number >= 40) return "XL" + ConversionsFromNumbersIntoRomanNumerals(number - 40);
            if (number >= 10) return "X" + ConversionsFromNumbersIntoRomanNumerals(number - 10);
            if (number >= 9) return "IX" + ConversionsFromNumbersIntoRomanNumerals(number - 9);
            if (number >= 5) return "V" + ConversionsFromNumbersIntoRomanNumerals(number - 5);
            if (number >= 4) return "IV" + ConversionsFromNumbersIntoRomanNumerals(number - 4);
            if(number>=1) return "I" + ConversionsFromNumbersIntoRomanNumerals(number - 1);
            return string.Empty;
           

        }

        public static void MergeSort(int[] array)
        {
            var n = array.Length;
            if (n < 2)
                return;           
            var middle = n/2;
            var leftArray = new int[middle];
            var rightArray = new int[n-middle];

            leftArray=CopyArray(array, ref leftArray, 0, middle-1);
            rightArray = CopyArray(array, ref rightArray, middle, n-1);

            MergeSort(leftArray);
            MergeSort(rightArray);

            Merge(leftArray,rightArray, array);

        }

        public static int[] CopyArray(int[] arrayOld, ref int[] newArray, int left, int right)
        {
            for (int i = left; i <= right; i++)
                newArray[i-left] = arrayOld[i];
            return newArray;
        }

        public static void Merge(int[] leftArray, int[] rightArray, int[] array)
        {
            var i = 0;
            var k = 0;
            var j = 0;
            while (i < leftArray.Length && j < rightArray.Length)
            {
                if(leftArray[i]<rightArray[j])
                    array[k++] = leftArray[i++];
                else
                {
                    array[k++] = rightArray[j++];
                }
            }
            while (i < leftArray.Length)
                array[k++] = leftArray[i++];
            while (j < rightArray.Length)
                array[k++] = rightArray[j++];

        }

        public static void ShellSort(int[] array)
        {
            var h = 1;
            while (h < array.Length)
                h = 3*h;
            while (h > 0)
            {
                h /= 3;
                InsertionSort(array, h);
            }
        }

        private static void InsertionSort(int[] array, int h)
        {
            for (var k = h; k < array.Length; k++)
            {
                var v = array[k];
                var j = k;
                while (j >= h && array[j - h] > v)
                {
                    array[j] = array[j - h];
                    j = j - h;
                }
                array[j] = v;
            }
        }
    }
}