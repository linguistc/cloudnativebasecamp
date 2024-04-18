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

        Console.Write("[   ");
        for(i = 0; i < result.Length; ++i)
        {
            if (i > 0 && result[i] == 0) break;

            Console.Write(result[i] + "   ");
        }
        Console.Write("]\n");



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
