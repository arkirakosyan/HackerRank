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
            tree.AddRange(new int[] { 5,3, 7, 4, 2, 6, 8 });

            //tree.AddRange(new int[] { 4,7,8,3,6,5,2 });


            //tree.InOrderTeraversal();
            //Console.WriteLine();
            //tree.PostOrderTeraversal();
            tree.LevelOrderTraversal();
            Console.WriteLine();

            //tree.PreOrderTeraversal();

            Console.WriteLine(tree.CalcTreeHeight());
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
            Console.Write(Value.ToString() + " ");
            if (Right != null) Right.InOrderTeraversal();
        }

        public void PreOrderTeraversal()
        {
            Console.Write(Value.ToString() + " ");
            if (Left != null) Left.InOrderTeraversal();
            if (Right != null) Right.InOrderTeraversal();
        }

        public void PostOrderTeraversal()
        {
            if (Left != null) Left.InOrderTeraversal();
            if (Right != null) Right.InOrderTeraversal();
            Console.Write(Value.ToString() + " ");
        }

        public void LevelOrderTraversal()
        {
            Stack<MyTree> nodes = new Stack<MyTree>();
            Queue<MyTree> nodes1 = new Queue<MyTree>();

            nodes.Push(this);

            bool traversalFinished = false;
            bool orderLeftToRight = true;
            while (!traversalFinished)
            {
                while (nodes.Count > 0)
                {
                    MyTree myTree = nodes.Pop();

                    Console.Write(myTree.Value.ToString() + " ");


                    if (myTree.Left != null) nodes1.Enqueue(myTree.Left);
                    if (myTree.Right != null) nodes1.Enqueue(myTree.Right);

                }

                while (nodes1.Count > 0)
                {
                    nodes.Push(nodes1.Dequeue());
                }
              
                Console.WriteLine(" ");
               // orderLeftToRight = !orderLeftToRight;
                nodes1.Clear();
                if (nodes.Count == 0) traversalFinished = true;
            }

        }
        public int CalcTreeHeight()
        {
            if (Left == null && Right == null) return 1;

            if (Left == null && Right != null) return Right.CalcTreeHeight() + 1;
            if (Left != null && Right == null) return Left.CalcTreeHeight() + 1;

            return Math.Max(Left.CalcTreeHeight(), Right.CalcTreeHeight()) + 1;
        }
    }
}
