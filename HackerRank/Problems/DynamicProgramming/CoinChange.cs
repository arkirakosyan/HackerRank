using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.DynamicProgramming
{
    public class CoinChange : _ProblemBase
    {
        public override void MainRun()
        {
            int[] coins = new int[] { 1, 3, 5, 7 };
            Print(CoinChangeBottomUp(coins, 8));
        }

        private int CoinChangeRecursive(int[] coins, int i, int sum)
        {
            if (sum <= 0) return 0;

            if (i == 0) return sum % coins[i] == 0 ? sum / coins[i] : int.MaxValue;

            int minCoinsCount = CoinChangeRecursive(coins, i - 1, sum);

            int currentCointMaxUseCount = sum / coins[i];

            while (currentCointMaxUseCount > 0)
            {
                minCoinsCount = Math.Min(CoinChangeRecursive(coins, i - 1, sum - currentCointMaxUseCount * coins[i]) + currentCointMaxUseCount, minCoinsCount);
                currentCointMaxUseCount--;
            }

            return minCoinsCount;
        }

        private int CoinChangeBottomUp(int[] coins, int sum)
        {
            int[,] table = new int[coins.Length + 1, sum + 1];
            for (int i = 0; i <= sum; i++)
            {
                table[0, i] = int.MaxValue;
            }

            for (int i = 1; i <= coins.Length; i++)
            {
                for(int j = 1; j <= sum; j++)
                {
                    int minCoinsCount = table[i - 1, j];
                    int currentCoinMaxUseCount = j / coins[i - 1];
                    while(currentCoinMaxUseCount > 0)
                    {
                        minCoinsCount = Math.Min(currentCoinMaxUseCount + table[i, j - currentCoinMaxUseCount * coins[i - 1]], minCoinsCount);
                        currentCoinMaxUseCount--;
                    }
                    table[i, j] = minCoinsCount;
                }
            }

            return table[coins.Length, sum];
        }
    }
}
