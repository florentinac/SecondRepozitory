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
        public ArrayClass()
        {
            this.data = new object[8];
            this.count = 0;
        }

        public ArrayClass(object[] data, ref int count)
        {
            this.data = data;
            this.count = count;
        }

        private object[] data;       
        private int count;

        public void Add2(object newElement)
        {
            if (count > 8)
                Resize(ref data, 2*data.Length);            
            data[count] = newElement;
            count++;                               
        }
        public object[] Add(object newElement)
        {
            var newArray = new object[8];

            newArray = ResizeNewArray(data.Length, newArray);

            Copy(data, newArray, data.Length);
            newArray[data.Length] = newElement;

            return newArray;
        }

        public object[] Insert(object newElement, int position)
        {
            var newArray = new object[8];
            newArray = ResizeNewArray(data.Length, newArray);

            for (var i = 0; i <= data.Length; i++)
            {              
                if (i < position)
                    newArray[i] = data[i];
                else if (i == position)
                    newArray[i] = newElement;
                else
                {
                    newArray[i] = data[i - 1];
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

        public object[] Remove(object elementToRemove)
        {
            var newArray = new object[data.Length];
            var index = 0;           

            for (var i = 0; i < data.Length; i++)
            {
                
                if (!(data[i].Equals(elementToRemove)))
                {
                    newArray[index++] = data[i];
                }
            }
            return newArray;
        }

        public object[] Remove(int index)
        {
            var newArray = new object[data.Length];
            var indexNewArray = 0;

            for(var i=0;i<data.Length;i++)
                if (i != index)
                    newArray[indexNewArray++] = data[i];

            return newArray;
        }
    }
}
