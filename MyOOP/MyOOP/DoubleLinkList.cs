using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOP
{
    public class DoubleLinkList<T>:ICollection<T>
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
            guard.next = guard.prev;
            guard.prev = guard.next;
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

            toAdd.next = guard.prev;          
            toAdd.prev = guard.next;         
            guard.next = toAdd;                      
            count++;         
        }
        public void AddLast(T item)
        {
            var toAdd = new Node
            {
                value = item
            };

            toAdd.prev = guard.next;           
            toAdd.next = guard;
            guard.prev = toAdd;
            guard.next = toAdd;

            count++;
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
            throw new NotImplementedException();
        }

        public int Count => count;
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
                
                return current != null;
            }

            public void Reset()
            {
                current=doubleLinkList.guard;
            }
        }
    }
}
