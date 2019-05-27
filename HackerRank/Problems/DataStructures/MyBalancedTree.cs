using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class MyBalancedTree<T> where T : IComparable
    {
        public T Value { get; set; }
        public MyBalancedTree<T> Right { get; set; }
        public MyBalancedTree<T> Left { get; set; }
        public int _rightHeight;
        public int _leftHeight;

        public MyBalancedTree()
        {
        }

        public MyBalancedTree(T t)
        {
            this.Value = t;
        }

        public MyBalancedTree<T> Add(T value)
        {
            if (Value.CompareTo(default(T)) == 0 && Left == null && Right == null)
            {
                Value = value;
                return this;
            }
            if (value.CompareTo(Value) < 0)
            {
                Left = Left == null ? new MyBalancedTree<T>(value) : Left.Add(value);
                _leftHeight = Math.Max(Left._leftHeight, Left._rightHeight) + 1;
            }
            else
            {
                Right = Right == null ? new MyBalancedTree<T>(value) : Right.Add(value);
                _rightHeight = Math.Max(Right._leftHeight, Right._rightHeight) + 1;
            }

            if (Math.Abs(_rightHeight - _leftHeight) > 1)
            {
                return RebalanceTree(this);
            }
            return this;
        }

        private MyBalancedTree<T> RebalanceTree(MyBalancedTree<T> root)
        {
            MyBalancedTree<T> newRoot = null;

            if (_leftHeight > _rightHeight)
            {
                if (root.Left._leftHeight < root.Left._rightHeight)
                {
                    MyBalancedTree<T> newSubRoot = root.Left.Right;
                    root.Left.Right = root.Left.Right.Right;
                    newSubRoot.Left = root.Left;
                    root.Left = newSubRoot;
                    root.Left._leftHeight++;
                    root.Left.Left._rightHeight--;
                }

                newRoot = root.Left;
                root.Left = newRoot.Right;
                newRoot.Right = root;

                newRoot.Right._leftHeight -= 2;
                newRoot._rightHeight++;
            }
            else
            {
                if (root.Right._rightHeight < root.Right._leftHeight)
                {
                    MyBalancedTree<T> newSubRoot = root.Right.Left;
                    root.Right.Left = root.Right.Left.Left;
                    newSubRoot.Right = root.Right;
                    root.Right = newSubRoot;
                    root.Right._rightHeight++;
                    root.Right.Right._leftHeight--;
                }

                newRoot = root.Right;
                root.Right = newRoot.Left;
                newRoot.Left = root;
                newRoot.Left._rightHeight -= 2;
                newRoot._leftHeight++;
            }

            return newRoot;
        }

        public static void Test()
        {
            MyBalancedTree<int> bt = new MyBalancedTree<int>();


            //bt = bt.Add(8);
            //bt = bt.Add(7);
            //bt = bt.Add(5);


            //bt = bt.Add(5);
            //bt = bt.Add(7);
            //bt = bt.Add(8);

            //bt = bt.Add(5);
            //bt = bt.Add(8);
            //bt = bt.Add(7);


            bt = bt.Add(8);
            bt = bt.Add(5);
            bt = bt.Add(7);

            //bt.Add(9);
            //bt.Add(-7);

            bt = bt.Add(20);
            bt = bt.Add(15);
            bt = bt.Add(25);
            bt = bt.Add(18);
            bt = bt.Add(10);
            bt = bt.Add(-10);
            bt = bt.Add(-15);
            bt = bt.Add(-20);
            bt = bt.Add(-30);

            //for (int i = 0; i < 5; i++)
            //{
            //    bt.Add(5 + i);
            //    if (i > 0)
            //        bt.Add(5 - i);
            //}
        }
    }
}
