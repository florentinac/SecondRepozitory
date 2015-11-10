using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyOOP
{
    public class SimpleLinkList<T>
    {
        private Node<T> begin;
        private int count;

        private class Node<T>
        {
            public T value;
            public Node<T> next;           
           
        }              

        public void Add(T data)
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

        public void Insert(T elementToFollow, T data)
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

        public void Delete(T n)
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



    }
}
