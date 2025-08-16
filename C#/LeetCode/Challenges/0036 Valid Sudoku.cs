namespace LeetCode.Challenges._0036ValidSudoku;

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        var rowValues = new HashSet<char>[9];
        var colValues = new HashSet<char>[9];
        var boxValues = new HashSet<char>[9];

        for (int i = 0; i < 9; i++)
        {
            rowValues[i] = new HashSet<char>();
            colValues[i] = new HashSet<char>();
            boxValues[i] = new HashSet<char>();
        }

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                char cell = board[row][col];

                if (cell == '.') continue;

                int boxIndex = ((row / 3) * 3) + (col / 3);

                if (rowValues[row].Contains(cell)
                    || colValues[col].Contains(cell)
                    || boxValues[boxIndex].Contains(cell)
                   )
                {
                    return false;
                }

                rowValues[row].Add(cell);
                colValues[col].Add(cell);
                boxValues[boxIndex].Add(cell);
            }
        }

        return true;
    }
}

/*
36. Valid Sudoku
Medium
Topics
premium lock icon
Companies
Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

Each row must contain the digits 1-9 without repetition.
Each column must contain the digits 1-9 without repetition.
Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
Note:

A Sudoku board (partially filled) could be valid but is not necessarily solvable.
Only the filled cells need to be validated according to the mentioned rules.
 

Example 1:


Input: board = 
[["5","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: true
Example 2:

Input: board = 
[["8","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: false
Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.
 

Constraints:

board.length == 9
board[i].length == 9
board[i][j] is a digit 1-9 or '.'.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,090,130/3.3M
Acceptance Rate
62.6%
Topics
Array
Hash Table
Matrix
template
public class Solution {
    public bool IsValidSudoku(char[][] board) {
        
    }
}
 */
public static class _0036ValidSudoku
{
    private static List<char[][]> Boards = new List<char[][]>() 
    { 
        new char[][]
        {
            new char[]{'5','3','.','.','7','.','.','.','.' },
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'}
        },

        new char[][]
        {
            new char[]{'8','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'}
        }
    };
    private static List<bool> ExpectedOutputs = new List<bool>() 
    { 
        true,
        false
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Boards.Count; i++)
        {
            var board = Boards[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.IsValidSudoku(board);
            Console.WriteLine($"Board: {board}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}