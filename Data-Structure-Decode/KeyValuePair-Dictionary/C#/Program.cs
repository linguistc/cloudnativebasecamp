using System;
using clsDictionary;

internal class Program
{
    static void Main(string[] args)
    {
        clsDictionary <string, string> dic = new clsDictionary<string, string> ();
        dic.Print();

        dic.Set("Ahmed", "ahmed@proton.me");
        dic.Set("Elvis", "elvis@gmail.com");
        dic.Print();

        dic.Set("Tane", "tane@gmail.com");
        dic.Set("Gerti", "gerti@gmail.com");
        dic.Set("Arist", "arist@gmail.com");

        dic.Print();

        Console.WriteLine(dic.Get("Tane"));
        Console.WriteLine(dic.Get("Sinar"));
        Console.WriteLine(dic.Get("Elviaaa"));

        dic.Remove("Ahmed");
        dic.Remove("Elvis");
        dic.Print();
        dic.Remove("Tane");
        dic.Remove("Gerti");
        dic.Remove("Arist");
        dic.Print();
        dic.Set("Ahmed", "ahmed@proton.com");
        dic.Print();

        Console.ReadKey();
    }
}
