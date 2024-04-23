using System;
using System.Collections.Generic;


namespace Greedy_Fractional_Knapsack_Problem
{
    public class clsPrint
    {
        public void PrintItems(clsKnapsack bag)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Total Profit: " + bag.totalProfit);
            Console.WriteLine("Current Capacity: " + bag.currentCapacity);
            Console.WriteLine("Items: ");
            Console.WriteLine("n\tv\tw");

            for (int i = 0; i < bag.lItems.Count; ++i)
            {
                Console.WriteLine(bag.lItems[i].ToString() + "\t" + bag.lItems[i].profit + "\t" + bag.lItems[i].weight);
            }
        }

        public void print_array(List<clsItem> lItems)
        {
            Console.WriteLine("n\tv\tw\tr");

            for (int i = 0; i < lItems.Count; ++i)
            {
                Console.WriteLine(lItems[i].name + "\t" + lItems[i].profit + "\t" + lItems[i].weight + "\t" + lItems[i].ratio);
            }
        }
    }
}
