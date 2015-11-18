using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyOOP
{
    public class DictionaryClass<Key, T>:ICollection
    {
        private Key key;
        private Library[] library=new Library[100];
        private int count = 0;
    

        private class Library
        {
            public T value;
            public List<T> bucket=new List<T>();

            public Library(T value)
            {
                this.value = value;
            }

            public void Add()
            {
                bucket.Add(value);
            }
        }

        public DictionaryClass(){ }    

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < 100; i++)
                if(library[i]!=null)
                   yield return library[i].value;
        }

        public void Add(Key name, T newEntry)
        {
            var hash = name.GetHashCode();
            hash %= library.Length;

            var newBucket = new Library(newEntry);
            newBucket.Add();
            library[hash] = newBucket;
            count++;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count => count;
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
        public bool IsReadOnly { get; }

        //public override bool Equals(object obj)
        //{
        //    if (obj is List<int>)
        //    {
        //        var equals = value?.Equals(obj);
        //        return equals.Value && equals.HasValue;
        //    }
        //    return false;
        //}
    }
}
