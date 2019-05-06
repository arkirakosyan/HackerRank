using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.GeekForGeeks
{
    public class NumberManipulations : _ProblemBase
    {
        public override void MainRun()
        {
            AllPrimeFactors(568733);
        }

        public int AllPrimeFactors(int n)
        {
            bool primeFound = false;
            while (n % 2 == 0)
            {
                if (!primeFound)
                {
                    Console.Write(2 + " ");
                    primeFound = true;
                }
                n /= 2;
            }

            // n must be odd at this point. So we can 
            // skip one element (Note i = i +2) 
            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                primeFound = false;
                // While i divides n, print i and divide n 
                while (n % i == 0)
                {
                    if (!primeFound)
                    {
                        Console.Write(i + " ");
                        primeFound = true;
                    }
                    n /= i;
                }
            }

            // This condition is to handle the case when 
            // n is a prime number greater than 2 
            if (n > 2)
                Console.Write(n);

            return n;
        }
    }
}
