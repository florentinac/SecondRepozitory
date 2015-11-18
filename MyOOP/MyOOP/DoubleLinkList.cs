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
        private delegate Node InsertDelegate(Node node);

        private void InsertElement(T referenceItem, T item, InsertDelegate insertDelegate)
        {
            Node nodePrevious;
            var found = FindElement(referenceItem, out nodePrevious);
            var toAdd = new Node(item);
            InsertElement(found ? insertDelegate(nodePrevious) : guard, toAdd);
        }

        
        public void InsertBefore(T referenceItem, T item)
        {
            InsertElement(referenceItem,item,(node)=>node.next);          
        }

        public void InsertAfter(T referenceItem, T item)
        {
            InsertElement(referenceItem, item, (node) => node);          
        }

        private void InsertElement(Node node, Node toAdd)
        {
            toAdd.next = node;
            toAdd.prev = node.prev;
            toAdd.prev.next = toAdd;
            node.prev = toAdd;

            count++;
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

        public void Clear()
        {
            guard=null;           
        }

        public bool Contains(T item)
        {
            Node nodePrevious;
            var found = FindElement(item, out nodePrevious);
            if (found)
                return true;            
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            for (var current = guard.next; current != guard; current = current.next)
            {
                if (arrayIndex > array.Length - 1)
                    throw new ArgumentException();
                array[arrayIndex++] = current.value;
            }
        }

        public bool Remove(T item)
        {
            Node nodePrevious;
            var found = FindElement(item, out nodePrevious);
            if (found)
            {
                RemoveNode(nodePrevious);
                return true;
            }            
            return false;
        }

        private void RemoveNode(Node node)
        {
            node.next = node.next.next;
            node.next.prev = node;
            count--;
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
