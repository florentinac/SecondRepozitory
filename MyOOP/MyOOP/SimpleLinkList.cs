using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyOOP
{
    public class SimpleLinkList<T>:ICollection<T>
    {
        private Node<T> begin;
        private int count;

        private class Node<T>
        {
            public T value;
            public Node<T> next;
         
        }

        public SimpleLinkList()
        {
            begin = new Node<T>();
            count = 0;
        }

        public void AddLast(T data)
        {         
            var toAdd= NewNodeWithValue(data);

            Node<T> current = begin;
            InsertLastValue(current, toAdd);
           
        }

        private static Node<T> NewNodeWithValue(T data)
        {
            Node<T> toInsert = new Node<T>();
            toInsert.value = data;
            return toInsert;
        }

        private void InsertLastValue(Node<T> current, Node<T> toAdd)
        {
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = toAdd;
            count++;
        }

        public void InsertRight(T elementToFollow, T data)
        {          
            var toInsert = NewNodeWithValue(data);

            Node<T> current = begin;
            InsertElement(elementToFollow, current, toInsert);
            
        }     

        private void InsertElement(T referenceElement, Node<T> current, Node<T> toInsert)
        {
            while (current.next != null)
            {
                if (current.value.Equals(referenceElement))
                {
                    toInsert.next = current.next;
                    current.next = toInsert;
                    count++;
                }
                current = current.next;
            }
        }

        public void Update(T n, T newvalue)
        {
            for (var current = begin; current != null; current = current.next)
            {
                if (current.value.Equals(n))
                {
                    UpdateNode(newvalue, current);
                }               
            }
        }

        private static void UpdateNode(T newvalue, Node<T> current)
        {
            current.value = newvalue;
        }

        public int GetCount()
        {
            return count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumSimpleLinkList(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {           
            var addNode= NewNodeWithValue(item);

            addNode.next = begin.next;
            begin.next = addNode;
            count++;
        }

        public void Clear()
        {
            begin=null;
        }

        public bool Contains(T item)
        {
            for (var current = begin.next; current!=null; current = current.next)
            {               
                if (current.value.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (var current = begin.next; current!= null; current = current.next)
            {
                array[arrayIndex++] = current.value;
            }          
        }

        public bool Remove(T item)
        {
            
            for (var current = begin; current.next != null; current = current.next)
            {            
                if (FoundElement(item, current)) return true;
            }             
            return false;
        }

        private bool FoundElement(T item, Node<T> current)
        {
            if (current.next.value.Equals(item))
            {
                current.next = current.next.next;
                count--;
                return true;
            }
            return false;
        }

        public int Count => count;
        public bool IsReadOnly => false;

        private class EnumSimpleLinkList : IEnumerator<T>
        {
            private SimpleLinkList<T> simpleLinkList;
            private Node<T> current;           

            public EnumSimpleLinkList(SimpleLinkList<T> simpleLinkList)
            {
                this.simpleLinkList = simpleLinkList;
                Reset();               
              
            }            

            public bool MoveNext()
            {
                current=current?.next;
                return current != null;
            }

            public void Reset()
            {             
                this.current=simpleLinkList.begin;
            }

            void IDisposable.Dispose() { }

            public T Current => current.value;

            object IEnumerator.Current => current.value;
        }
    }
}
