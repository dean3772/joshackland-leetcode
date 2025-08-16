/*
34. Find First and Last Position of Element in Sorted Array
Medium
Topics
premium lock icon
Companies
Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.

If target is not found in the array, return [-1, -1].

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:

Input: nums = [5,7,7,8,8,10], target = 8
Output: [3,4]
Example 2:

Input: nums = [5,7,7,8,8,10], target = 6
Output: [-1,-1]
Example 3:

Input: nums = [], target = 0
Output: [-1,-1]
 

Constraints:

0 <= nums.length <= 105
-109 <= nums[i] <= 109
nums is a non-decreasing array.
-109 <= target <= 109
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,830,064/6M
Acceptance Rate
47.2%
Topics
Array
Binary Search
template
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        
    }
}
 */
namespace LeetCode.Challenges._0034FindFirstAndLastPositionOfElementInSortedArray;

public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        int[] indexes = new int[] { -1, -1 };

        if (nums.Length == 0) return indexes;

        int lower = 0;
        int upper = nums.Length - 1;
        int current = upper - ((upper - lower) / 2);

        if (nums[lower] != target && nums[upper] != target) 
        {
            while (current != lower && current != upper)
            {
                if (nums[current] == target)
                {
                    indexes[0] = current;
                    indexes[1] = current;
                    break;
                }

                if (nums[current] < target)
                {
                    lower = current;
                }
                else
                {
                    upper = current;
                }

                current = upper - ((upper - lower) / 2);
            }
        }
        else
        {
            if (nums[lower] == target)
            {
                indexes[0] = lower;
                indexes[1] = lower;
            }
            else
            {
                indexes[0] = upper;
                indexes[1] = upper;
            }
        }

        

        if (indexes[0] == -1) return indexes;

        for (int i = indexes[0]; i >= 0; i--)
        {
            if (nums[i] == target)
            {
                indexes[0] = i;
            }
            else
            {
                break;
            }
        }

        for (int i = indexes[1]; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                indexes[1] = i;
            }
            else
            {
                break;
            }
        }

        return indexes;
    }
}

public static class _0034FindFirstAndLastPositionOfElementInSortedArray
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int [] { 0,1,2,3,4,4,4 },
        new int [] { 5, 7, 7, 8, 8, 10 },
        new int [] { 5, 7, 7, 8, 8, 10 },
        new int [] {  },
    };
    private static List<int> Targets = new List<int>()
    {
        2,
        8,
        6,
        0
    };
    private static List<int[]> ExpectedOutputs= new List<int[]>()
    {
        new int [] { 2,2 },
        new int [] { 3,4 },
        new int [] { -1,-1 },
        new int [] { -1,-1 },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.SearchRange(input, target);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {string.Join(',', expectedOutput)}, Actual Output: {string.Join(',', actualOutput)}");
        }
    }
}