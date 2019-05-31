using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class DivideTwoIntegers : _ProblemBase
    {
        public override void MainRun()
        {
            Print(Divide(int.MinValue, -1));
        }
        private long Abs(int i)
        {
            long iLong = i;
            if (i < 0) return -iLong;
            return iLong;
        }
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();
            bool isResultNegative = divisor > 0 && dividend < 0 || dividend > 0 && divisor < 0;
            long longDivisor = Abs(divisor);
            long longDividend = Abs(dividend);

            if (longDividend < longDivisor) return 0;

            long result = 0;
            long bigDivisor = 0;

            while (bigDivisor <= longDividend - longDivisor)
            {

                long tempDivisor = longDivisor;
                int tempResult = 1;

                while (tempDivisor << 1 < longDividend - bigDivisor)
                {
                    tempResult = tempResult << 1;
                    tempDivisor = tempDivisor << 1;
                }
                bigDivisor += tempDivisor;
                result += tempResult;
            }

           
            if(isResultNegative)
                return -(int)result;
            return result > int.MaxValue ? int.MaxValue : (int)result;
        }
    }
}
