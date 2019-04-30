using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class RemoveInvalidParentheses : _ProblemBase
    {
        int _extraLeftCount;
        int _extraRightCount;

        int _correctParentheseCount;
        string _initialExpression;
        HashSet<string> _validSolutions = new HashSet<string>();

        public override void MainRun()
        {
            //_initialExpression = Console.ReadLine();
            //_initialExpression = "()a)b(s(c()()f)";

            _initialExpression = "(((";


            CalcExtraParentheses();
            BuildValidExpressions(_initialExpression, 0, _extraLeftCount, _extraRightCount, 0, 0);
            Console.WriteLine(_count);


            PrintArrVertical(_validSolutions.ToList());
        }

        private void CalcExtraParentheses()
        {
            for (int i = 0; i < _initialExpression.Length; i++)
            {
                switch (_initialExpression[i])
                {
                    case '(':
                        _extraLeftCount++;
                        _correctParentheseCount++;
                        break;
                    case ')':
                        if (_extraLeftCount > 0)
                        {
                            _extraLeftCount--;
                        }
                        else
                        {
                            _extraRightCount++;
                        }
                        _correctParentheseCount++;
                        break;
                }
            }
            _correctParentheseCount = (_correctParentheseCount - (_extraLeftCount + _extraRightCount)) / 2;
        }
        private int _count = 0;
        private void BuildValidExpressions(string expression, int startIndex, int extraLeftCount, int extraRightCount, int countedLeft, int countedRight)
        {
            _count++;
            Console.WriteLine($"Exp: {expression}, I: {startIndex}, ELC: {extraLeftCount} ERC: {extraRightCount} L: {countedLeft} R: {countedRight}");
            if (startIndex == expression.Length)
            {
                Console.WriteLine();
                if (countedLeft == _correctParentheseCount && countedRight == _correctParentheseCount && extraRightCount == 0 && extraLeftCount == 0)
                {
                    if (!_validSolutions.Contains(expression))
                        _validSolutions.Add(expression);
                }
                return;
            }

            int i = startIndex;
            if (expression[i] != '(' && expression[i] != ')')
            {
                BuildValidExpressions(expression, i + 1, extraLeftCount, extraRightCount, countedLeft, countedRight);
            }
            else if (expression[i] == '(')
            {
                BuildValidExpressions(expression, i + 1, extraLeftCount, extraRightCount, countedLeft + 1, countedRight);

                if (extraLeftCount > 0)
                {
                    BuildValidExpressions(expression.Substring(0, i) + expression.Substring(i + 1), i, extraLeftCount - 1, extraRightCount, countedLeft, countedRight);
                }
            }
            else if (expression[i] == ')')
            {
                if (countedLeft > countedRight)
                {
                    BuildValidExpressions(expression, i + 1, extraLeftCount, extraRightCount, countedLeft, countedRight + 1);
                }

                if (extraRightCount > 0)
                {
                    BuildValidExpressions(expression.Substring(0, i) + expression.Substring(i + 1), i, extraLeftCount, extraRightCount - 1, countedLeft, countedRight);
                }
            }
        }
    }
}
