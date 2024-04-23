using System;
using System.Collections;
using System.Collections.Generic;


// Assistant Class
public class clsHeapNode
{
    public char data;
    public int freq;
    public clsHeapNode left, right;

    public clsHeapNode(char data, int freq)
    {
        this.data = data;
        this.freq = freq;
        this.left = this.right = null;
    }

}


public class clsHuffman
{
    private char _NullChar = '\0'; // (char)0 

    private PriorityQueue<clsHeapNode, int> _MinHeap = new PriorityQueue<clsHeapNode, int>();

    public Hashtable htCodes = new Hashtable();

    public clsHuffman(string message)
    {
        Hashtable htFreq = new Hashtable();
        int i;
        for (i = 0; i < message.Length; ++i)
        {
            if (htFreq[message[i]] == null)
                htFreq[message[i]] = 1;
            else
                htFreq[message[i]] = (int)htFreq[message[i]] + 1;
        }

        // Converting HashTable to Periority Queue
        i = 0;
        foreach (char key in htFreq.Keys)
        {
            clsHeapNode newNode = new clsHeapNode(key, (int)htFreq[key]);
            _MinHeap.Enqueue(newNode, newNode.freq);
            ++i;
        }

        clsHeapNode top, left, right;
        int newFreq;
        while (_MinHeap.Count > 1)
        {
            left = _MinHeap.Dequeue();
            right = _MinHeap.Dequeue();
            newFreq = left.freq + right.freq;
            top = new clsHeapNode(_NullChar, newFreq);
            top.left = left;
            top.right = right;
            _MinHeap.Enqueue(top, newFreq);

        }
        // Generate Codes
        this._GenerateCodes(_MinHeap.Peek(), "");
    }

    private void _GenerateCodes(clsHeapNode root, string str)
    {
        if (root == null) return;
        if (root.data != _NullChar)
            htCodes[root.data] = str;
        _GenerateCodes(root.left, str + "0");
        _GenerateCodes(root.right, str + "1");

        //if (root.left == null && root.right == null && root.data != _NullChar)
        //{
        //    Console.WriteLine(root.data + " : " + str);
        //    return;
        //}

        //_GenerateCodes(root.left, str + "0");
        //_GenerateCodes(root.right, str + "1");
    }
}

