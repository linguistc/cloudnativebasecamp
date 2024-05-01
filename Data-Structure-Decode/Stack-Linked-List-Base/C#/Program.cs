using System;
using clsStack;

internal class Program
{
    static void Main(string[] args)
    {
        clsStack<int> stack = new clsStack<int>(true);

        //Console.WriteLine("Is empty? " + stack.IsEmpty());
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        //Console.WriteLine("Is empty? " + stack.IsEmpty());
        //Console.WriteLine("Size: " + stack.Size());
        //stack.PrintStack();

        //Console.WriteLine("Pop: " + stack.Pop());
        //Console.WriteLine("Size: " + stack.Size());
        //stack.PrintStack();

        //Console.WriteLine("Peek: " + stack.Beek());
        //Console.WriteLine("Size: " + stack.Size());
        //stack.PrintStack();

        while (!stack.IsEmpty())
        {
            Console.WriteLine("Pop: " + stack.Pop());
            Console.WriteLine("Size: " + stack.Size());
            stack.PrintStack();
        }


        Console.ReadKey();

    }
}

