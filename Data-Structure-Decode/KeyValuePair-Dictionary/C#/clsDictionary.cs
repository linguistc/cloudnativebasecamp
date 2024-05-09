using System;


namespace clsDictionary
{
    public class clsDictionary<Tkey, Tvalue> where Tkey : class
    {
        private KeyValuePair[] _entries;
        private int _initialSize;
        private int _entriesCount;

        public clsDictionary()
        {
            this._initialSize = 3;
            this._entries = new KeyValuePair[this._initialSize];
            this._entriesCount = 0;
        }
        public void ResizeOrNot()
        {
            if (this._entriesCount < this._entries.Length - 1)
                return;

            int newSize = this._entries.Length + this._initialSize;
            Console.WriteLine("[resize] from "
                + this._entries.Length + " to " + newSize);

            KeyValuePair[] copyEntries = new KeyValuePair[newSize];

            Array.Copy(this._entries, copyEntries, this._entries.Length);

            this._entries = copyEntries;
        }

        public int Size()
        {
            return this._entriesCount;
        }

        public void Set(Tkey key, Tvalue value)
        {
            for(int i = 0; i< this._entriesCount; ++i) 
            {
                if (this._entries[i] != null && this._entries[i].Key == key)
                {
                    this._entries[i].Value = value;
                    return;
                }
            }

            this.ResizeOrNot();
            // make new pair and assign it to the end of the entries array, then increase count by one.
            this._entries[this._entriesCount++] = new KeyValuePair(key, value);
            
        }

        public Tvalue Get(Tkey key)
        {
            for (int i = 0; i < this._entriesCount; ++i)
            {
                if(this._entries[i] != null && key == this._entries[i].Key)
                    return this._entries[i].Value;
            }

            return default(Tvalue);
        }

        public bool Remove(Tkey key)
        {
            for(int i = 0; i < this._entriesCount; ++i)
            {
                if (this._entries[i] != null && key == this._entries[i].Key)
                {
                    this._entries[i] = this._entries[this._entriesCount - 1];
                    this._entries[this._entriesCount - 1] = null;
                    --this._entriesCount;
                    return true;
                }
            }


            return false;
        }

        public void Print()
        {
            Console.WriteLine("----------");
            Console.WriteLine("[size] " + this.Size());

            for (int i = 0; i < this._entries.Length; ++i)
            {
                if (this._entries[i] == null)
                {
                    Console.WriteLine("[" + i + "]");
                    continue;
                }
                else
                {
                    Console.WriteLine("[" + i + "]" + this._entries[i].Key
                      + ": " + this._entries[i].Value);
                }
            }
            Console.WriteLine("==========");
        }

        private class  KeyValuePair
        {
            private Tkey _key;
            private Tvalue _value;

            public Tkey Key
            {
                get { return _key; }
            }

            public Tvalue Value
            {
                get { return _value; }
                set { this._value = value; }
            }

            public KeyValuePair(Tkey key, Tvalue value)
            {
                this._key = key;
                this._value = value;
            }

        } // class
    }// class
}// namespace
