using System;


internal class Program
{
    public static void merge(int[] arr, int start, int midPoint, int end)
    {
        int leftLength = midPoint - start + 1;
        int rightLength = end - midPoint;

        int[] leftArray = new int[leftLength];
        int[] rightArray = new int[rightLength];

        int i, j, k;

        for (i = 0; i < leftLength; ++i)
            leftArray[i] = arr[start+i];

        for (i = 0; i < rightLength; ++i)
            rightArray[i] = arr[midPoint + 1 + i];

        i = 0; 
        j = 0;
        k = start;

        // Checking the left array first and moving the negative numbers
        while (i < leftLength && leftArray[i] < 0)
            arr[k++] = leftArray[i++];

        // then checking negative in right array
        while (j < rightLength && rightArray[j] < 0)
            arr[k++] = rightArray[j++];

        // moving remain items from left array first
        while(i < leftLength)
            arr[k++] = leftArray[i++];

        // moving remains from right array
        while (j < rightLength) 
            arr[k++] = rightArray[j++];

    }
    public static void segregate(int[] arr, int start, int end)
    {
        if(end <= start) return;

        int midPoint = (end + start) / 2;

        segregate(arr, start, midPoint);
        segregate(arr, midPoint+1, end);
        merge(arr, start, midPoint, end);

    }

    static void Main(string[] args)
    {

        int[] arr = { 6, -5, 12, 10, -9, -1 };
        Console.WriteLine("[" + String.Join(", ", arr)+ "]");
        segregate(arr, 0, arr.Length - 1);
        Console.WriteLine("[" + String.Join(", ", arr) + "]");
        Console.ReadKey();
    }
}

