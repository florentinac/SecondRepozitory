using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOP
{
    public class SortedArray<T> : ArrayClass<T> where T : IComparable
    {
        public SortedArray(T[] data, int count)
        {
            this.count = count;
            this.data = data;
        }
             
        public override void Add(T newElement)
        {
            var oldCount = count;
            if (newElement.CompareTo(data[0]) <= 0 || count==0)
            {
                Insert(newElement, 0);
                return;
            }
            for (var i = oldCount - 1; i >= 0; i--)
            {
                if (newElement.CompareTo(data[i]) >= 0)
                {
                    Insert(newElement, i + 1);
                    return;
                }
            }
        }
        public void SortArray(T[] array)
        {
            for (var i = 1; i < count; i++)
                for (var k = i; k > 0; k--)
                {
                    if (array[k].CompareTo(array[k - 1])<=0)
                    {
                        Swap(ref array[k], ref array[k - 1]);
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
