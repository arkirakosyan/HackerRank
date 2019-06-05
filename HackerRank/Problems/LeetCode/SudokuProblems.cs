using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class SudokuProblems : _ProblemBase
    {
        public override void MainRun()
        {
            //char[] aa = new char[][] { { '5', '3', '.', '.', '7', '.', '.', '.', '.' } };

            char[,] board = new char[9,9] {{'5', '3', '.', '.', '7', '.', '.', '.', '.' },
                       { '6', '.', '.', '1', '9', '5', '.', '.', '.'},
                       {'.', '9', '8', '.', '.', '.', '.', '6', '.'},
                       {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                       {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                       {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                       {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                       {'.', '.', '.', '4', '1', '9', '.', '.', '5' },
                       { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            Print(IsValidSudoku1(board));

        }

        public bool IsValidSudoku1(char[,] board)
        {
            for (int i = 0; i < 9; i++)
            {
                bool[] row = new bool[9];
                bool[] col = new bool[9];

                bool boxRow = (i - 1) % 3 == 0;
                for (int j = 0; j < 9; j++)
                {
                    if (board[i,j] != '.')
                    {
                        if (row[board[i,j] - '1'])
                        {
                            return false;
                        }
                        row[board[i,j] - '1'] = true;
                    }

                    if (board[j,i] != '.')
                    {
                        if (col[board[j,i] - '1'])
                        {
                            return false;
                        }
                        col[board[j,i] - '1'] = true;
                    }

                    if (boxRow && (j - 1) % 3 == 0)
                    {
                        if (!IsValidBox1(board, i, j))
                        {
                            return false;
                        }
                    }

                }
            }

            return true;
        }

        private bool IsValidBox1(char[,] board, int i, int j)
        {
            bool[] a = new bool[9];
            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    if (board[k,l] != '.')
                    {
                        if (a[board[k,l] - '1'])
                        {
                            return false;
                        }
                        a[board[k,l] - '1'] = true;
                    }
                }
            }

            return true;
        }


        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                bool[] row = new bool[9];
                bool[] col = new bool[9];

                bool boxRow = (i - 1) % 3 == 0;
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        if (row[board[i][j] - '1'])
                        {
                            return false;
                        }
                        row[board[i][j] - '1'] = true;
                    }

                    if (board[j][i] != '.')
                    {
                        if (col[board[j][i] - '1'])
                        {
                            return false;
                        }
                        col[board[j][i] - '1'] = true;
                    }

                    if (boxRow && (j - 1) % 3 == 0)
                    {
                        if (!IsValidBox(board, i, j))
                        {
                            return false;
                        }
                    }

                }
            }

            return true;
        }

        private bool IsValidBox(char[][] board, int i, int j)
        {
            bool[] a = new bool[9];
            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    if (board[k][l] != '.')
                    {
                        if (a[board[k][l] - '1'])
                        {
                            return false;
                        }
                        a[board[k][l] - '1'] = true;
                    }
                }
            }

            return true;
        }

    }
}
