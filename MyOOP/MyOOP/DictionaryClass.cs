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
    }

    public class DictionaryClass<Key, T> : ICollection
    {
        private Bucket[] buckets = new Bucket[100];
        private int count;

        public class Entry
        {
            public Key key;
            public T value;

            public Entry(Key key, T value)
            {
                this.key = key;
                this.value = value;
            }
        }

        private class Bucket:ICollection<Entry>
        {           
            public List<Entry> data = new List<Entry>();            

            public void Add(Key key, T value)
            {
                data.Add(new Entry(key, value));
            }

            public IEnumerator GetEnumerator()
            {
                return data.GetEnumerator();
            }

            public void CopyTo(Array array, int index)
            {
                throw new NotImplementedException();
            }

            public void Add(Entry item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(Entry item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(Entry[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(Entry item)
            {
                throw new NotImplementedException();
            }

            IEnumerator<Entry> IEnumerable<Entry>.GetEnumerator()
            {
                foreach (var entry in data)
                {
                    yield return entry;
                }
            }

            public int Count { get; }
            public object SyncRoot { get; }
            public bool IsSynchronized { get; }

            public bool IsReadOnly
            {
                get
                {
                    throw new NotImplementedException();
                }
            }
        }     

        public IEnumerator GetEnumerator()
        {
            foreach(var bucket in buckets)
                if (bucket != null)
                {
                    foreach (var entry in bucket)
                    {
                        yield return ((Entry) entry).value;
                    }
                }           
        }

        public void Add(Key key, T newEntry)
        {
            var hash = CalculateHash(key);

            if (buckets[hash] == null)
            {
                AddToNewBucket(key, newEntry, hash);
            }
            else
            {
                AddNewEntryInExistentBucket(key, newEntry, hash);
            }
        }

        private void AddToNewBucket(Key key, T newEntry, int hash)
        {
            var newBucket = new Bucket();
            newBucket.Add(key, newEntry);
            buckets[hash] = newBucket;
            count++;
        }

        public bool ContainsKey(Key key)
        {
            var hash = CalculateHash(key);
            if (buckets[hash] == null)
                return false;
            foreach (Entry entry in buckets[hash])
            {
                if (entry.key.Equals(key))
                    return true;
            }
            return false;
        }

        public Entry Find(Key key)
        {
            int hash;
            var foundWord = FindWordWithHah(key, out hash);
            if (!foundWord) return default(Entry);
            var index = 0;
            foreach (Entry entry in buckets[hash])
            {              
                if (entry.key.Equals(key))
                    return entry;
            }
            return default(Entry);
        }

        private bool FindWordWithHah(Key name, out int hash)
        {
            hash = CalculateHash(name);
            return buckets[hash] != null;

        }

        private void AddNewEntryInExistentBucket(Key key,T newEntry, int hash)
        {
            buckets[hash].Add(key,newEntry);
            count++;
        }

        private int CalculateHash(Key key)
        { 
            var hash = Math.Abs(key.GetHashCode());
            hash %= buckets.Length;
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