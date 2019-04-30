using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Problems.LeetCode
{
    public class FindInRange : _ProblemBase
    {
        public RangeNode RangeRoot { get; set; }

        public override void MainRun()
        {
            RangeRoot = new RangeNode();

            RangeRoot.AddRange(40, 50, false);
            RangeRoot.AddRange(20, 30, false);
            RangeRoot.AddRange(10, 18, false);
            RangeRoot.AddRange(35, 36, false);
            RangeRoot.AddRange(25, 45, false);


        }






    }

    public class Range
    {
        public int Start { get; set; }
        public int End { get; set; }

        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }

        public bool IsOnFullRight(Range range)
        {
            return this.End < range.Start;
        }

        public bool IsOnFullLeft(Range range)
        {
            return this.Start > range.End;
        }

        public bool IsOnRight(Range range)
        {
            return this.Start > range.Start;
        }
        public bool IsOnLeft(Range range)
        {
            return this.End < range.End;
        }


        public bool IsOverlapping(Range range)
        {
            return !IsOnFullLeft(range) && !IsOnFullRight(range);
        }
        public bool ContainsRange(Range range)
        {
            return this.Start <= range.Start && this.End >= range.End;
        }
    }

    public class RangeNode
    {
        //bool Overlapping { get; s }
        public Range Value { get; set; }
        public RangeNode LeftRange { get; set; }
        public RangeNode RightRange { get; set; }

        private bool MergeWith(Range range)
        {
            if (!Value.IsOnFullLeft(range) && !Value.IsOnFullRight(range))
            {
                Value.Start = Math.Min(Value.Start, range.Start);
                Value.End = Math.Max(Value.End, range.End);

                return true;
            }

            return false;
        }

        public void AddRange(int start, int end, bool overlappingFound)
        {
            if (Value == null)
            {
                Value = new Range(start, end);
                return;
            }

            var range = new Range(start, end);

            //if (Value.ContainsRange(range)) return;

            if (LeftRange != null && range.IsOnLeft(Value))
            {
                LeftRange.AddRange(start, end, overlappingFound || Value.IsOverlapping(range));

                if (MergeWith(LeftRange.Value))
                {
                    if (LeftRange.LeftRange == null && LeftRange.RightRange == null)
                    {
                        LeftRange = null;
                    }
                    else if (LeftRange.RightRange == null)
                    {
                        LeftRange = LeftRange.LeftRange;
                    }
                    else if (LeftRange.LeftRange == null)
                    {
                        LeftRange = LeftRange.RightRange;
                    }
                }
            }

            if (RightRange != null && range.IsOnRight(Value))
            {
                RightRange.AddRange(start, end, overlappingFound || Value.IsOverlapping(range));

                if (MergeWith(RightRange.Value))
                {
                    if (RightRange.LeftRange == null && RightRange.RightRange == null)
                    {
                        RightRange = null;
                    }
                    else if (RightRange.RightRange == null)
                    {
                        RightRange = RightRange.LeftRange;
                    }
                    else if (RightRange.LeftRange == null)
                    {
                        RightRange = RightRange.RightRange;
                    }
                }
            }

            MergeWith(range);

            if (!overlappingFound)
            {
                if (Value.IsOnFullRight(range))
                {
                    if (RightRange == null)
                    {
                        RightRange = new RangeNode();
                    }
                    RightRange.AddRange(range.Start, range.End, false);
                }
                else if (Value.IsOnFullLeft(range))
                {
                    if (LeftRange == null)
                    {
                        LeftRange = new RangeNode();
                    }
                    LeftRange.AddRange(range.Start, range.End, false);
                }
            }
        }
    }
}
