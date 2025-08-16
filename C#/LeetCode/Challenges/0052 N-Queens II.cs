/*
52. N-Queens II
Hard
Topics
premium lock icon
Companies
The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.

Given an integer n, return the number of distinct solutions to the n-queens puzzle.

 

Example 1:


Input: n = 4
Output: 2
Explanation: There are two distinct solutions to the 4-queens puzzle as shown.
Example 2:

Input: n = 1
Output: 1
 

Constraints:

1 <= n <= 9
Seen this question in a real interview before?
1/5
Yes
No
Accepted
516,765/670K
Acceptance Rate
77.1%
Topics
Backtracking
 */
namespace LeetCode.Challenges._0052NQueensII;

public class Solution
{
    public int TotalNQueens(int n)
    {
        if (n == 1) 
        {
            return 1;
        }

        char[][] board = new char[n][];

        for (int i = 0; i < n; i++)
        {
            board[i] = new char[n];
            for(int j = 0; j < n; j++)
            {
                board[i][j] = '.';
            }
        }

        return SolveBoard(board, 0, 0);
    }

    private int SolveBoard(char[][]board, int row, int count)
    {
        if (row == board.Length)
        {
            var solved = new List<string>();

            foreach (var bRow in board)
            {
                solved.Add(string.Join("", bRow));
            }

            return count + 1;
        }

        for (int col = 0; col < board.Length; col++)
        {
            if (IsSafe(board, row, col))
            {
                board[row][col] = 'Q';
                count = SolveBoard(board, row + 1, count);
                board[row][col] = '.';
            }
        }

        return count;
    }

    private bool IsSafe(char[][] board, int row, int col) 
    {
        for (int i = 0; i < row; i++)
        {
            if (board[i][col] == 'Q') return false;

            int leftDiagonal = col - (row - i);
            int righttDiagonal = col + (row - i);

            if (leftDiagonal >= 0 && board[i][leftDiagonal] == 'Q') return false;
            if (righttDiagonal < board.Length && board[i][righttDiagonal] == 'Q') return false;
        }

        return true;
    }
}

public static class _0052NQueensII
{
    private static List<int> Inputs = new List<int>() 
    { 
        4,
        1
    };
    private static List<int> ExpectedOutputs = new List<int>()
    {
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
            var actualOutput = solution.TotalNQueens(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}