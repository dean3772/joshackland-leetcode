/*
58. Length of Last Word
Easy
Topics
premium lock icon
Companies
Given a string s consisting of words and spaces, return the length of the last word in the string.

A word is a maximal substring consisting of non-space characters only.

 

Example 1:

Input: s = "Hello World"
Output: 5
Explanation: The last word is "World" with length 5.
Example 2:

Input: s = "   fly me   to   the moon  "
Output: 4
Explanation: The last word is "moon" with length 4.
Example 3:

Input: s = "luffy is still joyboy"
Output: 6
Explanation: The last word is "joyboy" with length 6.
 

Constraints:

1 <= s.length <= 104
s consists of only English letters and spaces ' '.
There will be at least one word in s.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,902,690/5.1M
Acceptance Rate
56.8%
Topics
String
template
public class Solution {
    public int LengthOfLastWord(string s) {
        
    }
}
 */
namespace LeetCode.Challenges._0058LengthOfLastWord;

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int output = 0;

        int lastIndex = s.Length - 1;

        while (s[lastIndex] == ' ') lastIndex--;

        while (lastIndex >= 0 && s[lastIndex] != ' ')
        {
            output++;
            lastIndex--;
        }

        return output;
    }
}

public static class _0058LengthOfLastWord
{
    private static List<string> Inputs = new List<string>() 
    {
        "Hello World",
        "   fly me   to   the moon  ",
        "luffy is still joyboy",
    };
    private static List<int> ExpectedOutputs= new List<int>() 
    { 
        5, 
        4, 
        6
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.LengthOfLastWord(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}