using System;
using System.Collections.Generic;

namespace Greedy_Fractional_Knapsack_Problem
{
    internal class Program
    {


        static void Main(string[] args)
        {
            int[] profits = { 4, 9, 12, 11, 6, 5 };
            int[] weights = { 1, 2, 10, 4, 3, 5 };

            List<clsItem> items = new List<clsItem>();

            for (int i = 0; i < profits.Length; ++i)
            {
                clsItem newItem = new clsItem(profits[i], weights[i], "#" + i.ToString());
                items.Add(newItem);
            }

            clsSorting s = new clsSorting();
            s.MergeSort(items, 0, items.Count - 1);

            clsPrint p = new clsPrint();
            p.print_array(items);

            int j = 0;
            clsKnapsack bag = new clsKnapsack(12);
            while (bag.currentCapacity < bag.maxCapacity && j < items.Count)
                bag.AddItem(items[j++]);

            p.PrintItems(bag);

            Console.ReadKey();

        }
    }
}
