/*
48. Rotate Image
Medium
Topics
premium lock icon
Companies
You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).

You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

 

Example 1:


Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[7,4,1],[8,5,2],[9,6,3]]
Example 2:


Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]
 

Constraints:

n == matrix.length == matrix[i].length
1 <= n <= 20
-1000 <= matrix[i][j] <= 1000
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,426,108/3.1M
Acceptance Rate
78.3%
Topics
Array
Math
Matrix
template
public class Solution {
    public void Rotate(int[][] matrix) {
        
    }
}
 */
using System.Runtime.CompilerServices;

namespace LeetCode.Challenges._0048RotateImage;

public class Solution
{
    public int[][] Rotate(int[][] matrix)
    {
        int length = matrix.Length;

        for (int i = 0; i < length / 2; i++)
        {
            for (int j = i; j < length - 1 - i; j++) 
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[length - 1 - j][i];
                matrix[length - 1 - j][i] = matrix[length - 1 - i][length - 1 - j];
                matrix[length - 1 - i][length - 1 - j] = matrix[j][length - 1 - i];
                matrix[j][length - 1 - i] = temp;
            }
        }

        return matrix;
    }
}

public static class _0048RotateImage
{
    private static List<int[][]> Inputs = new List<int[][]>() 
    { 
        new int[][]
        {
            new int [] { 1, 2, 3 },
            new int [] { 4, 5, 6 },
            new int [] { 7, 8, 9 },
        },
        new int[][]
        {
            new int [] { 5, 1, 9, 11 },
            new int [] { 2, 4, 8, 10 },
            new int [] { 13, 3, 6, 7 },
            new int [] { 15, 14, 12, 16 },
        },
    };
    private static List<int[][]> ExpectedOutputs= new List<int[][]>()
    {
        new int[][]
        {
            new int [] { 7, 4, 1 },
            new int [] { 8, 5, 2 },
            new int [] { 9, 6, 3 },
        },
        new int[][]
        {
            new int [] { 15, 13, 2, 5 },
            new int [] { 14, 3, 4, 1 },
            new int [] { 12, 6, 8, 9 },
            new int [] { 16, 7, 10, 11 },
        },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Rotate(input);
            Console.WriteLine($"Input: {PrintMatrix(input)}, Expected Output: {PrintMatrix(expectedOutput)}, Actual Output: {PrintMatrix(actualOutput)}");
        }
    }

    private static string PrintMatrix(int[][] matrix)
    {
        string output = "\n";

        foreach ( var row in matrix)
        {
            output += string.Join(',', row) + "\n";
        }

        return output;
    }
}