using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace MyOOP
{
    public class DictionaryNet<Key, T>: ICollection
    {
        private int[] buckets= new int[50];
        private Entry[] entries = new Entry[50];

        private class Entry
        {
            public int? next;
            public int indexer;
            public Key key;
            public T value;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Entry entry in entries)
            {
                if(entry!=null)
                yield return entry;
            }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }

        public void Add(Key key, T newEntry)
        {
            var hash = CalculateHash(key);           
            var i = 0;

            if (buckets[hash] == 0)
            {
                buckets[hash] = hash;
                AddNewEntry(key, newEntry, hash, i);
            }
            else
            {
                i++;
                AddNewEntryUsingLinkLIst(key, newEntry, hash, i);                
            };
        }

        private void AddNewEntryUsingLinkLIst(Key key, T value, int hash, int i)
        {
            var newEntry = new Entry();
            newEntry.indexer = hash;
            newEntry.next=VerifyIfEntriesHaveNext(i, newEntry);
            newEntry.value = value;
            newEntry.key = key;
            entries[i] = newEntry;
        }

        private int? VerifyIfEntriesHaveNext(int i, Entry newEntry)
        {
            for (var j = i-1; j >= 0; j--)
                if (entries[j].indexer == newEntry.indexer)
                {
                    newEntry.next = entries[j].indexer;
                    return newEntry.next;
                }
            return null;
        }

        private void AddNewEntry(Key key, T value, int hash, int i)
        {
            var newEntry = new Entry();           
            newEntry.indexer=buckets[hash];
            newEntry.value = value;
            newEntry.key = key;
            newEntry.next = null;
            entries[i] = newEntry;
        }

        private int CalculateHash(Key key)
        {
            var hash = Math.Abs(key.GetHashCode());
            hash %= buckets.Length;
            return hash;
        }
    }
}