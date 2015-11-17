using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyOOP
{
    public class DoubleLinkList<T>:ICollection<T>,ICollection
    {
        private int count;
        private Node guard;   
          
        private class Node
        {
            public T value;
            public Node next;
            public Node prev;

            public Node()
            {

            }

            public Node(T value)
            {
                this.value = value;
            }
        }

        public DoubleLinkList()
        {
            guard = new Node();
            guard.next = guard;
            guard.prev = guard;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoubleLinkListEnum(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            var toAdd = new Node(item);
           
            toAdd.prev = guard;
            toAdd.next = guard.next;
            toAdd.next.prev = toAdd;
            guard.next = toAdd;                       
            
            count++;         
        }

        public void Insert(T referenceItem, T item)
        {
            Node nodePrevious;
            var found = FindElement(referenceItem, out nodePrevious);
            var toAdd = new Node(item);
            InsertBefore(found ? nodePrevious : guard, toAdd);
        }

        private void InsertBefore(Node nodePrevious, Node toAdd)
        {
            toAdd.next = nodePrevious;
            toAdd.prev = nodePrevious.prev;
            toAdd.prev.next = toAdd;
            nodePrevious.prev = toAdd;

            count++;
        }

        private bool FindElement(T referenceItem, out Node nodePrevious)
        {
            for (var current = guard; current.next != guard; current = current.next)
            {
                if (current.value.Equals(referenceItem))
                {
                    nodePrevious = current;
                    return true;
                }
            }
            nodePrevious = null;
            return false;
        }

        public void Clear()
        {
            guard=null;           
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

            for (var current = guard; current.next != guard; current = current.next)
            {
                if (FindElementAndRemove(item, current)) return true;
            }
            return false;
        }

        private bool FindElementAndRemove(T item, Node current)
        {
            if (current.next.value.Equals(item))
            {
                current.next = current.next.next;
                current.next.prev = current;
                count--;
                return true;
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count => count;
        public object SyncRoot { get; }
        public bool IsSynchronized { get; }
        public bool IsReadOnly { get; }

        private class DoubleLinkListEnum : IEnumerator<T>
        {
            private DoubleLinkList<T> doubleLinkList;
            private Node current; 

            public DoubleLinkListEnum(DoubleLinkList<T> doubleLinkList)
            {
                this.doubleLinkList = doubleLinkList;
                Reset();
            }

            public T Current => current.value;

            object IEnumerator.Current => current.value;

            public void Dispose()
            {                
            }

            public bool MoveNext()
            {
                
                current = current?.next;                            
                
                return current != doubleLinkList.guard;
            }

            public void Reset()
            {
                current=doubleLinkList.guard;
            }
        }

        public IEnumerable<T> GetReverseEnumerable()
        {
            for (var current = guard.prev; current != guard; current = current.prev)
            {
                yield return current.value;
            }
        }
    }
}
