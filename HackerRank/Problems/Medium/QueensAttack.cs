using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems
{
    public class QueensAttack : _ProblemBase
    {
        public override void MainRun()
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            string[] r_qC_q = Console.ReadLine().Split(' ');

            int r_q = Convert.ToInt32(r_qC_q[0]);

            int c_q = Convert.ToInt32(r_qC_q[1]);

            int[][] obstacles = new int[k][];

            for (int i = 0; i < k; i++)
            {
                obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
            }

            int result = queensAttack(n, k, r_q, c_q, obstacles);
            Console.WriteLine(result);
        }

        private int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            int lu = Math.Min(r_q - 1, n - c_q);
            int cu = n - c_q;
            int ru = Math.Min(n - r_q, n - c_q);

            int cl = r_q - 1;
            int cr = n - r_q;

            int ld = Math.Min(c_q - 1, r_q - 1);
            int cd = c_q - 1;
            int rd = Math.Min(n - r_q, c_q - 1);

            int temp_lu = 0;
            int temp_cu = 0;
            int temp_ru = 0;
            int temp_cl = 0;
            int temp_cr = 0;
            int temp_ld = 0;
            int temp_cd = 0;
            int temp_rd = 0;


            //int luO, 
            for (int i = 0; i < obstacles.Length; i++)
            {
                var a = obstacles[i];

                if (a[0] + a[1] == r_q + c_q)
                {
                    if (a[0] < r_q)
                    {
                        int t = Math.Min(a[0] - 1, n - a[1]);
                        if (t > temp_lu)
                        {
                            int x = temp_lu > 0 ? 0 : 1;
                            temp_lu = t - temp_lu;
                            lu = lu - temp_lu - x;
                        }
                    }
                    else
                    {
                        int t = Math.Min(n - a[0], a[1] - 1);
                        if (t > temp_rd)
                        {
                            int x = temp_rd > 0 ? 0 : 1;
                            temp_rd = t - temp_rd;
                            rd = rd - temp_rd - x;
                        }
                    }
                    continue;
                }

                if (a[0] - r_q == a[1] - c_q)
                {
                    if (a[0] < r_q)
                    {
                        int t = Math.Max(Math.Min(a[0] - 1, a[1] - 1), 0);

                        if (t > temp_ld)
                        {
                            int x = temp_ld > 0 ? 0 : 1;
                            temp_ld = t - temp_ld;
                            ld = ld - temp_ld - x;
                        }
                    }
                    else
                    {
                        int t = Math.Min(n - a[0], n - a[1]);
                        if (t > temp_ru)
                        {
                            int x = temp_ru > 0 ? 0 : 1;
                            temp_ru = t - temp_ru;
                            ru = ru - temp_ru - x;
                        }
                    }
                    continue;
                }

                if (a[0] == r_q)
                {
                    if (a[1] > c_q)
                    {
                        int t = Math.Max(n - a[1], 0);

                        if (t > temp_cu)
                        {
                            int x = temp_cu > 0 ? 0 : 1;
                            temp_cu = t - temp_cu;
                            cu = cu - temp_cu - x;
                        }
                    }
                    else
                    {
                        int t = Math.Max(a[1] - 1, 0);

                        if (t > temp_cd)
                        {
                            int x = temp_cd > 0 ? 0 : 1;
                            temp_cd = t - temp_cd;
                            cd = cd - temp_cd - x;
                        }
                    }
                    continue;
                }

                if (a[1] == c_q)
                {
                    if (a[0] < r_q)
                    {
                        int t = Math.Max(a[0] - 1, 0);

                        if (t > temp_cl)
                        {
                            int x = temp_cl > 0 ? 0 : 1;
                            temp_cl = t - temp_cl;
                            cl = cl - temp_cl - x;
                        }
                    }
                    else
                    {
                        int t = n - a[0];

                        if (t > temp_cr)
                        {
                            int x = temp_cr > 0 ? 0 : 1;
                            temp_cr = t - temp_cr;
                            cr = cr - temp_cr - x;
                        }
                    }
                    continue;
                }
            }

            return lu + cu + ru + cl + cr + ld + cd + rd;
        }
    }
}
