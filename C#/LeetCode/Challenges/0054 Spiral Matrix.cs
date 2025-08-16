/*
54. Spiral Matrix
Medium
Topics
premium lock icon
Companies
Hint
Given an m x n matrix, return all elements of the matrix in spiral order.

 

Example 1:


Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]
Example 2:


Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]
 

Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 10
-100 <= matrix[i][j] <= 100
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,038,526/3.7M
Acceptance Rate
54.6%
Topics
Array
Matrix
Simulation
icon
Companies
Hint 1
Well for some problems, the best way really is to come up with some algorithms for simulation. Basically, you need to simulate what the problem asks us to do.
Hint 2
We go boundary by boundary and move inwards. That is the essential operation. First row, last column, last row, first column, and then we move inwards by 1 and repeat. That's all. That is all the simulation that we need.
Hint 3
Think about when you want to switch the progress on one of the indexes. If you progress on i out of [i, j], you'll shift in the same column. Similarly, by changing values for j, you'd be shifting in the same row. Also, keep track of the end of a boundary so that you can move inwards and then keep repeating. It's always best to simulate edge cases like a single column or a single row to see if anything breaks or not.
template
public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        
    }
}
 */
namespace LeetCode.Challenges._0054SpiralMatrix;

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var output = new List<int>();

        int top = 0;
        int right = matrix[0].Length - 1;
        int bottom = matrix.Length - 1;
        int left = 0;

        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++) 
            {
                output.Add(matrix[top][i]);
            }
            top++;

            for (int i = top; i <= bottom; i++)
            {
                output.Add(matrix[i][right]);
            }
            right--;

            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    output.Add(matrix[bottom][i]);
                }
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    output.Add(matrix[i][left]);
                }
                left++;
            }
        }

        return output;
    }
}

public static class _0054SpiralMatrix
{
    private static List<int[][]> Inputs = new List<int[][]>() 
    { 
        new int[][]
        {
            new int[] {1, 2, 3 },
            new int[] {4, 5, 6 },
            new int[] {7, 8, 9 },
        },
        new int[][]
        {
            new int[] {1, 2, 3, 4 },
            new int[] {5, 6, 7, 8 },
            new int[] {9, 10, 11, 12 },
        }
    };
    private static List<List<int>> ExpectedOutputs= new List<List<int>>() 
    { 
        new List<int>{1, 2, 3, 6, 9, 8, 7, 4, 5},
        new List<int>{1, 2, 3, 4, 8, 12,11, 10, 9, 5, 6,7},
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.SpiralOrder(input);
            Console.WriteLine($"Expected Output: {string.Join(',', expectedOutput)}, Actual Output: {string.Join(',', actualOutput)}");
        }
    }
}