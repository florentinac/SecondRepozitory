using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Array;

namespace MyOOP
{
    public class SortedArray<T> : ArrayClass<T> where T : IComparable
    {
        public SortedArray(T[] data, int count)
        {
            var copyData = new T[data.Length];
            Copy(data, copyData, data.Length);
            this.count = count;           
            this.data = data;
            SortArray();
        }
             
        public override void Add(T newElement)
        {
             
            for (var i = count - 1; i >= 0; i--)
            {
                if (newElement.CompareTo(data[i]) >= 0)
                {
                    Insert(newElement, i + 1);
                    return;
                }
            }
            Insert(newElement, 0);
        }
        
        public override int Find( T newElement)
        {
            return BinarySearch(newElement);
        }

        private int BinarySearch(T newElement)
        {
            var min = 0;
            var max = count - 1;
            while (min <= max)
            {
                var middle = (min + max)/2;
                if (newElement.Equals(data[middle]))
                    return middle;
                if (newElement.CompareTo(data[middle]) <= 0)
                {
                    max = middle - 1;
                }
                else
                {
                    min = middle + 1;
                }
            }
            return -1;
        }

        public void SortArray()
        {
            for (var i = 1; i < count; i++)
                for (var k = i; k > 0; k--)
                {
                    if (data[k].CompareTo(data[k - 1]) <= 0)
                    {
                        Swap(ref data[k], ref data[k - 1]);
                    }
                }
        }

        public static void Swap(ref T x, ref T y)
        {
            var temp = y;
            y = x;
            x = temp;
        }

    }
}
