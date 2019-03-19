using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.Other
{
    public class StepsCount : _ProblemBase
    {
        private int _endStep = 50;
        public override void MainRun()
        {
            PrintLine( StepsCounter1(_endStep));
            PrintLine(StepsCounter2());
            PrintLine(StepsCounter3());

            //foreach (var key in _memory.Keys)
            //{
            //    PrintLine(key.ToString() + " --> " + _memory[key]);

            //}
        }

        private Dictionary<int, int> _memory = new Dictionary<int, int>();
        public int StepsCounter(int currentStep)
        {
            PrintLine("Start - " + currentStep);

            if (_memory.ContainsKey(currentStep))
            {
                PrintLine("asdasdasdasd - " + currentStep);
                return _memory[currentStep];
            }
            int result;

            if (currentStep > _endStep)
            {
                result = 0;
            }
            else if (currentStep == _endStep)
            {
                result = 1;
            }
            else
            {
                result = StepsCounter(currentStep + 1) + StepsCounter(currentStep + 2);
            }
            _memory[currentStep] = result;

            return result;
        }

        public int StepsCounter1(int currentStep)
        {

            if (_memory.ContainsKey(currentStep))
            {
                //PrintLine("asdasdasdasd - " + currentStep);
                return _memory[currentStep];
            }
            int result;

            if (currentStep < 0)
            {
                result = 0;
            }
            else if (currentStep == 0)
            {
                result = 1;
            }
            else
            {
                result = StepsCounter1(currentStep - 1) + StepsCounter1(currentStep - 2);
            }
            _memory[currentStep] = result;

            PrintLine("Step - " + currentStep + " Result - " + result);

            return result;
        }

        public long StepsCounter2()
        {
            long[] tt = new long[_endStep];

            tt[0] = 1;
            tt[1] = 2;
            for (int i = 2; i < _endStep; i++)
            {
                tt[i] = tt[i - 1] + tt[i - 2];
            }

            return tt[_endStep - 1];
        }

        public long StepsCounter3()
        {
            long prevStep1 = 1;
            long prevStep2 = 2;

           // long currentStep = 0;
            for (int i = 2; i < _endStep; i++)
            {
                long temp = prevStep1 + prevStep2;
                prevStep1 = prevStep2;
                prevStep2 = temp;
            }

            return prevStep2;
        }

        public int findQuadreplets(int[] arr)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int possibleXIndex = -1;
            int possibleYIndex = -1;
            int possibleZIndex = -1;
            int possibleWIndex = -1;

            for (int i = 3; i < arr.Length; i++)
            {
                possibleWIndex = i;
                possibleXIndex = getPossibleIndex(arr[possibleWIndex], possibleXIndex, possibleWIndex - 2, arr);

                if (possibleXIndex >= 0)
                {
                    possibleYIndex = getPossibleIndex(arr[possibleWIndex] - arr[possibleXIndex], possibleXIndex, possibleWIndex - 1, arr);

                    if (possibleYIndex > 0)
                    {
                        possibleZIndex = getPossibleIndex(arr[possibleWIndex] - arr[possibleXIndex] - arr[possibleYIndex], possibleYIndex, possibleWIndex, arr);

                        if (possibleZIndex > 0)
                        {
                            stringBuilder.Append($"{arr[possibleXIndex]} + {arr[possibleYIndex]} + {arr[possibleZIndex]} = {arr[possibleWIndex]}");
                        }
                    }
                }
            }
            return 0;
        }

        private int getPossibleIndex(int value, int startIndex, int endIndex, int[] arr)
        {
            for (int i = startIndex + 1; i < endIndex; i++)
            {
                if (arr[i] < value) return i;
            }
            return -1;
        }
        //private int getPossibleY()
    }
}
