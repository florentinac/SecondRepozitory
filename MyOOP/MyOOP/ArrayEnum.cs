using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOP
{
    public class ArrayEnum<T> : IEnumerator
    {
        private ArrayClass<T> array;
        private int position = -1;

        public ArrayEnum(ArrayClass<T> array)
        {
            this.array = array;
        }

        public bool MoveNext()
        {
            position++;
            return (position < array.GetCount());
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current => array.GetElemenetAt(position);
    }
}


