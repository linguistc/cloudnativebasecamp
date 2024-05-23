using System;
using Tree;
using Tree;

class Program
{
    public static void Main(string[] args)
    {
        BinaryTree<char> tree = new BinaryTree<char>();
        tree.Insert('A');
        tree.Insert('B');
        tree.Insert('C');
        tree.Insert('D');
        tree.Insert('E');
        tree.Insert('F');
        tree.Insert('G');
        tree.Insert('H');
        tree.Insert('I');
        tree.Print();

        //Console.WriteLine("Height: " + tree.Height());
        //tree.PreOrder();
        //tree.InOrder();
        //tree.PostOrder();

        tree.Delete('a');
        tree.Print();

        tree.Delete('A');
        tree.Print();

        tree.Delete('B');
        tree.Print();

    }
}