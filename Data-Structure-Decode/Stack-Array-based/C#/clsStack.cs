using System;

namespace clsStack
{

    public class clsStack<T>
    {
        private T[] _DataList;
        private int _Top;
        private int _InitialSize;

        public clsStack()
        {
            this._InitialSize = 3;
            this._DataList = new T[this._InitialSize];
            this._Top = -1;
        }

        public void ResizeOrNot()
        {
            if (this._Top < this._DataList.Length - 1)
                return;

            Console.WriteLine("Will be resized.");

            T[] NewArray = new T[this._DataList.Length + this._InitialSize];

            this._DataList.CopyTo(NewArray, 0);
            this._DataList = null;
            this._DataList = NewArray;
        }

        public void Push(T Item)
        {
            this.ResizeOrNot();

            this._DataList[++this._Top] = Item;
        }

        public T Beek()
        {
            if (this.IsEmpty()) return (T)(object)-1;

            return this._DataList[this._Top];
        }
        public T Pop()
        {
            if (this.IsEmpty()) return (T)(object)-1;

            T HeadData = this._DataList[this._Top];
            this._DataList[this._Top] = default(T);
            --this._Top;
            return HeadData;
        }

        public bool IsEmpty()
        {
            return this._Top == -1;
        }

        public int Size()
        {
            return this._Top + 1;
        }

        public void PrintStack()
        {
            for (int i = this._Top; i > -1; --i)
                Console.Write(this._DataList[i] + " -> ");
            Console.WriteLine();

        }


    }

}
