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
            this._data = data;
        }

        private object[] _data;       
        private int _count;

        public object[] Add(object newElement)
        {
            var newArray = new object[8];

            while (_data.Length > newArray.Length)          
                Resize(ref newArray, 2 * newArray.Length);

            Copy(_data, newArray, _data.Length);
            newArray[_data.Length] = newElement;

            return newArray;
        }


    }
}
