/*
41. First Missing Positive
Hard
Topics
premium lock icon
Companies
Hint
Given an unsorted integer array nums. Return the smallest positive integer that is not present in nums.

You must implement an algorithm that runs in O(n) time and uses O(1) auxiliary space.

 

Example 1:

Input: nums = [1,2,0]
Output: 3
Explanation: The numbers in the range [1,2] are all in the array.
Example 2:

Input: nums = [3,4,-1,1]
Output: 2
Explanation: 1 is in the array but 2 is missing.
Example 3:

Input: nums = [7,8,9,11,12]
Output: 1
Explanation: The smallest positive integer 1 is missing.
 

Constraints:

1 <= nums.length <= 105
-231 <= nums[i] <= 231 - 1
Seen this question in a real interview before?
1/5
Yes
No
Accepted
1,531,734/3.7M
Acceptance Rate
41.4%
Topics
Array
Hash Table
icon
Companies
Hint 1
Think about how you would solve the problem in non-constant space. Can you apply that logic to the existing space?
Hint 2
We don't care about duplicates or non-positive integers
Hint 3
Remember that O(2n) = O(n)
template
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        
    }
}
 */
namespace LeetCode.Challenges._0041FirstMissingPositive;

public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        const int exist = 0;
        const int notexist = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 1 || nums[i] > nums.Length) nums[i] = notexist;
        }

        for (int i = 0;i < nums.Length; i++)
        {
            if (nums[i] == notexist || nums[i] == exist) continue;

            int index = nums[i] - 1;
            nums[i] = notexist;

            while (index >= exist)
            {
                var temp = nums[index] - 1;
                nums[index] = exist;
                index = temp;
            }
        }

        for (int i= 0; i < nums.Length; i++)
        {
            if (nums[i] != exist) return i+1;
        }

        return nums.Length + 1;
    }
}

public static class _0041FirstMissingPositive
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { 1, 2, 0 },
        new int[] { 3, 4, -1, 1 },
        new int[] { 7, 8, 9, 11, 12 }
    };
    private static List<int> ExpectedOutputs = new List<int>()
    {
        3,
        2,
        1
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.FirstMissingPositive(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}