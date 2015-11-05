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
       // public ArrayClass[] array;
        private int position = -1;
        private object[] array;

        public ArrayEnum(object[] array)
        {
            this.array = array;
        }

        public bool MoveNext()
        {
            position++;
            return (position < array.Length);
        }


        public void Reset()
        {
            position = -1;
        }
        
        public object Current
        {
            get
            {
                try
                {
                    return array[position];
                }
                catch (IndexOutOfRangeException)
                {

                    throw new IndexOutOfRangeException();
                }
               
            }
        }
    }
}
