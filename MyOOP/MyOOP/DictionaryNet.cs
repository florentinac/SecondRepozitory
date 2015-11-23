using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
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
            public int next;
            public Key key;
            public T value;

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
                AddEntry(key,value,hash,-1);
            }
            else
            {
                AddEntry(key, value, hash, buckets[hash]);
            }
        }     
        private void AddEntry(Key key, T value, int hash, int next)
        {
            var newEntries = new Entry(key, value, next);            
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

        public T this[Key keyToFind]
        {
            get
            {
                var hash = CalculateHash(keyToFind);
                if (buckets[hash] == -1) return default(T);
                var result = default(T);
                VerifyNext(buckets[hash], keyToFind, out result);
                return result;
            }

        }

        public bool ContainsKey(Key keyToFind)
        {
            var hash = CalculateHash(keyToFind);
            if (buckets[hash] == -1) return false;
            var result =default(T);
            return VerifyNext(buckets[hash], keyToFind, out result);

        }

        private bool VerifyNext(int nextValue, Key keyToFaind, out T result)
        {
            if (nextValue >= 0)
            { 
                if (entries[nextValue].key.Equals(keyToFaind))
                {
                    result = entries[nextValue].value;
                    return true;
                }
            if (nextValue > 0)
            {
                VerifyNext(entries[nextValue].next, keyToFaind, out result);
            }
            }
            result = default(T);
            return false;
        }

        public void Remove(Key key)
        {
            var hash = CalculateHash(key);
            if (buckets[hash] == -1)
                throw new ArgumentException();

            if (entries[buckets[hash]].key.Equals(key))
            {
                RemoveEntry(hash,buckets[hash]);
                return;
            }  
            VerifyNextAndRemoveEntry(key, hash);
        }

        private void RemoveEntry(int hash, int pos)
        {
            freeIndex = pos;
            buckets[hash] = entries[pos].next;
            count--;
        }

        private void VerifyNextAndRemoveEntry(Key key, int hash)
        {
            for (var i = entries[buckets[hash]].next; i >= 0; i = entries[i].next)
                if (entries[i].key.Equals(key))
                {
                    RemoveEntry(hash,i);                   
                }
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