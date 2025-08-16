/*
13. Roman to Integer
Easy
Topics
premium lock icon
Companies
Hint
Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000
For example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

I can be placed before V (5) and X (10) to make 4 and 9. 
X can be placed before L (50) and C (100) to make 40 and 90. 
C can be placed before D (500) and M (1000) to make 400 and 900.
Given a roman numeral, convert it to an integer.

 

Example 1:

Input: s = "III"
Output: 3
Explanation: III = 3.
Example 2:

Input: s = "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.
Example 3:

Input: s = "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
 

Constraints:

1 <= s.length <= 15
s contains only the characters ('I', 'V', 'X', 'L', 'C', 'D', 'M').
It is guaranteed that s is a valid roman numeral in the range [1, 3999].
Seen this question in a real interview before?
1/5
Yes
No
Accepted
5,078,438/7.8M
Acceptance Rate
65.3%
Topics
Hash Table
Math
String
icon
Companies
Hint 1
Problem is simpler to solve by working the string from back to front and using a map.
template
public class Solution {
    public int RomanToInt(string s) {
        
    }
}
 */
namespace LeetCode.Challenges._0013RomanToInteger;

public class Solution
{
    public int RomanToInt(string s)
    {
        int number = 0;

        for (int i = 0; i < s.Length; i++)
        {
            string currentCharacter = s[i].ToString();

            if (currentCharacter == "M")
            {
                number += 1000;
            }
            else if (currentCharacter == "D") 
            {
                number += 500;
            }
            else if (currentCharacter == "C")
            {
                string nextCharacter = NextCharacter(i, s);

                if (nextCharacter == "M")
                {
                    number += 900;
                    i++;
                }
                else if (nextCharacter == "D")
                {
                    number += 400;
                    i++;
                }
                else
                {
                    number += 100;
                }

            }
            else if (currentCharacter == "L")
            {
                number += 50;
            }
            else if (currentCharacter == "X")
            {
                string nextCharacter = NextCharacter(i, s);

                if (nextCharacter == "C")
                {
                    number += 90;
                    i++;
                }
                else if (nextCharacter == "L")
                {
                    number += 40;
                    i++;
                }
                else
                {
                    number += 10;
                }
            }
            else if (currentCharacter == "V")
            {
                number += 5;
            }
            else if (currentCharacter == "I")
            {
                string nextCharacter = NextCharacter(i, s);

                if (nextCharacter == "X")
                {
                    number += 9;
                    i++;
                }
                else if (nextCharacter == "V")
                {
                    number += 4;
                    i++;
                }
                else
                {
                    number += 1;
                }
            }
        }
        return number;
    }

    private string NextCharacter(int index, string s)
    {
        index++;

        if (index >= s.Length) return string.Empty;

        return s[index].ToString();
    }
}

public static class _0013RomanToInteger
{
    private static List<string> Inputs = new List<string>() { "III", "LVIII", "MCMXCIV" };
    private static List<int> ExpectedOutputs= new List<int>() { 3, 58, 1994 };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.RomanToInt(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}