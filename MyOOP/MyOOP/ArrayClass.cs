using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Array;

namespace MyOOP
{
    public class ArrayClass:IEnumerable
    {
        public ArrayClass()
        {
            this.data = new object[8];
            this.count = 0;
        }

        public ArrayClass(object[] data, int count)
        {
            this.data = data;
            this.count = count;
        }

        private object[] data;
        private int count;

        

        public void Add2(object newElement)
        {
            ResizeArray();
            data[count] = newElement;
            count++;
        }

        private void ResizeArray()
        {
            if (count >= data.Length)
                Resize(ref data, 2*data.Length);
        }

        public void Insert(object newElement, int position)
        {
            ResizeArray();
            ShiftRight(position);
            InsertElement(newElement, position);
        }

        private void InsertElement(object newElement, int position)
        {
            data[position] = newElement;
            count++;
        }

        private void ShiftRight(int position)
        {
            for (var i = count + 1; i >= position; i--)
                data[i] = data[i - 1];
        }

        public void Remove(object elementToRemove)
        {
            var index = 0;
            var countInitial = count;
            for (var i = 0; i < countInitial; i++)
            {
                if (!(data[i].Equals(elementToRemove)))
                {
                    data[index++] = data[i];
                }
                else
                    count--;
            }
            data[countInitial - 1] = null;
        }

        public void Remove(int index)
        {
            ShiftLeft(index);
            count--;
            data[data.Length - 1] = null;
        }

        private void ShiftLeft(int index)
        {
            for (var i = index; i < data.Length - 1; i++)
                data[i] = data[i + 1];
        }

        public int GetCount()
        {
            return count;
        }
        public object[] GetData()
        {
            return data;
        }

       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ArrayEnum GetEnumerator()
        {
            
            return new ArrayEnum(data);
        }
    }
}
