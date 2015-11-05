﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Array;

namespace MyOOP
{
    public class ArrayClass : IEnumerable
    {
        public ArrayClass()
        {
            this.data = new object[8];
            this.count = 0;
        }

        public ArrayClass(object[] data, int count)
        {
            var copyData = new object[data.Length];
            Copy(data, copyData, data.Length);        
            this.data = copyData;
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
            if(position<data.Length)
            { 
                ShiftRight(position);
                InsertElement(newElement, position);              
            }
        }

        private void InsertElement(object newElement, int position)
        {

            data[position] = newElement;
            count++;
        }

        private void ShiftRight(int position)
        {

            for (var i = count; i >= position; i--)
                data[i] = data[i - 1];
        }

        public object GetElemenetAt(int position)
        {
            if(position<data.Length)
                return data[position];
            return null;
        }

        public int GetPosition(object element)
        {
            var position = -1;
            for (var i=0;i<count;i++)
                if (data[i].Equals(element))
                    return i;
            return position;
        }

        public void Remove(object elementToRemove)
        {           
            var index = GetPosition(elementToRemove);

            if (index>-1)                
                Remove(index);                  
        }

        public void Remove(int index)
        {
            if (index < data.Length)
            {
                ShiftLeft(index);
                count--;
                data[data.Length - 1] = null;
            }
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
       
        public IEnumerator GetEnumerator()
        {
            return new ArrayEnum(this);
        }

        
    }
}
