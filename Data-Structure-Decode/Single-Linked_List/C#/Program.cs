using System;
using SingleList;

internal class Program
{
    static void Main(string[] args)
    {
        clsLinkedList list = new clsLinkedList();
        list.InsertLast(0);
        list.InsertLast(1);
        list.InsertLast(2);
        list.PrintList();

        list.InsertAfter(list.Find(1), 98);
        list.PrintList();

        list.InsertBefore(list.Find(1), 97);
        list.PrintList();

        list.InsertBefore(list.Find(10), 7777777);
        list.PrintList();
        list.DeleteNode(list.Find(97));
        list.PrintList();
        list.DeleteNode(list.Find(0));
        list.PrintList();
        Console.WriteLine(list.Head.Data);

        Console.ReadKey();
    }
}
