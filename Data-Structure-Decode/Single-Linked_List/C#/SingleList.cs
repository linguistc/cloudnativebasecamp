using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SingleList
{
    public class clsLinkedListNode
    {
        public int Data;
        public clsLinkedListNode Next;

        // constructor for the node
        public clsLinkedListNode(int _Data)
        {
            this.Data = _Data;
            this.Next = null;
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
        public clsLinkedListIterator(clsLinkedListNode node)
        {
            this.CurrentNode = node;
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

        public bool IsEmpty()
        {
            return this.Head == null;
        }

        public void InsertLast(int Data)
        {
            clsLinkedListNode NewNode = new clsLinkedListNode(Data);
            
            if(this.IsEmpty())
            {
                this.Head = NewNode;
                this.Tail = NewNode;
            }
            else
            {
                this.Tail.Next = NewNode;
                this.Tail = NewNode;
            }
            ++this._Length; 
        }
    
        public void InsertAfter(clsLinkedListNode Node, int Data)
        {
            if (Node == null) return;

            clsLinkedListNode NewNode = new clsLinkedListNode(Data);

            NewNode.Next = Node.Next;
            Node.Next = NewNode;

            if (this.Tail == Node) // OR if(NewNode.Next == null)
                this.Tail = NewNode;

            ++this._Length;
        }

        public void InsertBefore(clsLinkedListNode Node, int Data)
        {
            if(Node == null) return;

            clsLinkedListNode NewNode = new clsLinkedListNode(Data);
            NewNode.Next = Node;

            clsLinkedListNode Parent = this.FindParent(Node);
            if(Parent != null)
                Parent.Next = NewNode;
            else
                this.Head = NewNode;

        }

        public void DeleteNode(clsLinkedListNode Node)
        {
            if (Node == null) return;
            clsLinkedListNode Parent = this.FindParent(Node);

            if (this.Head == this.Tail)
            {
               this.Head = this.Tail = null;
            }
            else if(this.Head == Node)
            {
                this.Head = Node.Next;
                Node.Next = null;
            }
            else if(this.Tail == Node)
            {
                this.Tail = Parent;
                Parent.Next = null;                
            }
            else
            {
                Parent.Next = Node.Next;
                Node.Next = null;
            }

            Node = null;
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

        public clsLinkedListNode FindParent(clsLinkedListNode Node)
        {
            for (clsLinkedListIterator itr = this.Begin(); itr.Current() != null; itr.next())
            {
                if (itr.Current().Next == Node)
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
