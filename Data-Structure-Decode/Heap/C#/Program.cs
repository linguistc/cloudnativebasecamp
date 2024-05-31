using System;
using clsHeap;

internal class Program
{
    static void Main(string[] args)
    {
        Heap heap = new Heap();

        heap.insert(24);
        heap.insert(32);
        heap.insert(16);
        heap.insert(45);
        heap.insert(20);
        heap.insert(53);
        heap.insert(14);
        heap.insert(27);
        heap.Print();
        heap.Draw();

        Console.WriteLine(heap.pop());
        heap.Draw();
        Console.WriteLine(heap.pop());
        heap.Draw(); 
        Console.WriteLine(heap.pop());
        heap.Draw(); 
        Console.WriteLine(heap.pop());
        heap.Draw(); 
        Console.WriteLine(heap.pop());
        heap.Draw(); 
        Console.WriteLine(heap.pop());
        heap.Draw(); 
        Console.WriteLine(heap.pop());
        heap.Draw(); 
        Console.WriteLine(heap.pop());
        heap.Draw();

    }
}

