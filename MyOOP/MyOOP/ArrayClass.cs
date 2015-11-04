using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Array;

namespace MyOOP
{
    public class ArrayClass
    {
        public ArrayClass(object[] data)
        {
            _data = data;
        }

        private object[] _data;       
        private int _count;

        public object[] Add(object newElement)
        {
            var newArray = new object[8];

            newArray = ResizeNewArray(_data.Length, newArray);

            Copy(_data, newArray, _data.Length);
            newArray[_data.Length] = newElement;

            return newArray;
        }

        public object[] Insert(object newElement, int position)
        {
            var newArray = new object[8];
            newArray = ResizeNewArray(_data.Length, newArray);

            for (var i = 0; i <= _data.Length; i++)
            {              
                if (i < position)
                    newArray[i] = _data[i];
                else if (i == position)
                    newArray[i] = newElement;
                else
                {
                    newArray[i] = _data[i - 1];
                }
            }
            return newArray;
        }

        private static object[] ResizeNewArray(int size, object[] newArray)
        {
            while (size >= newArray.Length)
                Resize(ref newArray, 2*newArray.Length);
            return newArray;
        }
    }
}
