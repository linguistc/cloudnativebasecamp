using System;

    internal class Program
    {
        static void InsertionSort(int[] arr)
        {
            int i = 1, j, key;
            for(; i < arr.Length; ++i) 
            {
                j = i - 1;
                key = arr[i];
                while(j >= 0 && key < arr[j])
                {
                   
                    arr[j + 1] = arr[j];
                    
                    --j;
                }
                arr[j+1] = key;
            }
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("[");
            for(int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i]);
                if(i != arr.Length - 1)
                    Console.Write(", ");
            }
            Console.Write("]");
        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 4, 2, 29, 10, 7 };
            InsertionSort(arr);
            PrintArray(arr);
            Console.ReadKey();
        }
    }
