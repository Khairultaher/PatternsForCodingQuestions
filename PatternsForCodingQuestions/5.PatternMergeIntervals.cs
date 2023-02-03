using System;

namespace PatternsForCodingQuestions;

public class Interval
{
    public int start = 0;
    public int end = 0;
    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}
public class PatternMergeIntervals
{
    [Fact]
    public void MergeInterval()
    {
        // arrange
        List<Interval> input = new List<Interval>();
        input.Add(new Interval(1, 4));
        input.Add(new Interval(2, 5));
        input.Add(new Interval(7, 9));

        List<Interval> expected = new List<Interval>
        {
            new Interval(1,5),
            new Interval(7,9)
        };
       
        // act
        List<Interval> actual = Merge(input);

        // assert
        Assert.True(expected.SequenceEqual(actual, new IntervalComparer()));
    }

    public List<Interval> Merge(List<Interval> intervals)
    {
        if (intervals.Count < 2)
            return intervals;

        List<Interval> mergedIntervals = new List<Interval>();
        //intervals.Sort((s1, s2) => s1.start.CompareTo(s2.start));
        intervals = intervals.OrderBy(interval => interval.start).ToList();
        IEnumerator<Interval> intervalItr = intervals.GetEnumerator();
        intervalItr.MoveNext();
        int start = intervalItr.Current.start;
        int end = intervalItr.Current.end;

        bool hasNext = intervalItr.MoveNext();
        while (hasNext)
        {
            if (intervalItr.Current.start <= end)
            {
                end = Math.Max(end, intervalItr.Current.end);
            }
            else
            {
                mergedIntervals.Add(new Interval(start, end));
                start = intervalItr.Current.start;
                end = intervalItr.Current.end;
            }
            hasNext = intervalItr.MoveNext();
        }
        mergedIntervals.Add(new Interval(start, end));
        return mergedIntervals;
    }

    public class IntervalComparer : IEqualityComparer<Interval>
    {
        public bool Equals(Interval x, Interval y)
        {
            return x.start == y.start && x.end == y.end;
        }

        public int GetHashCode(Interval obj)
        {
            return obj.GetHashCode();
        }
    }
}