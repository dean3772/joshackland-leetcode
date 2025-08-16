/*
6. Zigzag Conversion
Medium

The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 
Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
 

Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000
Seen this question in a real interview before?
1/5
Yes
No
Accepted
1,861,118/3.6M
Acceptance Rate
52.1%
Topics
String 
template they give
public class Solution {
    public string Convert(string s, int numRows) {
        
    }
}
 */
namespace LeetCode.Challenges._0006ZigzacConversions;

public class Solution {
    public string Convert(string s, int numRows) {
        string[] rows = new string[numRows];

        int row = 0;
        bool directionDown = true;

        foreach (char c in s){
            rows[row] += c.ToString();

            if (numRows > 1){
                directionDown = row == 0 ? true : row == numRows - 1 ? false : directionDown;

                row = directionDown ? row + 1 : row - 1;
            }
        }

        string output = "";

        foreach (string sRow in rows){
            output += sRow;
        }

        return output;
    }
}