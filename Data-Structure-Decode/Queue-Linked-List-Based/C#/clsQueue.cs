using System;
using SinglyList;


namespace Queue
{
    public class clsQueue<T>
    {
        private clsLinkedList<T> _DataList;

        public clsQueue(bool unique = false)
        {
            this._DataList = new clsLinkedList<T>(unique);
        }

        public void Enqueue(T Data)
        {
            this._DataList.InsertLast(Data);
        }

        public T Dequeue()
        {
            if (this._DataList.Head == null)
                return default(T);

            T NodeData = this._DataList.Head.Data;

            this._DataList.DeleteHead();

            return NodeData;
        }

        public T Peek()
        {
            if(this._DataList.Head == null)
                return default(T);

            return this._DataList.Head.Data;
        }

        public bool HasData()
        {
            return this._DataList.HasData();

            //return !this._DataList.IsEmpty();
        }

        public int Size()
        {
            return this._DataList.Length;
        }

        public void PrintQueue()
        {
            this._DataList.PrintList();
        }


            
    }
}
