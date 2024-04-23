using System;
using System.Collections.Generic;


namespace Greedy_Fractional_Knapsack_Problem
{
 
    public class clsItem
    {
        public string name;
        public float profit;
        public int weight;
        public float ratio;

        public clsItem() { }
        public clsItem(int profit, int weight, string name)
        {
            this.name = name;
            this.profit = profit;
            this.weight = weight;
            ratio = (float)profit / weight;
        }
    }

    public class clsKnapsack
    {
        public int maxCapacity, currentCapacity;
        public float totalProfit;
        public List<clsItem> lItems = new List<clsItem>();

        public clsKnapsack(int maxCapacity) 
        {
            this.maxCapacity = maxCapacity;
            currentCapacity = 0;
            totalProfit = 0;
        }

        public void AddItem(clsItem newItem)
        {
            if (newItem.weight > maxCapacity - currentCapacity)
            {
                int diff = maxCapacity - currentCapacity;
                newItem.weight = diff;
                newItem.profit = diff * newItem.ratio;
            }

            lItems.Add(newItem);
            currentCapacity += newItem.weight;
            totalProfit += newItem.profit;
        }

    }
}
