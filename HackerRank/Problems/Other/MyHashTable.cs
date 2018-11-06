using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
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

        private const long MyHashTable_ARRAY_LENGTH = 100000;
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
}
