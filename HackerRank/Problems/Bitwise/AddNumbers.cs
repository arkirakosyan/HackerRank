using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Bitwise
{
    public class AddNumbers : _ProblemBase
    {
        public override void MainRun()
        {
            //Console.WriteLine(AddRecursve(58888, 7));
            Console.WriteLine(Subtract(58888, 7));

            Console.WriteLine(Test(10));

        }

        int Add(int x, int y)
        {
            // Iterate till there is no carry 
            while (y != 0)
            {
                // carry now contains common 
                // set bits of x and y 
                int carry = x & y;

                // Sum of bits of x and  
                // y where at least one  
                // of the bits is not set 
                x = x ^ y;

                // Carry is shifted by  
                // one so that adding it  
                // to x gives the required sum 
                y = carry << 1;
            }
            return x;
        }

        int AddRecursve(int x, int y)
        {
            if (y == 0) return x;

            return AddRecursve(x ^ y, (x & y) << 1);
        }

        int Subtract(int x, int y)
        {
            y = AddRecursve(~y, 1);
            return AddRecursve(x, y);
        }

        int Test(int y)
        {
            return (int)Math.Sqrt(10);
            if (y == 0) return 0;

            return y + Test(y - 1);
        }
    }
}
