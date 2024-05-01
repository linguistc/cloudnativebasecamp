using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DoublyList
{
    public class clsLinkedListNode
    {
        public int Data;
        public clsLinkedListNode Next;
        public clsLinkedListNode Parent;

        // constructor for the node
        public clsLinkedListNode(int _Data)
        {
            this.Data = _Data;
            this.Next = null;
            this.Parent = null;
        }
    }

    public class clsLinkedListIterator
    {
        private clsLinkedListNode CurrentNode;

        // default constructor for the iterator
        public clsLinkedListIterator()
        {
            this.CurrentNode = null;
        }

        // constructor for the iterator with a starting node
        public clsLinkedListIterator(clsLinkedListNode Head)
        {
            this.CurrentNode = Head;
        }

        // return the current node's data
        public int data()
        {
            return this.CurrentNode.Data;
        }

        // advance to the next node and return the iterator
        public clsLinkedListIterator next()
        {
            this.CurrentNode = this.CurrentNode.Next;
            return this;
        }

        public clsLinkedListNode Current()
        {
            return this.CurrentNode;
        }

    }


    public class clsLinkedList
    {

        private int _Length;

        public clsLinkedListNode Head;
        public clsLinkedListNode Tail;
        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        public clsLinkedList()
        {
            this.Head = null;
            this.Tail = null;
            this.Length = 0;
        }

        public bool IsEmpty()
        {
            return this.Head == null;
        }

        public void InsertLast(int Data)
        {
            clsLinkedListNode NewNode = new clsLinkedListNode(Data);
            if(IsEmpty())
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
    
        public void InsertAfter(int Target, int Data)
        {
            clsLinkedListNode Node  = this.Find(Target);
            if (Node == null) return;

            clsLinkedListNode NewNode = new clsLinkedListNode(Data);
            
            NewNode.Next = Node.Next;
            NewNode.Parent = Node;
            Node.Next = NewNode;
            if(this.Tail == Node) // OR (NewNode.Next == null)
            {
                this.Tail= NewNode;
            }
            else
            {
                NewNode.Next.Parent = Node;
            }

            ++this.Length;
        }

        public void InsertBefore(int Target, int Data)
        {
            clsLinkedListNode Node = this.Find(Target);
            clsLinkedListNode NewNode = new clsLinkedListNode(Data);

            if (Node == null) return;

            NewNode.Next = Node;

            if(this.Head == Node)
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

        public void DeleteNode(int Data)
        {
            clsLinkedListNode Node = this.Find(Data);

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
       
        public clsLinkedListNode Find(int Data)
        {
            for(clsLinkedListIterator itr = this.Begin(); itr.Current() != null; itr.next())
            {
                if(itr.Current().Data == Data)
                    return itr.Current();
            }
            return null;
        }

        

        public void PrintList()
        {
            for(clsLinkedListIterator itr = this.Begin(); itr.Current() != null; itr.next())
            {
                Console.Write(itr.data() + " -> ");
            }
            Console.WriteLine("\n");
        }

        public clsLinkedListIterator Begin()
        {
            return new clsLinkedListIterator(this.Head);
        }
    
    }

}
