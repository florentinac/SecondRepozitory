using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyOOP
{
    public class DictionaryClass<Key, T> : ICollection
    {
        private Library[] library = new Library[100];
        private int count;

        private class Library
        {
            public T value;
            public List<T> bucket = new List<T>();

            public Library(T value)
            {
                this.value = value;
            }

            public void Add()
            {
                bucket.Add(value);
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < 100; i++)
                if (library[i] != null)
                    yield return library[i].value;
        }

        public void Add(Key name, T newEntry)
        {
            var hash = CalculateHash(name);

            if (library[hash] == null)
            {
                var newBucket = new Library(newEntry);
                AddValueInLibrary(newBucket, hash);
            }
            else
            {
                AddNewEntryInExistentBucket(newEntry, hash);
            }
        }

        private void AddValueInLibrary(Library newBucket, ulong hash)
        {
            newBucket.Add();
            library[hash] = newBucket;
            count++;
        }

        private void AddNewEntryInExistentBucket(T newEntry, ulong hash)
        {
            library[hash].bucket.Add(newEntry);
            count++;
        }

        private ulong CalculateHash(Key name)
        {
            var hash = (ulong)name.GetHashCode();
            hash %= (ulong)library.Length;
            return hash;
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

        public bool Find(Key name)
        {
            var hash = CalculateHash(name);
            if (library[hash] == null)
                return false;
            foreach (var words in library[hash].bucket)
            {
                if (words.Equals(name))
                    return true;
            }
            return false;
        }
    }
}