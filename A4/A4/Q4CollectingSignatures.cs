using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Segments
    {
        public Segments(long start, long end)
        {
            this.Start = start;
            this.End = end;
        }
        public long Start { get; set; }
        public long End { get; set; }
    }
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);

        private static List<long> PointsCoveredSorted(Segments[] segments)
        {
            var answer = new List<long>();
            var SortedSegmentsList = segments.OrderBy(s => s.End).ToList();
            long p = SortedSegmentsList.FirstOrDefault().End;
            for (int i = 0; i < SortedSegmentsList.Count; i++)
            {
                if ( !(p <= SortedSegmentsList[i].End && p >= SortedSegmentsList[i].Start) )
                {
                    p = SortedSegmentsList.FirstOrDefault().End;
                }
                else
                {
                    SortedSegmentsList.Remove(SortedSegmentsList[i]);
                    answer.Add(p);
                }
                i--;
            }
            return answer.Distinct().ToList();
        }
        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            List<Segments> s = new List<Segments>();
            for (long i = 0; i < tenantCount; i++)
            {
                var segment  = new Segments(startTimes[i], endTimes[i]);
                s.Add(segment);
            }
            var ansList = PointsCoveredSorted(s.ToArray());
            return ansList.Count;
        }
    }
}
