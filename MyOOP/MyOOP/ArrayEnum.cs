using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOP
{
    public class ArrayEnum : IEnumerator
    {
        private ArrayClass array;
        private int position = -1;        

        public ArrayEnum(ArrayClass array)
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
