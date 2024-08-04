using System;
using System.Security.Policy;
using Hash;

internal class Program
{
    static void Main(string[] args)
    {
        clsHash Hash = new clsHash();
        Hash.Hash32("This is Original Text");
        //Hash.Hash32("this is original text");
        Hash.Hash64("This is Original Text");

        Console.ReadKey();
    }
}

