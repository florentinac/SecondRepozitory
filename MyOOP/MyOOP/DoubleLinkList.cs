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
        private Node<T> begin;
        private Node<T> last;
          
        private class Node<T>
        {
            public T value;
            public Node<T> next;
            public Node<T> prev;

        }

        public DoubleLinkList()
        {
            begin=new Node<T>();
            last=new Node<T>();
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
            var toAdd=new Node<T>();
            toAdd.value = item;

            toAdd.next = begin.next;
            toAdd.prev = last.next;
            begin.next = toAdd;
            last.prev = toAdd;
            count++;         
        }

        public void Clear()
        {
            begin=null;
            last = null;
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
            private Node<T> current; 

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
                current=doubleLinkList.begin;
            }
        }
    }
}
