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

        public class Node<T>
        {
            public T value;
            public Node<T> next;           
           
        }       

        public void PrintAllNodes()
        {
            Node<T> current = begin;
            while (current != null)
            {             
                current = current.next;
            }
        }

        public void AddFirst(T data)
        {
            Node<T> toAdd=new Node<T>();
            toAdd.value = data;
            toAdd.next = begin;
           
            begin = toAdd;
            count++;

        }

        public void AddLast(T data)
        {
            if (begin == null)
            {
                begin = new Node<T>();

                begin.value = data;
                begin.next = null;
                count++;
            }
            else
            {
                Node<T> toAdd=new Node<T>();
                toAdd.value = data;

                Node<T> current = begin;
                while (current.next != null) 
                {
                    current = current.next;
                }
                current.next = toAdd;
                count++;
            }
        }

        public void Delete(T n)
        {
            Node<T> node = new Node<T>();
            node = begin;
            if (begin.value.Equals(n))
            {
                begin = node.next;
                node.next = null;
                count--;
            }
            else
            {
                Node<T> current = begin;
                while (current.next != null)
                {
                    if (current.value.Equals(n))
                    {
                        current.next = begin.next;
                        current.next = null;
                        break;
                    }
                    current = current.next;
                    
                }
                count--;
            }
        }

        public int GetCount()
        {
            return count;
        }



    }
}
