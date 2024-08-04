using System.Text;

namespace HashTable
{
    public class clsHashTable<Tkey, Tvalue> where Tkey : class
    {
        private KeyValuePair[] _entries;
        private int _initialSize;
        private int _entriesCount;

        public clsHashTable()
        {
            this._initialSize = 3;
            this._entriesCount = 0;
            this._entries = new KeyValuePair[this._initialSize];
        }

        private int GetHash(Tkey key)
        {
            uint FNVOffsetBasis = 2166136261;
            uint FNVPrime = 16777619;


            byte[] data = Encoding.ASCII.GetBytes(key.ToString());
            uint hash = FNVOffsetBasis;

            for (int i = 0; i < data.Length; ++i)
            {
                hash = hash ^ data[i];
                hash = hash * FNVPrime;
            }

            Console.WriteLine("[hash] " + key.ToString()
                + " " + hash + " " + hash.ToString("x")
                  + " " + hash % (uint)this._entries.Length);

            return (int)(hash % (uint)this._entries.Length);
        }


        private int CollisionHandling(Tkey key, int hash, bool Set)
        {
            int newHash;
            // Linear Probing
            for (int i = 1; i < this._entries.Length; ++i)
            {
                newHash = (hash + i) % this._entries.Length;

                Console.WriteLine("[coll] " + key.ToString()
                  + " " + hash + ", new hash: " + newHash);

                if (Set &&
                    (this._entries[newHash] == null ||
                    this._entries[newHash].Key == key))
                {
                    return newHash;
                }
                else if(!Set && this._entries[newHash].Key == key)
                {
                    return newHash;
                }

            }


            return -1;
        }

        private void AddToEntries(Tkey key, Tvalue val)
        {
            int hash = this.GetHash(key);
            if (this._entries[hash] != null && this._entries[hash].Key != key)
            {
                hash = this.CollisionHandling(key, hash, true);
            }

            if(hash == -1)
            {
                throw new Exception("Invalid Hashtable!");
            }
            if (this._entries[hash] == null)
            {
                KeyValuePair newPair = new KeyValuePair(key, val);
                this._entries[hash] = newPair;
                ++this._entriesCount;
            }
            else if (this._entries[hash].Key == key)
            {
                this._entries[hash].Value = val;
            }
            else
            {
                throw new Exception("Invalid Hashtable!");
            }
        }

        public void ResizeOrNot()
        {
            if (this._entriesCount < this._entries.Length) return;

            int newSize = this._entries.Length * 2;

            Console.WriteLine($"[resize] from {this._entries.Length} to {newSize}");

            KeyValuePair[] newEntries = new KeyValuePair[newSize];
            Array.Copy(this._entries, newEntries, newSize);

            this._entries = new KeyValuePair[newSize];
            this._entriesCount = 0;
            for (int i = 0; i < newSize; ++i)
            {
                if (newEntries[i] == null) continue;

                this.AddToEntries(newEntries[i].Key, newEntries[i].Value);
            }

        }

        public Tvalue Set(Tkey key)
        {
            int hash = this.GetHash(key);
            if (this._entries[hash] != null && this._entries[hash].Key != key)
            {
                this.CollisionHandling(key, hash, false);
            }

            if (hash == -1 || this._entries[hash] == null)
                return default(Tvalue);
            
            if (this._entries[hash].Key == key)
                return this._entries[hash].Value;
            else
                throw new Exception("Invalid Hashtable!");
        }

        public int Size()
        {
            return this._entriesCount;
        }

        public void Print()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("[Size] " + this.Size());

            for (int i = 0; i < this._entries.Length; i++)
            {
                if (this._entries[i] == null)
                {
                    Console.WriteLine("[" + i + "] null");
                }
                else
                {
                    Console.WriteLine("[" + i + "] " +
                      this._entries[i].Key + ": " +
                        this._entries[i].Value);
                }
            }

            Console.WriteLine("============");
        }


        private class KeyValuePair
        {
            Tkey _key;
            Tvalue _value;

            public Tkey Key
            {
                get { return _key; }
            }
            public Tvalue Value
            {
                set { this._value = value; }
                get { return this._value; }
            }

            public KeyValuePair(Tkey key, Tvalue value)
            {
                this._key = key;
                this._value = value;
            }
        } // class
    } // class
} // namespace
