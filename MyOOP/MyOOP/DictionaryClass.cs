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
        private T value;
        private Key key;
        private List<Library> library;
        private int count = 100;

        private class Library
        {
            public T value;
            public List<T> bucket;

            public void Add()
            {
                bucket.Add(value);
            }
        }

        public DictionaryClass(){ }

        public DictionaryClass(Key key, T value)
        {
            this.key = key;
            this.value=value;
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < count; i++)
                if(library!=null)
                   yield return library[i].value;
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

        public int Count { get; }
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
        public bool IsReadOnly { get; }

        public override bool Equals(object obj)
        {
            if (obj is List<int>)
            {
                var equals = value?.Equals(obj);
                return equals.Value && equals.HasValue;
            }
            return false;
        }
    }
}
