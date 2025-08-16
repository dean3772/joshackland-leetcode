/*
44. Wildcard Matching
Hard
Topics
premium lock icon
Companies
Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).
The matching should cover the entire input string (not partial).

 

Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "*"
Output: true
Explanation: '*' matches any sequence.
Example 3:

Input: s = "cb", p = "?a"
Output: false
Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.
 

Constraints:

0 <= s.length, p.length <= 2000
s contains only lowercase English letters.
p contains only lowercase English letters, '?' or '*'.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
756,699/2.5M
Acceptance Rate
30.3%
Topics
String
Dynamic Programming
Greedy
Recursion
template
public class Solution {
    public bool IsMatch(string s, string p) {
        
    }
}
 */
namespace LeetCode.Challenges._0044WildcardMatching;

public class Solution {
    public bool IsMatch(string s, string p) {
        if (p == "*") return true;

        int sLocation = 0;
        int pLocation = 0;

        int pStar = -1;
        int lastMatch = -1;


        while(sLocation < s.Length)
        {
            char sChar = s[sLocation];

            if (pLocation < p.Length && (p[pLocation] == '?' || sChar == p[pLocation]))
            {
                sLocation++;
                pLocation++;
            }
            else if (pLocation < p.Length && p[pLocation] == '*')
            {
                pStar = pLocation;
                lastMatch = sLocation;
                pLocation++;
            }
            else if (pStar == -1)
            {
                return false;
            }
            else
            {
                pLocation = pStar + 1;
                sLocation = lastMatch + 1;
                lastMatch = sLocation;
            }
        }

        while (pLocation < p.Length && p[pLocation] == '*') pLocation++;

        return pLocation == p.Length;
    }
}


public static class _0044WildcardMatching
{
    private static List<string> Ss = new List<string>()
    {
        "aa",
        "aa",
        "cb",
    };
    private static List<string> Ps = new List<string>()
    {
        "a",
        "*a",
        "?a",
    };
    private static List<bool> ExpectedOutputs = new List<bool>()
    {
        false,
        true,
        false
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Ss.Count; i++)
        {
            var s = Ss[i];
            var p = Ps[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.IsMatch(s, p);
            Console.WriteLine($"S: {s}, P: {p}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}