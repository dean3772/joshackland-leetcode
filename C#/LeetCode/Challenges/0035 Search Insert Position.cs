/*
35. Search Insert Position
Easy
Topics
premium lock icon
Companies
Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:

Input: nums = [1,3,5,6], target = 5
Output: 2
Example 2:

Input: nums = [1,3,5,6], target = 2
Output: 1
Example 3:

Input: nums = [1,3,5,6], target = 7
Output: 4
 

Constraints:

1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums contains distinct values sorted in ascending order.
-104 <= target <= 104
Seen this question in a real interview before?
1/5
Yes
No
Accepted
4,037,873/8.2M
Acceptance Rate
49.5%
Topics
Array
Binary Search
template
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        
    }
}
 */
namespace LeetCode.Challenges._0035SearchInsertPosition;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int lower = 0;
        int upper = nums.Length - 1;

        if (nums[lower] >= target) return lower;
        if (nums[upper] < target) return nums.Length;
        if (nums[upper] == target) return upper;

        while (lower < upper)
        {
            if (lower == upper-1) return upper;

            int current = upper - ((upper - lower) / 2);

            if (nums[current] == target) return current;
            if (nums[current] < target) lower = current;
            if (nums[current] > target) upper = current;
        }

        return upper;
    }
}

public static class _0035SearchInsertPosition
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int [] { 1,3,5,6 },
        new int [] { 1,3,5,6 },
        new int [] { 1,3,5,6 },
    };
    private static List<int> Targets = new List<int>()
    {
        5,
        2,
        7
    };
    private static List<int> ExpectedOutputs= new List<int>()
    {
        2,
        1,
        4
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.SearchInsert(input, target);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}