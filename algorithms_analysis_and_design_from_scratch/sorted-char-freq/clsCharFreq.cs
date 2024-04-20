using System;
using System.Collections;


namespace sorted_char_freq
{
    public class clsCharFreq
    {
        public clsCharFreq() { }
        public void ASCIIMethod(string msg)
        {
            Console.WriteLine("ASCIIMethod");
            int[] freq = new int[127];

            for (int i = 0; i < msg.Length; ++i)
            {
                int charCode = (int)msg[i];
                ++freq[charCode];
            }

            for (int i = 0; i < freq.Length; ++i)
            {
                if (freq[i] > 0)
                {
                    char c = (char)i;
                    Console.Write(c + ": ");
                    Console.WriteLine(freq[i]);
                }
            }
        }

        
        
        public void AnyCodeMethod(string msg)
        {
            Console.WriteLine("AnyCodeMethod");

            Hashtable htFreq = new Hashtable();

            for (int i = 0; i < msg.Length; ++i)
            {
                if (htFreq[msg[i]] == null)
                    htFreq[msg[i]] = 1;
                else
                    htFreq[msg[i]] = (int)htFreq[msg[i]] + 1;
            }

            //foreach (char key in htFreq.Keys)
            //{
            //    Console.Write(key + ": ");
            //    Console.WriteLine(htFreq[key]);
            //}

            SortHash(htFreq);

        }

        public void SortHash(Hashtable htFreq)
        {
            int[,] freqArray = new int[htFreq.Count, 2];

            int i = 0;
            foreach(char key in htFreq.Keys)
            {
                freqArray[i, 0] = (int)key;
                freqArray[i, 1] = (int)htFreq[key];
                ++i;
            }

            this.Sort(freqArray, 0, htFreq.Count - 1);

            Console.WriteLine("Sotred Data ...");
            for (i = 0; i < htFreq.Count; ++i)
            {
                Console.Write((char)freqArray[i, 0] + ": ");
                Console.WriteLine(freqArray[i, 1]);
            }
        }


        public void Sort(int[,] array, int start, int end)
        {
            if (end <= start) return;

            int midPoint = (start + end) / 2;
            Sort(array, start, midPoint);
            Sort(array, midPoint+1, end);
            Merge(array, start, midPoint, end);

        }

        public void Merge(int[,] array, int start, int midPoint, int end)
        {
            int i, j, k;
            int leftLength = midPoint - start + 1;
            int rightLength = end - midPoint;

            int[,] leftArray = new int[leftLength, 2];
            int[,] rightArray = new int[rightLength, 2];

            for(i = 0; i < leftLength; ++i)
            {
                leftArray[i, 0] = array[start + i, 0];
                leftArray[i, 1] = array[start + i, 1];
            }

            for(j = 0;  j < rightLength; ++j)
            {
                rightArray[j, 0] = array[midPoint + j + 1, 0];
                rightArray[j, 1] = array[midPoint + j + 1, 1];
            }

            i = j = 0;
            k = start;

            while ( i < leftLength && j < rightLength) 
            {
                if (leftArray[i, 1] >= rightArray[j, 1])
                {
                    array[k, 0] = leftArray[i, 0];
                    array[k, 1] = leftArray[i, 1];
                    ++i;
                }
                else
                {
                    array[k,0] = rightArray[j, 0];
                    array[k, 1] = rightArray[j, 1];
                    ++j;
                }
                ++k;
            }

            while(i < leftLength)
            {
                array[k, 0] = leftArray[i, 0];
                array[k, 1] = leftArray[i, 1];
                ++i;
                ++k;
            }

            while (j < rightLength)
            {
                array[k, 0] = rightArray[j, 0];
                array[k, 1] = rightArray[j, 1];
                ++j; ++k;
            }
        }


    }
}
