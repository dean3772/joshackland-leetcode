/*
51. N-Queens
Hard
Topics
premium lock icon
Companies
The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.

Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.

Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space, respectively.

 

Example 1:


Input: n = 4
Output: [[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
Explanation: There exist two distinct solutions to the 4-queens puzzle as shown above
Example 2:

Input: n = 1
Output: [["Q"]]
 

Constraints:

1 <= n <= 9
Seen this question in a real interview before?
1/5
Yes
No
Accepted
1,056,643/1.4M
Acceptance Rate
73.5%
Topics
Array
Backtracking
template
public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        
    }
}
 */
namespace LeetCode.Challenges._0051NQueens;

public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var output = new List<IList<string>>();
        if (n == 1) 
        {
            output.Add(new List<string>() { "Q" });
            return output;
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

        SolveBoard(board, output, 0);

        return output;
    }

    private void SolveBoard(char[][]board, List<IList<string>> output, int row)
    {
        if (row == board.Length)
        {
            var solved = new List<string>();

            foreach (var bRow in board)
            {
                solved.Add(string.Join("", bRow));
            }
            output.Add(solved);
            return;
        }

        for (int col = 0; col < board.Length; col++)
        {
            if (IsSafe(board, row, col))
            {
                board[row][col] = 'Q';
                SolveBoard(board, output, row + 1);
                board[row][col] = '.';
            }
        }
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

public static class _0051NQueens
{
    private static List<int> Inputs = new List<int>() 
    { 
        4,
        1
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var actualOutput = solution.SolveNQueens(input);
            Console.WriteLine($"Input: {input}, Output: {DisplayOutput(actualOutput)}");
        }
    }

    private static string DisplayOutput(IList<IList<string>> input)
    {
        string output = "\n";

        foreach (var item in input)
        {
            output += string.Join(',',item) + "\n";
        }

        return output;
    }
}