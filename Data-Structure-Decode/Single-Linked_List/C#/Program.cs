using System;
using SinglyList;

internal class Program
{
    static void Main(string[] args)
    {
        clsLinkedList<int> list = new clsLinkedList<int>();
        list.InsertLast(0);
        list.InsertLast(1);
        list.InsertLast(2);
        list.PrintList();
        Console.WriteLine(list.Length + " items");

        list.InsertAfter(1, 98);
        list.PrintList();
        Console.WriteLine(list.Length + " items");


        list.InsertBefore(1, 97);
        list.PrintList();
        Console.WriteLine(list.Length + " items");


        list.DeleteNode(98);
        list.PrintList();
        Console.WriteLine(list.Length + " items");

        list.DeleteNode(0);
        list.PrintList();
        Console.WriteLine(list.Length + " items");

        Console.WriteLine("Head: "+ list.Head.Data);


        list.InsertBefore(10, 7777777);
        list.PrintList();

        Console.ReadKey();
    }
}
