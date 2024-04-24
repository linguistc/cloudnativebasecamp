using System;
using System.Collections.Generic;

namespace Greedy_Fractional_Knapsack_Problem
{
    public class clsSorting
    {

        public void Merge(List<clsItem> lItems, int start, int midPoint, int end)
        {
            int left_lenght = midPoint - start + 1;
            int right_lenght = end - midPoint;

            List<clsItem> left_array = new List<clsItem>();
            List<clsItem> right_array = new List<clsItem>();

            int i, j, k;

            for (i = 0; i < left_lenght; ++i)
                left_array.Add( lItems[start + i] );

            for (i = 0; i < right_lenght; ++i)
                right_array.Add( lItems[midPoint + 1 + i]);

            i = 0;
            j = 0;
            k = start;

            while (i < left_lenght && j < right_lenght)
            {
                if (left_array[i].ratio > right_array[j].ratio)
                    lItems[k] = left_array[i++];
                else
                    lItems[k] = right_array[j++];
                ++k;
            }

            while (i < left_lenght)
            {
                lItems[k++] = left_array[i++];
            }
            while (j < right_lenght)
                lItems[k++] = right_array[j++];
        }

        public void MergeSort(List<clsItem> lItems, int start, int end)
        {
            if (end <= start) return;
            int midPoint = (end + start) / 2;

            MergeSort(lItems, start, midPoint);
            MergeSort(lItems, midPoint + 1, end);
            Merge(lItems, start, midPoint, end);
        }

    }
}

