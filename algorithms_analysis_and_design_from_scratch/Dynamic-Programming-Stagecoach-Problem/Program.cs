using System;
using System.Collections.Generic;

public class Program
{
    const int MAX = int.MaxValue;

    // Define the labels and data for the graph
    static List<string> labels = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
    static List<List<int>> _data = new List<List<int>>
    {
        new List<int> {0, 2, 4, 3, 0, 0, 0, 0, 0, 0},
        new List<int> {0, 0, 0, 0, 7, 4, 6, 0, 0, 0},
        new List<int> {0, 0, 0, 0, 3, 2, 4, 0, 0, 0},
        new List<int> {0, 0, 0, 0, 4, 1, 5, 0, 0, 0},
        new List<int> {0, 0, 0, 0, 0, 0, 0, 1, 4, 0},
        new List<int> {0, 0, 0, 0, 0, 0, 0, 6, 3, 0},
        new List<int> {0, 0, 0, 0, 0, 0, 0, 3, 3, 0},
        new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 3},
        new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 4},
        new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    };

    struct State
    {
        public string From;
        public string To;
        public int Cost;
    }

    public static void Main()
    {
        int n = _data.Count;

        // Initialize the states array to store the minimum cost and path to each node
        State[] states = new State[n];

        // Set the last element of the states array to have a cost of 0
        states[n - 1] = new State { From = "", To = "", Cost = 0 };

        // Iterate through each node, starting from the second to last node
        for (int i = n - 2; i >= 0; --i)
        {
            // Initialize the current state with a very large cost and no path
            states[i] = new State { From = labels[i], To = "", Cost = int.MaxValue };

            // Iterate through each neighbor of the current node
            for (int j = i + 1; j < n; j++)
            {
                // If there is no edge between the current node and the neighbor, continue to the next neighbor
                if (_data[i][j] == 0) continue;

                // Calculate the new cost to reach the neighbor and add it to the cost of the neighbor's minimum path
                int newCost = _data[i][j] + states[j].Cost;

                // If the new cost is smaller than the current minimum cost for the current node, update the current state
                if (newCost < states[i].Cost)
                {
                    states[i].To = labels[j];
                    states[i].Cost = newCost;
                }
            }
        }

        List<string> path = new List<string> { "A" };
        int index = 0;

        while (index < states.Length)
        {
            if (states[index].From == path[path.Count - 1])
            {
                path.Add(states[index].To);
            }
            index++;
        }

        Console.WriteLine("Minimum Cost: " + states[0].Cost);
        Console.Write("Minimum Path: ");
        foreach (string node in path)
        {
            Console.Write(node + " ");
        }
        Console.WriteLine();

        Console.ReadKey();
    }
}
