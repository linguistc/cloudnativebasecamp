using System;
using Tree;
using Tree;

class Program
{
    public static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();
        //tree.BSInsert(1);
        //tree.BSInsert(4);
        //tree.BSInsert(2);
        //tree.BSInsert(3);
        //tree.BSInsert(6);
        //tree.BSInsert(5);
        //tree.Print();

        //Console.WriteLine(tree.IsExsit(8));

        //tree.InOrder();

        //tree.BinarySearchInsert(4);
        //tree.BinarySearchInsert(6);
        //tree.BinarySearchInsert(7);
        //tree.BinarySearchInsert(5);
        //tree.BinarySearchInsert(2);
        //tree.BinarySearchInsert(1);
        //tree.BinarySearchInsert(3);
        //tree.Print();

        //tree.BinarySearchDelete(4);
        //tree.Print();
        //tree.BinarySearchDelete(6);
        //tree.Print();
        //tree.BinarySearchDelete(3);
        //tree.Print();
        //tree.BinarySearchDelete(5);
        //tree.Print();
        //tree.BinarySearchDelete(7);
        //tree.Print();
        //tree.BinarySearchDelete(2);
        //tree.Print();
        //tree.BinarySearchDelete(1);
        //tree.Print();

        tree.BinarySearchInsert(1);
        tree.BinarySearchInsert(2);
        tree.BinarySearchInsert(3);
        tree.BinarySearchInsert(4);
        tree.BinarySearchInsert(5);
        tree.BinarySearchInsert(6);
        tree.BinarySearchInsert(7);
        tree.Print();

        tree.Balance();
        tree.Print();

    }
}