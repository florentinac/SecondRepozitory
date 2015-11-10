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

        public class Node<T>
        {
            public T value;
            public Node<T> next;

            public Node()
            {
                next = null;
                value = default(T);
            }
        }

        public SimpleLinkList()
        {
            begin = new Node<T>();
            count = 0;
        }

        public void AddLast(T data)
        {
            if (begin == null)
            {
                InsertFirstValue(data);
            }
            else
            {
                Node<T> toAdd=new Node<T>();
                toAdd.value = data;

                Node<T> current = begin;
                InsertLastValue(current, toAdd);
            }
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

        public void Insert2(T elementToFollow, T data)
        {
            if (begin == null && elementToFollow == null)
            {
                InsertFirstValue(data);
            }
            else
            {
                Node<T> toInsert = new Node<T>();
                toInsert.value = data;

                Node<T> current = begin;
                InsertElement(elementToFollow, current, toInsert);
            }
        }

        private void InsertElement(T elementToFollow, Node<T> current, Node<T> toInsert)
        {
            while (current.next != null)
            {
                if (current.value.Equals(elementToFollow))
                {
                    toInsert.next = current.next;
                    current.next = toInsert;
                    count++;
                }
                current = current.next;
            }
        }

        private void InsertFirstValue(T data)
        {
            begin = new Node<T>();

            begin.value = data;
            begin.next = null;
            count++;
        }

        public void Delete2(T n)
        {
            Node<T> current = begin;
            if (begin.value.Equals(n))
            {
                DeleteFirstElement(current);
            }
            else
            {
                while (current.next != null)
                {
                    if (current.next.value.Equals(n))
                    {
                        current = current.next.next;
                        count--;                       
                    }
                    if(current.next!=null)
                        current = current.next;          
                }
            }
        }

        private void DeleteFirstElement(Node<T> current)
        {
            begin = current.next;
            //current.next = current.next;
            count--;
        }

        public void Update(T n, T newvalue)
        {
            Node<T> current = begin;
            while (current.next != null)
            {
                if (current.value.Equals(n))
                {
                    UpdateNode(newvalue, current);
                }
                current = current.next;
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
            var addNode=new Node<T>();
            addNode.value = item;
            addNode.next = begin.next;
            begin.next = addNode;
           count++;

        }

        public void Clear()
        {
            throw new NotImplementedException();
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

            var found = false;
            for (var current = begin; current != null; current = current.next)
            {
                var next = current.next;
                var equals = next?.value.Equals(item);
                if (equals.Value && equals.HasValue)
                {
                    current.next = next.next;
                    found = true;
                    return found;
                }
            }             
            return found;
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
