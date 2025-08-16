/*
62. Unique Paths
Medium
Topics
premium lock icon
Companies
There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.

Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

The test cases are generated so that the answer will be less than or equal to 2 * 109.

 

Example 1:


Input: m = 3, n = 7
Output: 28
Example 2:

Input: m = 3, n = 2
Output: 3
Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
1. Right -> Down -> Down
2. Down -> Down -> Right
3. Down -> Right -> Down
 

Constraints:

1 <= m, n <= 100
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,463,576/3.7M
Acceptance Rate
66.0%
Topics
Math
Dynamic Programming
Combinatorics
template
public class Solution {
    public int UniquePaths(int m, int n) {
        
    }
}
 */
namespace LeetCode.Challenges._0062UniquePaths;

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        int[,] grid = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            grid[i, 0] = 1;
        }

        for (int i = 0; i < n; i++)
        {
            grid[0, i] = 1;
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                grid[i, j] = grid[i, j - 1] + grid[i-1, j];
            }
        }

        return grid[m-1,n-1];
    }
}

public static class _0062UniquePaths
{
    private static List<int> Ms = new List<int>() 
    { 
        3,
        3
    };
    private static List<int> Ns = new List<int>()
    {
        7,
        2
    };
    private static List<int> ExpectedOutputs= new List<int>() 
    { 
        28,
        3
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Ms.Count; i++)
        {
            var m = Ms[i];
            var n = Ns[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.UniquePaths(m, n);
            Console.WriteLine($"M: {m}, N: {n}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}