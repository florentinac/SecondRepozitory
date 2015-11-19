using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyOOP
{
    public class NewEntry
    {
        public string Name;
        public string Description;

        public NewEntry(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public override bool Equals(object obj)
        {
            var words = new NewEntry("mar", "Este un mar");
            if (obj is NewEntry)
            {                
                return words.Equals(obj);
            }
            if (obj is string)
            {
                var equals = words.Name?.Equals(obj);
                return equals.Value && equals.HasValue;
            }
            return false;
        }
    }

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
            public override bool Equals(object obj)
            {
                var words = new NewEntry("mar", "Este un mar");
                if (obj is NewEntry)
                {
                    var equals = words.Name?.Equals(obj);
                    return equals.Value && equals.HasValue;
                }
                return false;
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

        public T FindWord(Key name)
        {
            ulong hash;
            var foundWord = FindWordWithHah(name, out hash);
            if (!foundWord) return default(T);
            var index = 0;
            foreach (var words in library[hash].bucket)
            {
                if (words.Equals(name))
                    return library[hash].bucket[index];
                index++;
            }
            return default(T);
        }

        private bool FindWordWithHah(Key name, out ulong hash)
        {
            hash = CalculateHash(name);
            return library[hash] != null;

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

        

    }
}