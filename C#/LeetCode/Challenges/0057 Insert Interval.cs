/*
57. Insert Interval
Medium
Topics
premium lock icon
Companies
Hint
You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.

Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).

Return intervals after the insertion.

Note that you don't need to modify intervals in-place. You can make a new array and return it.

 

Example 1:

Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
Output: [[1,5],[6,9]]
Example 2:

Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
Output: [[1,2],[3,10],[12,16]]
Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
 

Constraints:

0 <= intervals.length <= 104
intervals[i].length == 2
0 <= starti <= endi <= 105
intervals is sorted by starti in ascending order.
newInterval.length == 2
0 <= start <= end <= 105
Seen this question in a real interview before?
1/5
Yes
No
Accepted
1,527,134/3.5M
Acceptance Rate
43.8%
Topics
Array
icon
Companies
Hint 1
Intervals Array is sorted. Can you use Binary Search to find the correct position to insert the new Interval.?
Hint 2
Can you try merging the overlapping intervals while inserting the new interval?
Hint 3
This can be done by comparing the end of the last interval with the start of the new interval and vice versa.
template
public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        
    }
}
 */
namespace LeetCode.Challenges._0057InsertInterval;

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0) return new int[][] { newInterval };

        var output = new List<int[]>();

        int low = int.MaxValue;
        int high = int.MinValue;
        bool added = false;

        for (int i = 0; i < intervals.Length; i++)
        {
            if (intervals[i][1] < newInterval[0])
            {
                output.Add(intervals[i]);

                if (i + 1 == intervals.Length && !added) output.Add(newInterval);
                continue;
            }
            else if (intervals[i][0] > newInterval[1])
            {
                if (!added)
                {
                    if (low < int.MaxValue)
                    {
                        output.Add(new int[] {low, high});
                    }
                    else
                    {
                        output.Add(newInterval);
                    }
                    added = true;
                }

                output.Add(intervals[i]);
                continue;
            }

            if (low == int.MaxValue) low = Math.Min(newInterval[0], intervals[i][0]);

            high = Math.Max(newInterval[1], intervals[i][1]);

            if (i + 1 == intervals.Length) output.Add(new int[] { low, high });
        }

        return output.ToArray();
    }
}

public static class _0057InsertInterval
{
    private static List<int[][]> Inputs = new List<int[][]>()
    {
        new int[][]
        {
            new int[] { 1, 3 },
            new int[] { 6, 9 },
        },
        new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 3, 5 },
            new int[] { 6, 7 },
            new int[] { 8, 10 },
            new int[] { 12, 16 },
        },
    };
    private static List<int[]> Intervals = new List<int[]>
    {
        new int[]{ 2, 5 },
        new int[]{ 4, 8 },
    };
    private static List<int[][]> ExpectedOutputs = new List<int[][]>()
    {
        new int[][]
        {
            new int[] { 1, 5 },
            new int[] { 6, 9 },
        },
        new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 3, 10 },
            new int[] { 12, 16 },
        },
    };
    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var interval = Intervals[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Insert(input, interval);
            Console.WriteLine($"Input: {DisplayOuput(input)}, Expected Output: {DisplayOuput(expectedOutput)}, Actual Output: {DisplayOuput(actualOutput)}");
        }
    }

    private static string DisplayOuput(int[][] output)
    {
        string sOutput = "\n[";

        foreach (var i in output)
        {
            sOutput += $"[{string.Join(',', i)}]";
        }

        sOutput += "]";
        return sOutput;
    }
}