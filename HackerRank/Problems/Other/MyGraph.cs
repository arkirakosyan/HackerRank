using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class MyGraphManager : _ProblemBase
    {
        public override void MainRun()
        {
            int matrixRank = Convert.ToInt16(Console.ReadLine());

            int[][] matrix = new int[matrixRank][];

            for (int i = 0; i < matrixRank; i++)
            {
                matrix[i] = Array.ConvertAll(Console.ReadLine().Split(' '), v => Convert.ToInt32(v));
            }

            Graph graph = new Graph();

            graph.Init(matrix);

            foreach (Node n in graph.Nodes.Values)
            {
                string adjacency = $"NODE: {n.Value} --> ";
                foreach (Node a in n.Adjacency)
                {
                    adjacency += $"{a.Value}, ";
                }

                Console.WriteLine(adjacency);
            }

            Console.ReadKey();

            graph.DFS(9, 6);
        }

    }

    public class Graph
    {
        public Dictionary<int, Node> Nodes { get; set; } = new Dictionary<int, Node>();

        public void Init(int[][] graphMatrix)
        {
            for (int i = 0; i < graphMatrix.Length; i++)
            {
                if (!Nodes.ContainsKey(i))
                {
                    Nodes.Add(i, new Node(graphMatrix[i][i]));
                }
                Node graphNode = Nodes[i];

                for (int j = 0; j < graphMatrix[i].Length; j++)
                {
                    if (graphMatrix[i][j] > 0 && i != j)
                    {
                        if (!Nodes.ContainsKey(j))
                        {
                            Nodes.Add(j, new Node(graphMatrix[j][j]));
                        }
                        Node adjacencyNode = Nodes[j];
                        graphNode.Adjacency.Add(adjacencyNode);
                    }
                }
            }
        }

        public void DFS(int start, int end)
        {
           Node startNode = Nodes.Values.Where(x => x.Value == start).FirstOrDefault();
            startNode.Visited = true;

            dfs(startNode, end, start, 0);
        }

        private void dfs(Node node, int end, int start, int depth)
        {
            Console.WriteLine($"{node.Value} node is in {depth} far from {start}");
            node.Visited = true;

            if (node.Value == end)
            {
                Console.WriteLine($"{end} is found in {depth} far from {start}");
            }

            foreach (Node child in node.Adjacency)
            {
                if(!child.Visited)
                    dfs(child, end, start, depth + 1);
            }
        }
    }

    public class Node
    {
        public Node()
        {
            Adjacency = new List<Node>();
        }

        public Node(int value)
        {
            Value = value;
        }
        public bool Visited { get; set; }
        public int Value { get; set; }
        public List<Node> Adjacency { get; set; } = new List<Node>();
    }
}
