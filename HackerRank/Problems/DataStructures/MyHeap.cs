using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class MyHeap
    {
        private readonly List<int> _arr = new List<int>();
        private int LastIndex { get { return Size - 1; } }

        private int Root
        {
            get
            {
                if (Size == 0)
                    throw new ArgumentOutOfRangeException();
                return _arr[0];
            }
            set
            {
                if (Size == 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _arr[0] = value;
                }
            }
        }
        private int LeftIndex(int index)
        {
            return index * 2 + 1;
        }
        private int? LeftValue(int index)
        {
            int leftIndex = LeftIndex(index);
            if (leftIndex >= Size) return null;

            return _arr[leftIndex];
        }
        private int RightIndex(int index)
        {
            return index * 2 + 2;
        }
        private int? RightValue(int index)
        {
            int rightIndex = RightIndex(index);
            if (rightIndex >= Size) return null;
            return _arr[rightIndex];
        }
        private int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        private int? ParentValue(int index)
        {
            if (index <= 0) return null;

            return _arr[ParentIndex(index)];
        }


        public int Size { get; private set; }
        public void Add(int value)
        {
            if (_arr.Count > Size)
            {
                _arr[Size] = value;
            }
            else
            {
                _arr.Add(value);
            }
            Size++;
            pullUp(Size - 1);
        }
        public int Peek()
        {
            return Root;
        }
        public int Poll()
        {
            int result = Root;
            Root = _arr[LastIndex];
            Size--;
           // _arr.RemoveAt(Size);
            pushDown(0);

            return result;
        }
        private void pullUp(int index)
        {
            if (index > 0 && _arr[index] < ParentValue(index))
            {
                int parentIndex = ParentIndex(index);
                swap(index, parentIndex);
                pullUp(parentIndex);
            }
        }

        private void pushDown(int index)
        {
            int swapIndex = index;
            if (LeftValue(index).HasValue && RightValue(index).HasValue)
            {
                swapIndex = LeftValue(index) < RightValue(index) ? LeftIndex(index) : RightIndex(index);
            }
            else
            {
                swapIndex = LeftValue(index).HasValue ? LeftIndex(index) : RightValue(index).HasValue ? RightIndex(index) : index;
            }

            if(_arr[index] > _arr[swapIndex] && swapIndex > index)
            {
                swap(index, swapIndex);
                pushDown(swapIndex);
            }
        }

        private void swap(int i, int j)
        {
            int temp = _arr[i];
            _arr[i] = _arr[j];
            _arr[j] = temp;
        }
    }
}
