/*
45. Jump Game II
Medium
Topics
premium lock icon
Companies
You are given a 0-indexed array of integers nums of length n. You are initially positioned at index 0.

Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at index i, you can jump to any index (i + j) where:

0 <= j <= nums[i] and
i + j < n
Return the minimum number of jumps to reach index n - 1. The test cases are generated such that you can reach index n - 1.

 

Example 1:

Input: nums = [2,3,1,1,4]
Output: 2
Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
Example 2:

Input: nums = [2,3,0,1,4]
Output: 2
 

Constraints:

1 <= nums.length <= 104
0 <= nums[i] <= 1000
It's guaranteed that you can reach nums[n - 1].
Seen this question in a real interview before?
1/5
Yes
No
Accepted
1,828,819/4.4M
Acceptance Rate
41.8%
Topics
Array
Dynamic Programming
Greedy
template
public class Solution {
    public int Jump(int[] nums) {
        
    }
}
 */
namespace LeetCode.Challenges._0045JumpGameII;

public class Solution
{
    public int Jump(int[] nums)
    {
        if (nums.Length <= 1 || nums[0] == 0) return 0;

        int steps = 1;
        int currentIndex = 0;
        int lastIndex = nums.Length - 1;

        while (currentIndex < lastIndex)
        {
            int currentNum = nums[currentIndex];

            if (currentIndex + currentNum >= lastIndex) return steps;

            int nextIndex = -1;
            int nextMaxJump = 0;

            for (int i = 1; i <= currentNum; i++)
            {
                if (i + nums[currentIndex + i] > nextMaxJump)
                {
                    nextIndex = i + currentIndex;
                    nextMaxJump = i + nums[currentIndex + i];
                }
            }

            if (nextIndex == -1) return 0;

            steps++;
            currentIndex = nextIndex;
        }

        return steps;
    }
}

public static class _0045JumpGameII
{
    private static List<int[]> Inputs = new List<int[]>() 
    { 
        new int[] { 2, 3, 1, 1, 4},
        new int[] { 2, 3, 0, 1, 4}
    };
    private static List<int> ExpectedOutputs= new List<int>() 
    { 
        2,
        2
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Jump(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}