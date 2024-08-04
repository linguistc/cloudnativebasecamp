using System;
using Queue;

internal class Program
{
    static void Main(string[] args)
    {
        clsQueue<char> queue = new clsQueue<char>(true);

        Console.WriteLine(queue.HasData());

        queue.Enqueue('A');
        queue.Enqueue('h');
        queue.Enqueue('m');
        queue.Enqueue('e');
        queue.Enqueue('d');

        Console.WriteLine(queue.HasData());

        queue.PrintQueue();

        while (queue.HasData())
        {
            Console.WriteLine("Peek: " + queue.Peek());
            Console.WriteLine("Dequeue: " + queue.Dequeue());
            Console.WriteLine("Size: " + queue.Size());
            queue.PrintQueue();
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}

