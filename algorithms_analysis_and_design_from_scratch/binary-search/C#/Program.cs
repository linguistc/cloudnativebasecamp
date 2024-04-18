using System;

internal class Program
{
    // This Algorithm is for sorted data only.
    static int binarysearch(int key, int[] arr)
    {
        int low = 0;
        int high = arr.Length - 1;
        int mid;

        while (low <= high)
        {
            mid = (low + high) / 2;
            if (key == arr[mid])
                return mid;
            else
            {
                if (key > arr[mid])
                    low = mid + 1;
                else
                    high = mid - 1;
            }
        }

        return -1;
    }  

    // f(n) = O( log(n) ) 

    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int ItemIndex = binarysearch(1, arr);

        Console.WriteLine(ItemIndex);
        Console.ReadKey();

    }
}