using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

 
internal class Program
{
    static void Main(string[] args)
    {
        int[] Array = new int[] { 4654, 921, 762 };
        clsArray MyArray = new clsArray();

        MyArray.Resize(ref Array, 5);
        Console.WriteLine(String.Join(", ", Array));

        int Item = MyArray.GetAt<int>(Array, 1, sizeof(int));
        Console.WriteLine(Item);


        Console.ReadKey();
    }

    class clsArray
    {
        public void Resize<T>(ref T[] Source, int NewSize)
        {
            if (NewSize <= 0) return;
            if (Source == null) return;
            if(NewSize ==  Source.Length) return;

            T[] NewArray = new T[NewSize];

            Buffer.BlockCopy(Source, 0, NewArray, 0, 
                                Buffer.ByteLength(Source));

            Source = NewArray;
        }

        public T GetAt<T>(T[] Source, int Index, int SizeOf)
        {
            if(Index < 0 || Index >= Source.Length) 
                return default(T);

            ref byte ZeroAddress = ref MemoryMarshal.GetArrayDataReference((Array)Source);
            ref byte IndexRef = ref Unsafe.Add(ref ZeroAddress, Index * SizeOf);
            ref T item = ref Unsafe.As<byte, T>(ref IndexRef);

            return item;
        }
    }
}
