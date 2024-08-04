using System;
using Hashtable;

class Program
{
    public static void Main(string[] args)
    {

        clsHashTable<string, string> table = new clsHashTable<string, string>();
        table.Print();
        table.Set("Sinar", "sinar@gmail.com");
        table.Set("Elvis", "elvis@gmail.com");
        table.Set("Tane", "tane@gmail.com");
        table.Print();
        Console.WriteLine("[get] " + table.Get("Sinar"));
        //Console.WriteLine("[get] " + table.Get("Tane"));
        table.Set("Gerti", "gerti@gmail.com");
        table.Set("Arist", "arist@gmail.com");
        table.Print();
        Console.WriteLine("[get] " + table.Get("Sinar"));

        Console.ReadKey();

    }
}