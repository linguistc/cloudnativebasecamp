using System;
using clsSinglyList;

namespace clsStack
{
    public class clsStack <T>
    {
        private clsLinkedList<T> _DataList;
        public clsStack(bool unique = false)
        {
            this._DataList = new clsLinkedList<T>(unique);
        }

        public void Push(T item)
        {
            this._DataList.InsertFirst(item);
        }

        public T Pop()
        {
            T HeadData = this._DataList.Head.Data;
            this._DataList.DeleteHead();
            return HeadData;
        }

        public T Beek()
        {
            return this._DataList.Head.Data;
        }

        public int Size()
        {
            return this._DataList.Length;
        }
        public bool IsEmpty()
        {
            return this._DataList.IsEmpty();
        }

        public void PrintStack()
        {
            this._DataList.PrintList();
        }

    }
}
