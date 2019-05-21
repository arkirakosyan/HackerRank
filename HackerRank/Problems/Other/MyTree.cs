using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class MyTreeManager : _ProblemBase
    {
        public override void MainRun()
        {
            MyTree tree = new MyTree();
            //tree.AddRange(new int[] { 5, 6, 4, 7, 3, 8, 2 });
            tree.AddRange(new int[] { 5, 3, 7, 6, 8, 2, 4 });

            tree.InOrderTeraversal();
        }
    }

    public class MyTree
    {
        public int Value { get; set; }
        public MyTree Right { get; set; }
        public MyTree Left { get; set; }

        public MyTree(int value)
        {
            Value = value;
        }
        public MyTree()
        {
            Value = int.MinValue;
        }
        public void AddRange(int[] arr)
        {
            foreach (int val in arr)
            {
                Add(val);
            }
        }
        public void Add(int value)
        {
            if (Value == int.MinValue)
            {
                Value = value;
                return;
            }

            if (value > Value)
            {
                if (Right == null)
                {
                    Right = new MyTree(value);
                }
                else
                {
                    Right.Add(value);
                }
            }
            else
            {
                if (Left == null)
                {
                    Left = new MyTree(value);
                }
                else
                {
                    Left.Add(value);
                }
            }
        }

        public void InOrderTeraversal()
        {
            if (Left != null) Left.InOrderTeraversal();
            Console.WriteLine(Value.ToString() + " ");
            if (Right != null) Right.InOrderTeraversal();

        }

        public void LevelOrderTraversal()
        {

        }
    }
}
