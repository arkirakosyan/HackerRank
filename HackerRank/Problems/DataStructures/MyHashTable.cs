using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public static class MyHashTableTest
    {
        public static void Test()
        {
            DateTime start = DateTime.Now;
            Hashtable hash = new Hashtable();


            for (int i = 1; i <= 2000000; i++)
            {
                hash["key" + i] = "value" + i;
            }

            for (int i = 1; i < 100000; i++)
            {
                Random r = new Random();
                int index = r.Next(200000);
                object s = hash["key" + index];
            }

            Console.WriteLine("Hashtable Time: {0}", (DateTime.Now - start).TotalSeconds);

            /****************************************************************************************************/
            start = DateTime.Now;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();


            for (int i = 1; i <= 2000000; i++)
            {
                dictionary["key" + i] = "value" + i;
            }

            for (int i = 1; i < 100000; i++)
            {
                Random r = new Random();
                int index = r.Next(2000000);
                string s = dictionary["key" + index];
            }

            Console.WriteLine("Dictionary Time: {0}", (DateTime.Now - start).TotalSeconds);


            /***********************************************MyHashTable<int>*****************************************************/
            start = DateTime.Now;

            MyHashTable<int> myHashG = new MyHashTable<int>();

            for (int i = 1; i <= 2000000; i++)
            {
                myHashG["key" + i] = i;
            }

            for (int i = 1; i < 100000; i++)
            {
                Random r = new Random();
                int index = r.Next(2000000);
                int s = myHashG["key" + index];
            }

            Console.WriteLine("MyHashTable generic Time: {0}", (DateTime.Now - start).TotalSeconds);


            /*********************************************MyHashTable*******************************************************/
            start = DateTime.Now;

            MyHashTable myHash = new MyHashTable();

            for (int i = 1; i <= 2000000; i++)
            {
                myHash["key" + i] = i;
            }

            for (int i = 1; i < 100000; i++)
            {
                Random r = new Random();
                int index = r.Next(2000000);
                int s = (int)myHash["key" + index];
            }

            Console.WriteLine("MyHashTable Time: {0}", (DateTime.Now - start).TotalSeconds);

            Console.ReadKey();
            //Console.WriteLine();
        }
    }

    public class MyHashTable : IEnumerable
    {
        private class Node
        {
            private string Key { get; set; }
            private object Value { get; set; }

            private Node Next { get; set; }

            public Node(string key, object value)
            {
                Key = key;
                Value = value;
            }

            public Node InsertNode(string key, object value)
            {
                Node newNode = new Node(key, value);
                newNode.Next = this;
                return newNode;
            }

            public object FindNodeValue(string key)
            {
                while (Key != key && Next != null)
                {
                    return Next.FindNodeValue(key);
                }

                if (key == Key)
                    return Value;

                return null;
            }
        }

        private const long MyHashTable_ARRAY_LENGTH = 2000000;
        private readonly Node[] _hashNodes = new Node[MyHashTable_ARRAY_LENGTH];
        private readonly List<string> _keys = new List<string>();
        private void SetValue(string key, object value)
        {
            _keys.Add(key);

            long hashKeysIndex = Math.Abs(key.GetHashCode()) % MyHashTable_ARRAY_LENGTH;

            if (_hashNodes[hashKeysIndex] == null)
            {
                _hashNodes[hashKeysIndex] = new Node(key, value);
            }
            else
            {
                _hashNodes[hashKeysIndex] = _hashNodes[hashKeysIndex].InsertNode(key, value);
            }
        }
        private object GetValue(string key)
        {
            long hashKeysIndex = Math.Abs(key.GetHashCode()) % MyHashTable_ARRAY_LENGTH;
            
            Node node = _hashNodes[hashKeysIndex];
            
            return node.FindNodeValue(key);
        }

        public IEnumerable Keys
        {
            get { return _keys.AsEnumerable(); }
        }
        public IEnumerator GetEnumerator()
        {
            return _keys.GetEnumerator();
        }

        public MyHashTable()
        { }

        public object this[string key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                SetValue(key, value);
            }
        }
    }


    public class MyHashTable<T> : IEnumerable
    {
        private class Node<T>
        {
            private string Key { get; set; }
            private T Value { get; set; }

            private Node<T> Next { get; set; }

            public Node(string key, T value)
            {
                Key = key;
                Value = value;
            }

            public Node<T> InsertNode(string key, T value)
            {
                Node<T> newNode = new Node<T>(key, value);
                newNode.Next = this;
                return newNode;
            }

            public T FindNodeValue(string key)
            {
                while (Key != key && Next != null)
                {
                    return Next.FindNodeValue(key);
                }

                if (key == Key)
                    return Value;

                return default(T);
            }
        }

        private const long MyHashTable_ARRAY_LENGTH = 500000;
        private readonly Node<T>[] _hashNodes = new Node<T>[MyHashTable_ARRAY_LENGTH];
        private readonly List<string> _keys = new List<string>();
        private void SetValue(string key, T value)
        {
            _keys.Add(key);

            long hashKeysIndex = Math.Abs(key.GetHashCode()) % MyHashTable_ARRAY_LENGTH;

            if (_hashNodes[hashKeysIndex] == null)
            {
                _hashNodes[hashKeysIndex] = new Node<T>(key, value);
            }
            else
            {
                _hashNodes[hashKeysIndex] = _hashNodes[hashKeysIndex].InsertNode(key, value);
            }
        }
        private T GetValue(string key)
        {
            long hashKeysIndex = Math.Abs(key.GetHashCode()) % MyHashTable_ARRAY_LENGTH;

            Node<T> node = _hashNodes[hashKeysIndex];

            return node.FindNodeValue(key);
        }

        public IEnumerable Keys
        {
            get { return _keys.AsEnumerable(); }
        }
        public IEnumerator GetEnumerator()
        {
            return _keys.GetEnumerator();
        }

        public MyHashTable()
        { }

        public T this[string key]
        {
            get
            {
                return GetValue(key);
            }
            set
            {
                SetValue(key, value);
            }
        }
    }
}
