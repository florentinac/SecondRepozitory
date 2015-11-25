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
        private int newNext;
        private int freeIndex = -1;

        private class Entry
        {
            public int next;
            public Key key;
            public T value;
            public int prev = 0;

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
            if(IsFreeIndexAdd(key, value, hash))
                return;           
            if (buckets[hash] == -1)
            {
                AddEntry(key,value,hash,-1);
            }
            else
            {
                AddEntry(key, value, hash, buckets[hash]);
            }
        }

        private bool IsFreeIndexAdd(Key key, T value, int hash)
        {
            if (freeIndex != -1)
            {
                var newEntries = new Entry(key, value, entries[freeIndex].next);
                VerifyPrevOfFreeIndex(hash);
                entries[freeIndex] = newEntries;
                count++;
                return true;
            }
            return false;
        }

        private void VerifyPrevOfFreeIndex(int hash)
        {
            if (entries[freeIndex].prev > 0)
                SetLinks();
            else
                SetBucketsValue(hash);
        }

        private void SetBucketsValue(int hash)
        {
            buckets[hash] = freeIndex;
        }

        private void SetLinks()
        {
            entries[entries[freeIndex].prev].next = freeIndex;
        }

        private void AddEntry(Key key, T value, int hash, int next)
        {
            var newEntries = new Entry(key, value, next);            
            buckets[hash] = newNext;
            entries[newNext++] = newEntries;
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
                var next = -1;          
                VerifyNext(buckets[hash], keyToFind, out result, out next);
                return result;
            }

        }

        public bool ContainsKey(Key keyToFind)
        {
            var hash = CalculateHash(keyToFind);
            if (buckets[hash] == -1) return false;
            var result =default(T);
            var next=-1;           
            return VerifyNext(buckets[hash], keyToFind, out result, out next);

        }

        private bool VerifyNext(int nextValue, Key keyToFaind, out T result, out int next)
        {
            if (nextValue >= 0)
            {
                if (entries[nextValue].key.Equals(keyToFaind))
                {                
                    next = nextValue;
                    result = entries[nextValue].value;
                    return true;
                }
                if (nextValue > 0)
                {
                    entries[entries[nextValue].next].prev = nextValue;                               
                    VerifyNext(entries[nextValue].next, keyToFaind, out result, out next);                    
                    return true;
                }
            }           
            next = -1;
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
                RemoveEntry(buckets[hash]);
                SetNewValueForBucket(hash);
                return;
            }
            var next = -1;
            var result = default(T);
           
            VerifyNext(buckets[hash], key, out result, out next);
            RemoveEntry(next);
        }

        private void SetNewValueForBucket(int hash)
        {
            if (!Equals(entries[buckets[hash]].next, -1))
                buckets[hash] = entries[buckets[hash]].next;
            else
                buckets[hash] = -1;
        }

        private void RemoveEntry(int pos)
        {
            freeIndex = pos;
            if(entries[freeIndex].prev > 0)
                  entries[entries[freeIndex].prev].next = entries[freeIndex].next;          
            count--;
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