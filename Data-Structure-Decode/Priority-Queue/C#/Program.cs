using System;

internal class Program
{
    static void Main(string[] args)
    {
        var pQueue = new PriorityQueue();

        pQueue.Enqueue(5, 24);
        pQueue.Enqueue(5, 32);
        pQueue.Enqueue(3, 16);
        pQueue.Enqueue(3, 45);
        pQueue.Enqueue(1, 20);
        pQueue.Enqueue(1, 53);
        pQueue.Enqueue(2, 14);
        pQueue.Enqueue(2, 27);

        pQueue.Print();
        pQueue.Draw();

        while (pQueue.HasData())
        {
            var result = pQueue.Dequeue();
            if (result.HasValue)
            {
                Console.WriteLine($"{result.Value.Item2}[{result.Value.Item1}]");
            }
        }
    }
}

