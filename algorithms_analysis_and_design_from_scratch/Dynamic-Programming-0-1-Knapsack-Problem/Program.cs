using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var items = new List<Item>
        {
            new Item("#1", 1, 4),
            new Item("#2", 3, 9),
            new Item("#3", 5, 12),
            new Item("#4", 4, 11)
        };

        int maxWeight = 8;

        // Insert an empty item at the beginning (equivalent to items.splice(0, 0, { "name": "#0", "weight": 0, "profit": 0 }); in JavaScript)
        items.Insert(0, new Item("#0", 0, 0));

        int itemCount = items.Count;

        // Create a 2D array for dynamic programming (DP) table
        int[,] dp = new int[itemCount, maxWeight + 1];

        // Populate the DP table
        for (int i = 0; i < itemCount; i++)
        {
            for (int j = 0; j <= maxWeight; j++)
            {
                if (i == 0 || j == 0)
                {
                    dp[i, j] = 0;
                }
                else if (items[i].Weight <= j)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], items[i].Profit + dp[i - 1, j - items[i].Weight]);
                }
                else
                {
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        // Output the maximum profit
        Console.WriteLine("Max Profit: " + dp[itemCount - 1, maxWeight]);

        // Retrieve the solution (selected items)
        List<string> solution = new List<string>();
        int currentWeight = maxWeight;
        int currentItem = itemCount - 1;

        while (currentItem > 0 && currentWeight > 0)
        {
            if (dp[currentItem, currentWeight] > dp[currentItem - 1, currentWeight])
            {
                solution.Add(items[currentItem].Name);
                currentWeight -= items[currentItem].Weight;
            }
            currentItem--;
        }

        // Output the solution (selected item names)
        solution.Reverse(); // Reverse the list to print in the correct order
        Console.WriteLine("Solution: " + string.Join(", ", solution));
        Console.ReadKey();
    }
}

// Item class representing each item with name, weight, and profit
public class Item
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Profit { get; set; }

    public Item(string name, int weight, int profit)
    {
        Name = name;
        Weight = weight;
        Profit = profit;
    }
}



/*
public class Program
{
    // Define a struct to represent an item
    public struct Item
    {
        public string name;
        public int weight;
        public int profit;
    }

    // Function to solve the knapsack problem and return the maximum profit
    public static int Knapsack(List<Item> items, int maxWeight, List<List<int>> dp, List<string> solution)
    {
        // Add a dummy item to the beginning of the list to simplify the dynamic programming algorithm
        items.Insert(0, new Item { name = "#0", weight = 0, profit = 0 });

        int n = items.Count;

        // Initialize the dynamic programming table with zeros
        dp = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            dp.Add(new List<int>(new int[maxWeight + 1]));
        }

        // Compute the maximum profit that can be obtained for each item and weight limit combination
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j <= maxWeight; j++)
            {
                if (items[i].weight <= j)
                {
                    dp[i][j] = Math.Max(dp[i - 1][j], items[i].profit + dp[i - 1][j - items[i].weight]);
                }
                else
                {
                    dp[i][j] = dp[i - 1][j];
                }
            }
        }

        // Backtrack through the dynamic programming table to determine the solution
        int remain = maxWeight;
        for (int i = n - 1, j = maxWeight; remain >= 0 && j > 0; i--)
        {
            if (dp[i][j] > dp[i - 1][j])
            {
                solution.Add(items[i].name);
                remain -= items[i].weight;
                j = remain;
            }
        }

        // Return the maximum profit that can be obtained
        return dp[n - 1][maxWeight];
    }

    public static void Main()
    {
        //
        //The time complexity of the dynamic programming algorithm used in this code is
        //O(n*W), where n is the number of items and W is the maximum weight that can be carried.
        //The space complexity of the algorithm is also O(n*W).
        //

        List<Item> items = new List<Item>
        {
            new Item { name = "#1", weight = 1, profit = 4 },
            new Item { name = "#2", weight = 3, profit = 9 },
            new Item { name = "#3", weight = 5, profit = 12 },
            new Item { name = "#4", weight = 4, profit = 11 }
        };
        int maxWeight = 8;

        // Define variables for the dynamic programming table and the solution
        List<List<int>> dp = new List<List<int>>();
        List<string> solution = new List<string>();

        // Compute the maximum profit that can be obtained and determine the solution
        int maxProfit = Knapsack(items, maxWeight, dp, solution);

        // Print the maximum profit and the solution
        Console.WriteLine("Max Profit: " + maxProfit);
        Console.Write("Solution: ");
        foreach (var item in solution)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}
*/
