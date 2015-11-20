using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace MyOOP
{
    public class DictionaryNet<Key, T>
    {
        private int[] buckets= new int[50];
        private Entry[] entries = new Entry[50];
        private int count = 0;
        private int newEntry = 0;
        private int freeIndex = -1;

        private class Entry
        {
            public int next = -1;
            public Key key;
            public T value;

            public Entry(Key key, T value)
            {
                this.key = key;
                this.value = value;
            }

            public Entry(Key key, T value, int next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }

        public void DictionaryClass()
        {
            for (var i = 0; i < buckets.Length; i++)
                buckets[i] = -1;
        }
    

        public void Add(Key key, T value)
        {
            var hash = CalculateHash(key);
            if (buckets[hash] == -1)
            {
                var newEntries = new Entry(key,value);
                buckets[hash] = newEntry;
                entries[newEntry++] = newEntries;                
                count++;                
            }
        }

        private int CalculateHash(Key key)
        {
            var hash = Math.Abs(key.GetHashCode());
            hash %= buckets.Length;
            return hash;
        }

        public int GetCount => count;

        public T ContainsKey(Key keyToFaind)
        {
            var hash = CalculateHash(keyToFaind);
            if (buckets[hash] == -1) return default(T);
            return entries[buckets[hash]].key.Equals(keyToFaind) ? entries[buckets[hash]].value : default(T);
        }
    }
}