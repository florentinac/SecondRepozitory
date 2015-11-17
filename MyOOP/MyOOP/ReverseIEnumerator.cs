using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOOP
{
    //class ReverseIEnumerator<T> : IEnumerable<T>
    //{


    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        return new ReverseEnum(this);
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }

    //    private class ReverseEnum : IEnumerator<T>
    //    {
    //        private DoubleLinkList<T> doubleLinkList;
    //        private Node current;

    //        public ReverseEnum(DoubleLinkList<T> doubleLinkList)
    //        {
    //            this.doubleLinkList = doubleLinkList;
    //            Reset();
    //        }

    //        public T Current => current.value;

    //        object IEnumerator.Current => current.value;

    //        public void Dispose()
    //        {
    //        }

    //        public bool MoveNext()
    //        {

    //            current = current?.prev;

    //            return current != doubleLinkList.guard;
    //        }

    //        public void Reset()
    //        {
    //            current = doubleLinkList.guard;
    //        }
    //    }
    //}
}
