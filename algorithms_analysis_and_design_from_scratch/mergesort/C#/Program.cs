using System;

internal class Program
{

    public static void merge(int[] array, int start, int midPoint, int end)
    {
        int left_lenght = midPoint - start + 1;
        int right_lenght = end - midPoint;

        int[] left_array = new int[left_lenght];
        int[] right_array = new int[right_lenght];

        int i, j, k;

        for (i = 0; i < left_lenght; ++i)
            left_array[i] = array[start + i];

        for (i = 0; i < right_lenght; ++i)
            right_array[i] = array[midPoint + 1 + i];

        i = 0;
        j = 0;
        k = start;

        while (i < left_lenght && j < right_lenght)
        {
            if (left_array[i] < right_array[j])
                array[k] = left_array[i++];
            else
                array[k] = right_array[j++];
            ++k;
        }

        while (i < left_lenght)
        {
            array[k++] = left_array[i++];
        }
        while (j < right_lenght)
            array[k++] = right_array[j++];
    }

    public static void mergeSort(int[] array, int start, int end)
    {
        if (end <= start) return;
        int midPoint = (end + start) / 2;

        mergeSort(array, start, midPoint);
        mergeSort(array, midPoint + 1, end);
        merge(array, start, midPoint, end);
    }

    static void Main(string[] args)
    {
        int[] array = { 1, 4, 2, 29, 10, 7 };
        Console.WriteLine("[" + String.Join(", ", array) + "]");
        mergeSort(array, 0, array.Length - 1);
        Console.WriteLine("[" + String.Join(", ", array) + "]");

        Console.ReadKey();


    }
}

