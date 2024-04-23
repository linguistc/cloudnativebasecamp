using System;



internal class Program
{
    static void Main(string[] args)
    {
        string msg = "internet";
        clsHuffman huff = new clsHuffman(msg);

        foreach(char key in huff.htCodes.Keys) 
        {
            Console.WriteLine(key + ": " + huff.htCodes[key]);
        }
    }
}


