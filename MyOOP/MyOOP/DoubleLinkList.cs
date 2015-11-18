using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
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

        public DoubleLinkList()
        {
            guard = new Node();
            guard.next = guard;
            guard.prev = guard;
            count = 0;
        }

        private delegate Node InsertDelegate(Node node);

        public int Count => count;

        public bool IsReadOnly { get; }

        public bool IsSynchronized { get; }

        public object SyncRoot { get; }

        public void Add(T item)
        {
            var toAdd = new Node(item);

            toAdd.prev = guard;
            toAdd.next = guard.next;
            toAdd.next.prev = toAdd;
            guard.next = toAdd;

            count++;
        }

        public void Clear()
        {
            guard = null;
        }

        public bool Contains(T item)
        {
            Node nodePrevious;
            return FindElement(item, out nodePrevious);         
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ValidatesParameters(array, arrayIndex);
            for (var current = guard.next; current != guard; current = current.next)
            {                
                array[arrayIndex++] = current.value;
            }
        }

        private void ValidatesParameters(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (count > array.Length - arrayIndex)
                throw new ArgumentException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoubleLinkListEnum(this);
        }

        public IEnumerable<T> GetReverseEnumerable()
        {
            for (var current = guard.prev; current != guard; current = current.prev)
            {
                 yield return current.value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void InsertAfter(T referenceItem, T item)
        {
            InsertElement(referenceItem, item, (node) => node);
        }

        public void InsertBefore(T referenceItem, T item)
        {
            InsertElement(referenceItem, item, (node) => node.next);
        }

        public bool Remove(T item)
        {
            Node nodePrevious;           
            if (!FindElement(item, out nodePrevious)) return false;
            RemoveNode(nodePrevious);               
            return true;
        }

        private bool FindElement(T referenceItem, out Node nodePrevious)
        {
            for (var current = guard.next; current != guard; current = current.next)
            {
                if (current.value.Equals(referenceItem))
                {
                    nodePrevious = current.prev;
                    return true;
                }
            }
            nodePrevious = null;
            return false;
        }

        private void InsertElement(T referenceItem, T item, InsertDelegate insertDelegate)
        {
            Node nodePrevious;
            var found = FindElement(referenceItem, out nodePrevious);
            var toAdd = new Node(item);
            InsertElementAt(found ? insertDelegate(nodePrevious) : guard, toAdd);
        }

        private void InsertElementAt(Node node, Node toAdd)
        {
            toAdd.next = node;
            toAdd.prev = node.prev;
            toAdd.prev.next = toAdd;
            node.prev = toAdd;

            count++;
        }

        private void RemoveNode(Node node)
        {
            node.next = node.next.next;
            node.next.prev = node;
            count--;
        }

        private class DoubleLinkListEnum : IEnumerator<T>
        {
            private Node current;
            private DoubleLinkList<T> doubleLinkList;
            public DoubleLinkListEnum(DoubleLinkList<T> doubleLinkList)
            {
                this.doubleLinkList = doubleLinkList;
                Reset();
            }

            public T Current => current.value;

            object IEnumerator.Current => current.value;

            public void Dispose(){}

            public bool MoveNext()
            {
                current = current?.next;

                return current != doubleLinkList.guard;
            }

            public void Reset()
            {
                current = doubleLinkList.guard;
            }
        }

        private class Node
        {
            public Node next;
            public Node prev;
            public T value;

            public Node(){}

            public Node(T value)
            {
                this.value = value;
            }
        }
    }
}
