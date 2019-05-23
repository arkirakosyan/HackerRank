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
            tree.AddRange(new int[] { 5, 3, 7, 4, 2, 6, 8, 1, 9 });

            //tree.AddRange(new int[] { 4,7,8,3,6,5,2 });


            //tree.InOrderTeraversal();
            //Console.WriteLine();
            //tree.PostOrderTeraversal();
            tree.LevelOrderTraversal();
            Console.WriteLine();
            tree.IsTreeMirrored();
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
            Stack<MyTree> nodes1 = new Stack<MyTree>();

            nodes.Push(this);
            bool popFromFirst = true;
            while (nodes.Count > 0 || nodes1.Count > 0)
            {
                if (nodes.Count > 0 && popFromFirst)
                {
                    var node = nodes.Pop();
                    Console.Write(node.Value + " ");

                    if (node.Right != null) nodes1.Push(node.Right);
                    if (node.Left != null) nodes1.Push(node.Left);

                    if (popFromFirst != nodes.Count > 0)
                    {
                        Console.WriteLine();
                        popFromFirst = nodes.Count > 0;
                    }
                }
                else if (nodes1.Count > 0 && !popFromFirst)
                {
                    var node = nodes1.Pop();
                    Console.Write(node.Value + " ");

                    if (node.Left != null) nodes.Push(node.Left);
                    if (node.Right != null) nodes.Push(node.Right);

                    if (popFromFirst != !(nodes1.Count > 0))
                    {
                        Console.WriteLine();
                        popFromFirst = !(nodes1.Count > 0);
                    }
                }

            }
        }

        public bool IsTreeMirrored()
        {
            Queue<MyTree> levelNOdes = new Queue<MyTree>();
            Queue<MyTree> levelNOdes1 = new Queue<MyTree>();

            bool userFirstQueue = true;
            List<int> values = new List<int>();

            levelNOdes.Enqueue(this);

            while (levelNOdes.Count > 0 || levelNOdes1.Count > 0)
            {
                if (userFirstQueue && levelNOdes.Count > 0)
                {
                    var node = levelNOdes.Dequeue();
                    values.Add(node.Value);

                    if (node.Left != null) levelNOdes1.Enqueue(node.Left);
                    if (node.Right != null) levelNOdes1.Enqueue(node.Right);

                    if (userFirstQueue != (levelNOdes.Count > 0))
                    {
                        userFirstQueue = false;
                        if (IsListMirrored(values))
                        {
                            Console.WriteLine("NO!");
                            return false;
                        }
                        values.Clear();
                    }
                }
                else if (!userFirstQueue && levelNOdes1.Count > 0)
                {
                    var node = levelNOdes1.Dequeue();
                    values.Add(node.Value);

                    if (node.Left != null) levelNOdes.Enqueue(node.Left);
                    if (node.Right != null) levelNOdes.Enqueue(node.Right);

                    if (userFirstQueue != !(levelNOdes1.Count > 0))
                    {
                        userFirstQueue = true;
                        if (IsListMirrored(values))
                        {
                            Console.WriteLine("NO!");
                            return false;
                        }
                        values.Clear();
                    }
                }
            }
            Console.WriteLine("YES!");

            return true;
        }

        private bool IsListMirrored(List<int> list)
        {
            int n = list.Count - 1;
            for (int i = 0; i <= n / 2; i++)
            {
                if (list[i] != list[n - i])
                {
                    return false;
                }
            }
            return true;
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
