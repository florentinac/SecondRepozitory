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
    public delegate void Insert<T>(T referenceItem, T data, bool before);

    public class SimpleLinkList<T>:ICollection<T>,ICollection
    {
        private Node begin;
        private int count;

        public SimpleLinkList()
        {
            begin = new Node();
            count = 0;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            var addNode = NewNodeWithValue(item);

            addNode.next = begin.next;
            begin.next = addNode;
            count++;
        }

        public void AddLast(T data)
        {
            var toAdd = NewNodeWithValue(data);

            Node current = begin;
            InsertLastValue(current, toAdd);

        }

        public void Clear()
        {
            begin = null;
        }

        public bool Contains(T item)
        {
            for (var current = begin.next; current != null; current = current.next)
            {
                if (current.value.Equals(item))
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            for (var current = begin.next; current != null; current = current.next)
            {
                if (arrayIndex > array.Length - 1)
                    throw new ArgumentException();
                array[arrayIndex++] = current.value;
            }
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

        public void InsertItem(T referenceItem, T data, bool before)
        {
            var toInsert = NewNodeWithValue(data);
            Node nodePrevious;
            var found = FindElement(referenceItem, out nodePrevious);
            switch (before)
            {
                case true:
                    InsertElement(found ? nodePrevious : begin, toInsert);
                    break;
                case false:
                    InsertElement(found ? nodePrevious.next : begin, toInsert);
                    break;
            }
        }

        public void InsertBefore(T referenceItem, T data)
        {
            var toInsert = NewNodeWithValue(data);
            Node nodePrevious;
            var found = FindElement(referenceItem, out nodePrevious);
            InsertElement(found ? nodePrevious : begin, toInsert);
        }

        public void InsertAfter(T referenceItem, T data)
        {
            var toInsert = NewNodeWithValue(data);
            Node nodePrevious;
            var found = FindElement(referenceItem, out nodePrevious);
            InsertElement(found ? nodePrevious.next : begin, toInsert);
        }

        public bool Remove(T item)
        {

            for (var current = begin; current.next != null; current = current.next)
            {
                if (FindElementAndRemove(item, current)) return true;
            }
            return false;
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

        private static Node NewNodeWithValue(T data)
        {
            return new Node { value = data };

        }

        private static void UpdateNode(T newvalue, Node current)
        {
            current.value = newvalue;
        }

        private bool FindElement(T elementbefore, out Node nodePrevious)
        {
            for (var current = begin; current.next != null; current = current.next)
            {                
                if (current.next.Equals(elementbefore))
                {
                    nodePrevious = current;
                    return true;
                }
            }
            nodePrevious = null;
            return false;
        }

      
        private bool FindElementAndRemove(T item, Node current)
        {
            if (current.next.Equals(item))
            {
                current.next = current.next.next;
                count--;
                return true;
            }
            return false;
        }       

        private void InsertElement(Node node, Node toInsert)
        {
            toInsert.next = node.next;
            node.next = toInsert;
            count++;
        }

        private void InsertLastValue(Node current, Node toAdd)
        {
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = toAdd;
            count++;
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        private class EnumSimpleLinkList : IEnumerator<T>
        {
            private Node current;
            private SimpleLinkList<T> simpleLinkList;
            public EnumSimpleLinkList(SimpleLinkList<T> simpleLinkList)
            {
                this.simpleLinkList = simpleLinkList;
                Reset();

            }

            public T Current => current.value;

            object IEnumerator.Current => current.value;

            void IDisposable.Dispose() { }

            public bool MoveNext()
            {
                current = current?.next;
                return current != null;
            }

            public void Reset()
            {
                this.current = simpleLinkList.begin;
            }
        }

        private class Node
        {
            public Node next;
            public T value;
            public override bool Equals(object obj)
            {
                if (obj is T)
                {
                    var equals = value?.Equals(obj);
                    return equals.Value&&equals.HasValue;
                }
                if (obj is Node)
                {
                    var equals = next?.Equals(obj);
                    return equals.Value&&equals.HasValue;
                }
                return false;
            }
        }
    }
}
