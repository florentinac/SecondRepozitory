using System;
using System.Collections;
using System.Collections.Generic;

namespace MyOOP
{
    public class DictionaryNet<Key, T>:ICollection
    {
        private int[] buckets= new int[50];
        private Entry[] entries = new Entry[50];

        private class Entry
        {
            public int next;
            public int indexer;
            public Key key;
            public T value;

            public Entry(int indexer, int next)
            {
                this.indexer = indexer;
                this.next = next;
            }
        }

        public DictionaryNet()
        {

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
    }
}