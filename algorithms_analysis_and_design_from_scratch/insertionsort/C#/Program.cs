using System;

internal class Program
{
    static void InsertionSort(int[] arr)
    {
        int i = 1, j, key;
        for (; i < arr.Length; ++i)
        {
            j = i - 1;
            key = arr[i];
            while (j >= 0 && key < arr[j])
            {

                arr[j + 1] = arr[j];

                --j;
            }
            arr[j + 1] = key;
        }
    }

   
    static void Main(string[] args)
    {
        int[] arr = { 1, 4, 2, 29, 10, 7 };
        Console.WriteLine("[" + String.Join(", ", arr) + "]");
        InsertionSort(arr);
        Console.WriteLine("[" + String.Join(", ", arr) + "]");
        Console.ReadKey();
    }
}
