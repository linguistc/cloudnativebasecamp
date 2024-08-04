using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<(int, int)> data_list; // list to hold the data and their respective priorities in the queue
    private int size;                   // holds the number of elements in the queue

    public PriorityQueue()
    {
        data_list = new List<(int, int)>();
        size = 0;
    }

    public void Enqueue(int priority, int data)
    {
        int i = size;
        data_list.Add((priority, data));
        size++;
        int parent_index = (i - 1) / 2;
        while (i != 0 && data_list[i].Item1 < data_list[parent_index].Item1)
        {
            (int, int) temp = data_list[i];
            data_list[i] = data_list[parent_index];
            data_list[parent_index] = temp;
            i = parent_index;
            parent_index = (i - 1) / 2;
        }
    }

    public (int, int)? Dequeue()
    {
        if (size == 0)
            return null;

        int i = 0;
        (int, int) data = data_list[i];
        (int, int) last_node = data_list[size - 1];

        // copy last node to root
        data_list[i] = last_node;

        // delete last node
        data_list.RemoveAt(size - 1);
        size--;

        int left_index = 2 * i + 1;
        while (left_index < size)
        {
            int right_index = 2 * i + 2;

            int smaller_index = left_index; // just initial value
            if (right_index < size && data_list[right_index].Item1 < data_list[left_index].Item1)
            {
                smaller_index = right_index;
            }
            if (data_list[smaller_index].Item1 >= data_list[i].Item1)
            {
                break;
            }

            // swap
            (int, int) temp = data_list[i];
            data_list[i] = data_list[smaller_index];
            data_list[smaller_index] = temp;

            i = smaller_index;
            left_index = 2 * i + 1;
        }
        return data;
    }

    public bool HasData()
    {
        return size > 0;
    }

    public void Print()
    {
        string print_data = "";
        for (int i = 0; i < size; i++)
        {
            print_data += data_list[i].Item2 + " - ";
        }
        Console.WriteLine(print_data);
    }

    public int GetSize()
    {
        return size;
    }

    public void Draw()
    {
        int levels_count = (int)Math.Log2(GetSize()) + 1;
        int line_width = (int)Math.Pow(2, levels_count - 1);
        int j = 0;

        for (int i = 0; i < levels_count; i++)
        {
            int nodes_count = (int)Math.Pow(2, i);
            int space = (int)Math.Ceiling((double)(line_width - nodes_count) / 2);
            int space_between = (int)Math.Ceiling((double)levels_count / nodes_count);
            space_between = space_between < 1 ? 1 : space_between;
            int k = j;
            string str = new string(' ', space + space_between);

            for (; j < k + nodes_count; j++)
            {
                if (j == GetSize())
                {
                    break;
                }
                if (data_list[j].Item1 != 0 && data_list[j].Item2 != 0)
                {
                    str += data_list[j].Item2 + "[" + data_list[j].Item1 + "]" + new string(' ', space_between);
                }
            }
            str += new string(' ', space) + "\n";
            Console.WriteLine(str);
        }
    }
}
