using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace MyOOP
{
    public class DictionaryNet<Key, T>
    {
        private int[] buckets = new int[50];
        private Entry[] entries = new Entry[50];
        private IHash<Key> hasher;
        private int count;
        private int newEntry;
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

        public DictionaryNet()
        {
            SetInitialValueForBuckets();
            hasher = new ClassIHasher<Key>();
        }

        public DictionaryNet(IHash<Key> hasher)
        {
            SetInitialValueForBuckets();
            this.hasher = hasher;
        }

        private void SetInitialValueForBuckets()
        {
            for (var i = 0; i < buckets.Length; i++)
                buckets[i] = -1;
        }

        public void Add(Key key, T value)
        {
            var hash = CalculateHash(key);
            if (buckets[hash] == -1)
            {
                AddDelegate(key,value,hash,()=>-1);
            }
            else
            {
                AddDelegate(key, value, hash, () => buckets[hash]);
            }
        }

        private delegate int DelegateNext();
        private void AddDelegate(Key key, T value, int hash, DelegateNext delegateNext)
        {
            var newEntries = new Entry(key, value);
            newEntries.next = delegateNext();
            buckets[hash] = newEntry;
            entries[newEntry++] = newEntries;
            count++;
        }

        private int CalculateHash(Key key)
        {
            var hash = hasher.GetHashCode(key);          
            hash %= buckets.Length;
            return hash;
        }

        public int GetCount => count;

        public T ContainsKey(Key keyToFaind)
        {
            var hash = CalculateHash(keyToFaind);
            if (buckets[hash] == -1) return default(T);
           
            return VerifyNext(buckets[hash],keyToFaind);
        }

        private T VerifyNext(int nextValue, Key keyToFaind)
        {
            if (entries[nextValue].key.Equals(keyToFaind))
                return entries[nextValue].value;
            if (nextValue > 0)
                return VerifyNext(entries[nextValue].next, keyToFaind);
            return default(T);
        }
    }

    public class ClassIHasher<T> : IHash<T>
    {
        public int GetHashCode(T obj)
        {
            var hash = Math.Abs(obj.GetHashCode());
            return hash;
        }
    }


}