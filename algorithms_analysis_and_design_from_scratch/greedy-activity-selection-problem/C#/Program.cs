using System;
using System.Linq;

internal class Program
{

    static void GreedyActivitySelection(int[] start, int[] end)
    {
        int[] result = new int[start.Length];
        result[0] = 0;
        int i = 1, j = 0, k = 1;

        for(; i < start.Length; ++i)
        {
            if (start[i] >= end[j])
            {
                result[k++] = i;
                j = i;
            }
        }

        Console.WriteLine("[" + String.Join(", ", result) + "]");
    }

    // f(n) = O(n)

    static void Main(string[] args)
    {
        int[] start = { 9, 10, 11, 12, 13, 15 };
        int[] end = { 11, 11, 12, 14, 15, 16 };

        GreedyActivitySelection(start, end);

        Console.ReadKey();
    }
}
