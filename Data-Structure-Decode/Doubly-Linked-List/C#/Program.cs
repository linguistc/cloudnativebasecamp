using System;
using DoublyList;

internal class Program
{
    static void Main(string[] args)
    {
        clsLinkedList<int> list = new clsLinkedList<int>(true);
        list.InsertLast(0);
        list.InsertLast(1);
        list.InsertLast(2);
        list.PrintList();
        Console.WriteLine(list.Length + " items\n\n");

        list.InsertLast(1);
        list.PrintList();
        list.DeleteNode(1);
        list.PrintList();
        list.InsertLast(1);
        list.PrintList();

        //clsLinkedList<int> Copy = new clsLinkedList<int>();
        //Copy = list.CopyList();
        //Console.WriteLine("Copied List");
        //Copy.PrintList();

        //list.InsertAfter(1, 98);
        //list.PrintList();
        //Console.WriteLine(list.Length + " items\n\n");


        //list.InsertBefore(1, 97);
        //list.PrintList();
        //Console.WriteLine(list.Length + " items\n\n");


        //list.DeleteNode(98);
        //list.PrintList();
        //Console.WriteLine(list.Length + " items\n\n");

        //list.DeleteNode(0);
        //list.PrintList();
        //Console.WriteLine(list.Length + " items\n\n");

        //Console.WriteLine("Head: " + list.Head.Data);


        //list.InsertBefore(10, 7777777);
        //list.PrintList();

        Console.ReadKey();
    }
}
