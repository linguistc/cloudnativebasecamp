using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DoublyList
{
    public class clsLinkedListNode <T>
    {
        public T Data;
        public clsLinkedListNode<T> Next;
        public clsLinkedListNode<T> Parent;

        // constructor for the node
        public clsLinkedListNode(T _Data)
        {
            this.Data = _Data;
            this.Next = null;
            this.Parent = null;
        }
    }

    public class clsLinkedListIterator <T>
    {
        private clsLinkedListNode<T> CurrentNode;

        // default constructor for the iterator
        public clsLinkedListIterator()
        {
            this.CurrentNode = null;
        }

        // constructor for the iterator with a starting node
        public clsLinkedListIterator(clsLinkedListNode<T> Head)
        {
            this.CurrentNode = Head;
        }

        // return the current node's data
        public T data()
        {
            return this.CurrentNode.Data;
        }

        // advance to the next node and return the iterator
        public clsLinkedListIterator<T> next()
        {
            this.CurrentNode = this.CurrentNode.Next;
            return this;
        }

        public clsLinkedListNode<T> Current()
        {
            return this.CurrentNode;
        }

    }


    public class clsLinkedList <T>
    {

        private int _Length;
        private bool _Unique;

        public clsLinkedListNode<T> Head;
        public clsLinkedListNode<T> Tail;
        public int Length
        {
            get { return this._Length; }
            set { this._Length = value; }
        }
        public bool Unique
        {
            get { return this._Unique; }
        }

        public clsLinkedList(bool unique = false)
        {
            this.Head = null;
            this.Tail = null;
            this.Length = 0;
            _Unique = unique;
        }

        public bool IsEmpty()
        {
            return this.Head == null;
        }

        public bool IsExist(T Data)
        {
            if (this.Find(Data) != null) return true;
            return false;
        }

        public bool CanInsert(T Data)
        {
            if (this.Unique && this.IsExist(Data))
            {
                Console.WriteLine("Item already exists!");
                return false;
            }
            return true;
        }

        public void InsertLast(T Data)
        {
            if (!this.CanInsert(Data)) return;

            clsLinkedListNode<T> NewNode = new clsLinkedListNode<T>(Data);
            if (IsEmpty())
            {
                this.Head = NewNode;
                this.Tail = NewNode;
            }
            else
            {
                NewNode.Parent = this.Tail;
                this.Tail.Next = NewNode;
                this.Tail = NewNode;
            }

            ++this.Length;
        }

        public void InsertAfter(T Target, T Data)
        {
            if (!this.CanInsert(Data)) return;

            clsLinkedListNode<T> Node = this.Find(Target);
            if (Node == null) return;

            clsLinkedListNode<T> NewNode = new clsLinkedListNode<T>(Data);

            NewNode.Next = Node.Next;
            NewNode.Parent = Node;
            Node.Next = NewNode;
            if (this.Tail == Node) // OR (NewNode.Next == null)
            {
                this.Tail = NewNode;
            }
            else
            {
                NewNode.Next.Parent = Node;
            }

            ++this.Length;
        }

        public void InsertBefore(T Target, T Data)
        {
            if (!this.CanInsert(Data)) return;

            clsLinkedListNode<T> Node = this.Find(Target);
            clsLinkedListNode<T> NewNode = new clsLinkedListNode<T>(Data);

            if (Node == null) return;

            NewNode.Next = Node;

            if (this.Head == Node)
            {
                this.Head = NewNode;
            }
            else
            {
                Node.Parent.Next = NewNode;
                NewNode.Parent = Node.Parent;
            }
            Node.Parent = NewNode;

            ++this.Length;

        }

        public void DeleteNode(T Data)
        {
            clsLinkedListNode<T> Node = this.Find(Data);

            if (Node == null) return;

            if (this.Head == this.Tail)
            {
                this.Head = this.Tail = null;

            }
            else if (this.Head == Node)
            {
                this.Head = Node.Next;
                this.Head.Parent = null;
                // Node.Next.Parent = null;
            }
            else if (this.Tail == Node)
            {
                this.Tail = Node.Parent;
                this.Tail.Next = null;
                // Node.Parent.Next = null;

            }
            else
            {
                Node.Next.Parent = Node.Parent;
                Node.Parent.Next = Node.Next;

                Node.Next = null;
                Node.Parent = null;
            }

            Node = null;
            --this.Length;
        }

        public clsLinkedList<T> CopyList()
        {
            clsLinkedList<T> CopiedList = new clsLinkedList<T>();
            for(clsLinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.next())
            {
                CopiedList.InsertLast(itr.data());
            }

            return CopiedList;
        }

        public clsLinkedListNode<T> Find(T Data)
        {
            for (clsLinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.next())
            {
                if (itr.Current().Data.Equals( Data ) )
                    return itr.Current();
            }
            return null;
        }



        public void PrintList()
        {
            for (clsLinkedListIterator<T> itr = this.Begin(); itr.Current() != null; itr.next())
            {
                Console.Write(itr.data() + " -> ");
            }
            Console.WriteLine("\n");
        }

        public clsLinkedListIterator<T> Begin()
        {
            return new clsLinkedListIterator<T>(this.Head);
        }

    }

}
