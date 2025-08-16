/*
14. Longest Common Prefix
Easy
Topics
premium lock icon
Companies
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 

Constraints:

1 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lowercase English letters if it is non-empty.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
4,817,237/10.5M
Acceptance Rate
45.9%
Topics
Array
String
Trie
template
public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        
    }
}
 */
namespace LeetCode.Challenges._0014LongestCommonPrefix;

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        string prefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            string currentPrefix = string.Empty;

            for (int j = 0; j < strs[i].Length; j++) 
            {
                if (j >= prefix.Length) break;

                if (strs[i][j] == prefix[j])
                {
                    currentPrefix += strs[i][j];
                }
                else
                {
                    break;
                }

            }

            prefix = currentPrefix;
        }

        return prefix;
    }
}

public static class _0014LongestCommonPrefix
{
    private static List<string[]> Inputs = new List<string[]> { 
        new string[] { "flower", "flow", "flight" },
        new string[] { "dog","racecar","car" },
    };
    private static List<string> ExpectedOutputs= new List<string>() { "fl", "" };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.LongestCommonPrefix(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}