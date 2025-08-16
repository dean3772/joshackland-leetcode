/*
11. Container With Most Water
Medium
Topics
premium lock icon
Companies
Hint
You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

Example 1:

Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
Example 2:

Input: height = [1,1]
Output: 1
 

Constraints:

n == height.length
2 <= n <= 105
0 <= height[i] <= 104
Seen this question in a real interview before?
1/5
Yes
No
Accepted
4,346,740/7.5M
Acceptance Rate
58.1%
Topics
Array
Two Pointers
Greedy
icon
Companies
Hint 1
If you simulate the problem, it will be O(n^2) which is not efficient.
Hint 2
Try to use two-pointers. Set one pointer to the left and one to the right of the array. Always move the pointer that points to the lower line.
Hint 3
How can you calculate the amount of water at each step?
template
public class Solution {
    public int MaxArea(int[] height) {
        
    }
}
 */
namespace LeetCode.Challenges._0011ContainerWithMostWater;

public class Solution
{
    public int MaxArea(int[] height)
    {
        int area = 0;
        for (int i = 0; i < height.Length -1; i++) 
        {
            if (height[i] * height.Length - i < area) continue;

            for (int j = i+1; j < height.Length; j++)
            {
                int smallest = height[i] < height[j] ? height[i] : height[j];
                int distance = j - i;
                int currentArea = smallest * distance;

                if (currentArea > area) 
                { 
                    area = currentArea;
                }
            }    
        }
        return area;
    }
}

public static class _0011ContainerWithMostWater
{
    private static List<int[]> Inputs = new List<int[]>() { new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 } } ;
    private static List<int> ExpectedOutputs = new List<int>() { 49 };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.MaxArea(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}