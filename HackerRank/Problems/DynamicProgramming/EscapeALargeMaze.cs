using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.DynamicProgramming
{
    public class EscapeALargeMaze : _ProblemBase
    {
        public override void MainRun()
        {
            int[][] xx = new int[][] { new int[] { 0, 199 }, new int[] { 1, 198 }, new int[] { 2, 197 }, new int[] { 3, 196 }, new int[] { 4, 195 }, new int[] { 5, 194 }, new int[] { 6, 193 }, new int[] { 7, 192 }, new int[] { 8, 191 }, new int[] { 9, 190 }, new int[] { 10, 189 }, new int[] { 11, 188 }, new int[] { 12, 187 }, new int[] { 13, 186 }, new int[] { 14, 185 }, new int[] { 15, 184 }, new int[] { 16, 183 }, new int[] { 17, 182 }, new int[] { 18, 181 }, new int[] { 19, 180 }, new int[] { 20, 179 }, new int[] { 21, 178 }, new int[] { 22, 177 }, new int[] { 23, 176 }, new int[] { 24, 175 }, new int[] { 25, 174 }, new int[] { 26, 173 }, new int[] { 27, 172 }, new int[] { 28, 171 }, new int[] { 29, 170 }, new int[] { 30, 169 }, new int[] { 31, 168 }, new int[] { 32, 167 }, new int[] { 33, 166 }, new int[] { 34, 165 }, new int[] { 35, 164 }, new int[] { 36, 163 }, new int[] { 37, 162 }, new int[] { 38, 161 }, new int[] { 39, 160 }, new int[] { 40, 159 }, new int[] { 41, 158 }, new int[] { 42, 157 }, new int[] { 43, 156 }, new int[] { 44, 155 }, new int[] { 45, 154 }, new int[] { 46, 153 }, new int[] { 47, 152 }, new int[] { 48, 151 }, new int[] { 49, 150 }, new int[] { 50, 149 }, new int[] { 51, 148 }, new int[] { 52, 147 }, new int[] { 53, 146 }, new int[] { 54, 145 }, new int[] { 55, 144 }, new int[] { 56, 143 }, new int[] { 57, 142 }, new int[] { 58, 141 }, new int[] { 59, 140 }, new int[] { 60, 139 }, new int[] { 61, 138 }, new int[] { 62, 137 }, new int[] { 63, 136 }, new int[] { 64, 135 }, new int[] { 65, 134 }, new int[] { 66, 133 }, new int[] { 67, 132 }, new int[] { 68, 131 }, new int[] { 69, 130 }, new int[] { 70, 129 }, new int[] { 71, 128 }, new int[] { 72, 127 }, new int[] { 73, 126 }, new int[] { 74, 125 }, new int[] { 75, 124 }, new int[] { 76, 123 }, new int[] { 77, 122 }, new int[] { 78, 121 }, new int[] { 79, 120 }, new int[] { 80, 119 }, new int[] { 81, 118 }, new int[] { 82, 117 }, new int[] { 83, 116 }, new int[] { 84, 115 }, new int[] { 85, 114 }, new int[] { 86, 113 }, new int[] { 87, 112 }, new int[] { 88, 111 }, new int[] { 89, 110 }, new int[] { 90, 109 }, new int[] { 91, 108 }, new int[] { 92, 107 }, new int[] { 93, 106 }, new int[] { 94, 105 }, new int[] { 95, 104 }, new int[] { 96, 103 }, new int[] { 97, 102 }, new int[] { 98, 101 }, new int[] { 99, 100 }, new int[] { 100, 99 }, new int[] { 101, 98 }, new int[] { 102, 97 }, new int[] { 103, 96 }, new int[] { 104, 95 }, new int[] { 105, 94 }, new int[] { 106, 93 }, new int[] { 107, 92 }, new int[] { 108, 91 }, new int[] { 109, 90 }, new int[] { 110, 89 }, new int[] { 111, 88 }, new int[] { 112, 87 }, new int[] { 113, 86 }, new int[] { 114, 85 }, new int[] { 115, 84 }, new int[] { 116, 83 }, new int[] { 117, 82 }, new int[] { 118, 81 }, new int[] { 119, 80 }, new int[] { 120, 79 }, new int[] { 121, 78 }, new int[] { 122, 77 }, new int[] { 123, 76 }, new int[] { 124, 75 }, new int[] { 125, 74 }, new int[] { 126, 73 }, new int[] { 127, 72 }, new int[] { 128, 71 }, new int[] { 129, 70 }, new int[] { 130, 69 }, new int[] { 131, 68 }, new int[] { 132, 67 }, new int[] { 133, 66 }, new int[] { 134, 65 }, new int[] { 135, 64 }, new int[] { 136, 63 }, new int[] { 137, 62 }, new int[] { 138, 61 }, new int[] { 139, 60 }, new int[] { 140, 59 }, new int[] { 141, 58 }, new int[] { 142, 57 }, new int[] { 143, 56 }, new int[] { 144, 55 }, new int[] { 145, 54 }, new int[] { 146, 53 }, new int[] { 147, 52 }, new int[] { 148, 51 }, new int[] { 149, 50 }, new int[] { 150, 49 }, new int[] { 151, 48 }, new int[] { 152, 47 }, new int[] { 153, 46 }, new int[] { 154, 45 }, new int[] { 155, 44 }, new int[] { 156, 43 }, new int[] { 157, 42 }, new int[] { 158, 41 }, new int[] { 159, 40 }, new int[] { 160, 39 }, new int[] { 161, 38 }, new int[] { 162, 37 }, new int[] { 163, 36 }, new int[] { 164, 35 }, new int[] { 165, 34 }, new int[] { 166, 33 }, new int[] { 167, 32 }, new int[] { 168, 31 }, new int[] { 169, 30 }, new int[] { 170, 29 }, new int[] { 171, 28 }, new int[] { 172, 27 }, new int[] { 173, 26 }, new int[] { 174, 25 }, new int[] { 175, 24 }, new int[] { 176, 23 }, new int[] { 177, 22 }, new int[] { 178, 21 }, new int[] { 179, 20 }, new int[] { 180, 19 }, new int[] { 181, 18 }, new int[] { 182, 17 }, new int[] { 183, 16 }, new int[] { 184, 15 }, new int[] { 185, 14 }, new int[] { 186, 13 }, new int[] { 187, 12 }, new int[] { 188, 11 }, new int[] { 189, 10 }, new int[] { 190, 9 }, new int[] { 191, 8 }, new int[] { 192, 7 }, new int[] { 193, 6 }, new int[] { 194, 5 }, new int[] { 195, 4 }, new int[] { 196, 3 }, new int[] { 197, 2 }, new int[] { 198, 1 }, new int[] { 199, 0 } };
            //var t = IsEscapePossible1(xx, new int[] { 0, 0 }, new int[] { 200, 200 });
            var t = IsEscapePossible1(new int[][] { new int[] { 0, 3 }, new int[] { 1, 0 } , new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 1, 3 } }, new int[] { 0, 0 }, new int[] { 0, 2 });



            // var t = IsEscapePossible1(new int[][] { new int[] { 1, 0 } }, new int[] { 0, 0 }, new int[] { 0, 2 });

        }
        //struct Cord
        //{
        //    public int X;
        //    public int Y;
        //    public bool IsVisited;
        //    public Cord(int x, int y)
        //    {
        //        X = x;
        //        Y = y;
        //        IsVisited = false;
        //    }
        //}
        public bool IsEscapePossible(int[][] blocked, int[] source, int[] target)
        {
            if (blocked.Length < 3) return true;

            const int GRID_SIZE = 210;
            HashSet<string> blockedSquares = new HashSet<string>();
            foreach (var b in blocked)
            {
                blockedSquares.Add(b[0] + "_" + b[1]);
            }

            Queue<int[]> cordinates = new Queue<int[]>();
            cordinates.Enqueue(source);
            while (cordinates.Count > 0)
            {
                var cordinate = cordinates.Dequeue();
                if (blockedSquares.Contains(cordinate[0] + "_" + cordinate[1]))
                {
                    continue;
                }
                if (cordinate[0] == target[0] && cordinate[1] == target[1]) return true;

                blockedSquares.Add(cordinate[0] + "_" + cordinate[1]);


                if (cordinate[0] > 0)
                {
                    cordinates.Enqueue(new int[] { cordinate[0] - 1, cordinate[1] });
                }
                if (cordinate[0] < GRID_SIZE - 1)
                {
                    cordinates.Enqueue(new int[] { cordinate[0] + 1, cordinate[1] });
                }
                if (cordinate[0] > 0)
                {
                    cordinates.Enqueue(new int[] { cordinate[0], cordinate[1] - 1 });
                }
                if (cordinate[1] < GRID_SIZE - 1)
                {
                    cordinates.Enqueue(new int[] { cordinate[0], cordinate[1] + 1 });
                }

               
            }

            return false;
        }


        public bool IsEscapePossible1(int[][] blocked, int[] source, int[] target)
        {
            if (blocked.Length < 2) return true;

            const int GRID_SIZE = 1000000;
            HashSet<long> blockedSquares = new HashSet<long>();
            HashSet<long> sourceVisitedSquares = new HashSet<long>();
            HashSet<long> targetVisitedSquares = new HashSet<long>();
            int[] adj = new int[] { 0, 0, 1, -1 };
            foreach (var b in blocked)
            {
                blockedSquares.Add(b[0]*GRID_SIZE + b[1]);
            }
            int maxTappedCords = blocked.Length * (blocked.Length + 1) / 2;
            Queue<int[]> sourceCordinates = new Queue<int[]>();
            sourceCordinates.Enqueue(source);

            Queue<int[]> targetCordinates = new Queue<int[]>();
            targetCordinates.Enqueue(target);
            bool sourceTurn = true;

            while (sourceCordinates.Count > 0 && targetCordinates.Count > 0)
            {
                if (sourceVisitedSquares.Count > maxTappedCords && targetVisitedSquares.Count > maxTappedCords)
                    return true;

                if (sourceTurn && sourceCordinates.Count > 0)
                {
                    var cordinate = sourceCordinates.Dequeue();
                    long cordKey = GRID_SIZE * cordinate[0] + cordinate[1];
                    if (targetVisitedSquares.Contains(cordKey))
                    {
                        return true;
                    }
                    
                    for (int i = 0; i < adj.Length; i++)
                    {
                        int[] newCord = new int[] { cordinate[0] + adj[i], cordinate[1] + adj[(i + 2) % 4] };
                        if (newCord[0] < 0 || newCord[0] >= GRID_SIZE || newCord[1] < 0 || newCord[1] >= GRID_SIZE) continue;
                        long newCordKey = GRID_SIZE * newCord[0] + newCord[1];
                        if (blockedSquares.Contains(newCordKey) || sourceVisitedSquares.Contains(newCordKey)) continue;
                        sourceCordinates.Enqueue(newCord);
                        sourceVisitedSquares.Add(newCordKey);
                    }
                    sourceTurn = false;
                }
                else
                {
                    var cordinate = targetCordinates.Dequeue();
                    long cordKey = GRID_SIZE * cordinate[0] + cordinate[1];

                    if (sourceVisitedSquares.Contains(cordKey))
                    {
                        return true;
                    }
                    for (int i = 0; i < adj.Length; i++)
                    {
                        int[] newCord = new int[] { cordinate[0] + adj[i], cordinate[1] + adj[(i + 2) % 4] };
                        if (newCord[0] < 0 || newCord[0] >= GRID_SIZE || newCord[1] < 0 || newCord[1] >= GRID_SIZE) continue;
                        long newCordKey = GRID_SIZE * newCord[0] + newCord[1];
                        if (blockedSquares.Contains(newCordKey) || targetVisitedSquares.Contains(newCordKey)) continue;
                        targetCordinates.Enqueue(newCord);
                        targetVisitedSquares.Add(newCordKey);
                    }
                    sourceTurn = true;
                }
            }
            return false;
        }
    }
}
