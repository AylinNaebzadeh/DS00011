using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Segments
{
    public Segments(int start, int end)
    {
        this.Start = start;
        this.End = end;
    }
    public int Start { get; set; }
    public int End { get; set; }
}

class A4_5
{
        static List<int> PointsCoveredSorted(Segments[] segments)
        {
            var answer = new List<int>();
            var SortedSegmentsList = segments.OrderBy(s => s.End).ToList();
            int p = SortedSegmentsList.FirstOrDefault().End;
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
}