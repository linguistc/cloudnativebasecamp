using System;
using System.Collections.Generic;

public class Program
{
    // The time complexity of this algorithm is O(n*m), where n and m are the lengths of the input strings
    // The space complexity of this algorithm is also O(n*m)

    public static void Main()
    {
        string text_01 = "HELLOWORLD";
        string text_02 = "OHELOD";
        int n = text_01.Length;
        int m = text_02.Length;

        // Add a space at the beginning of each string
        text_01 = " " + text_01;
        text_02 = " " + text_02;

        // Using List of Lists.
        /*
        // Initialize a 2D array (List of Lists) to store the dynamic programming values
        // List<List<int>> dp = new List<List<int>>();
        //for (int i = 0; i <= m; i++)
        //{
        //    dp.Add(new List<int>(new int[n + 1]));
        //}

        // Fill in the dp array
        //for (int i = 1; i <= m; i++)
        //{
        //    for (int j = 1; j <= n; j++)
        //    {
        //        if (text_02[i] == text_01[j])
        //        {
        //            dp[i][j] = 1 + dp[i - 1][j - 1];
        //        }
        //        else
        //        {
        //            dp[i][j] = Math.Max(dp[i][j - 1], dp[i - 1][j]);
        //        }
        //    }
        //}

         // Backtrack through the dp array to construct the LCS string
        string lcs_str = "";
        int x = m, y = n;
        while (x > 0 && y > 0)
        {
            if (dp[x][y] > dp[x][y - 1])
            {
                if (dp[x][y] == dp[x - 1][y])
                {
                    x--;
                }
                else
                {
                    lcs_str = text_02[x] + lcs_str;
                    x--;
                    y--;
                }
            }
            else
            {
                y--;
            }
        }

        */

        // Using 2D Array.
        int[,] dp = new int[m + 1, n + 1];

        // Fill in the dp array
        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0 || j == 0)
                {
                    dp[i, j] = 0;
                }
                else if (text_02[i] == text_01[j])
                {
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);
                }
            }
        }

        // Constructing the result string by tracing back the dp table
        string str = "";
        int x = m;
        int y = n;
        while (x > 0 && y > 0)
        {
            if (dp[x, y] > dp[x, y - 1])
            {
                if (dp[x, y] == dp[x - 1, y])
                {
                    x--;
                }
                else
                {
                    str = text_02[x] + str;
                    x--;
                    y--;
                }
            }
            else
            {
                y--;
            }
        }



        // Output the length of the LCS and the LCS string
        Console.WriteLine(dp[m,n]);  // Output the length of the longest common subsequence
        Console.WriteLine(str);     // Output the longest common subsequence string

        Console.ReadKey();
    }
}
