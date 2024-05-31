using System;
using System.Drawing;


namespace clsHeap
{
    public class Heap
    {
        private List<int> _dataList;
        private int _size;

        public Heap()
        {
            this._dataList = new List<int>();
            this._size = 0;
        }

        public void insert(int data)
        {
            int i = this._size++;

            this._dataList.Add(data);

            int parentIndex = (i - 1) / 2;

            while (i != 0 && this._dataList[i] < this._dataList[parentIndex])
            {
                this._dataList[i] = this._dataList[parentIndex];
                this._dataList[parentIndex] = data;

                i = parentIndex;
                parentIndex = (i - 1) / 2;
            }

        }

        public int? pop()
        {
            if (this._size == 0) return null;

            int i = 0;
            int data = this._dataList[i];

            this._dataList[i] = this._dataList[this._size - 1];
            this._dataList[this._size - 1] = 0;
            --this._size;

            int leftIndex = 2 * i + 1;
            while (leftIndex < this._size)
            {
                int rightIndex = 2 * i + 2;

                int smallerIndex = leftIndex;

                if(rightIndex < this._size && 
                    this._dataList[rightIndex] < this._dataList[leftIndex])
                {
                    smallerIndex = rightIndex;
                }

                if(this._dataList[smallerIndex] > this._dataList[i])
                    break;

                int temp = this._dataList[i];
                this._dataList[i] = this._dataList[smallerIndex];
                this._dataList[smallerIndex] = temp;

                i = smallerIndex;
                leftIndex = 2 * i + 1;
            }

            return data;

        }

        public void Print()
        {
            string print_data = "";
            for (int i = 0; i < this._size; i++)
            {
                print_data += this._dataList[i] + " - ";
            }
            Console.WriteLine(print_data);
        }

        public int Size()
        {
            return this._size;
        }

        public void Draw()
        {
            int levels_count = (int)Math.Log2(_size) + 1;
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
                    if (j == _size)
                    {
                        break;
                    }
                    if (_dataList[j] != 0)
                    {
                        str += _dataList[j] + new string(' ', space_between);
                    }
                }
                str += new string(' ', space) + "\n";
                Console.WriteLine(str);
            }
        }
    }
}
    

