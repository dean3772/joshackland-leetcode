/*
10. Regular Expression Matching
Hard

Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

'.' Matches any single character.​​​​
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
Example 3:

Input: s = "ab", p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".
 

Constraints:

1 <= s.length <= 20
1 <= p.length <= 20
s contains only lowercase English letters.
p contains only lowercase English letters, '.', and '*'.
It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
1,207,539/4.1M
Acceptance Rate
29.5%
Topics
String
Dynamic Programming
Recursion 
template
public class Solution {
    public bool IsMatch(string s, string p) {
        
    }
}
 */
namespace LeetCode.Challenges._0010RegularExpressionMatching;

public class Solution {
    public bool IsMatch(string s, string p) {
        int sLocation = 0;
        int pLocation = 0;

        while (sLocation <= s.Length) {
            if (pLocation == p.Length) {
                return sLocation == s.Length;
            }
            if (pLocation + 1 < p.Length && p[pLocation + 1] == '*') {
                char c = p[pLocation];
                pLocation += 2;
                while (pLocation + 1 < p.Length && c == p[pLocation] && p[pLocation+1] == '*')
                {
                    pLocation += 2;
                }
                while (sLocation < s.Length && (s[sLocation] == c || c == '.')) {
                    if (IsMatch(s.Substring(sLocation), p.Substring(pLocation))) {
                        return true;
                    }
                    sLocation++;
                }
            } else {
                if (sLocation == s.Length || (s[sLocation] != p[pLocation] && p[pLocation] != '.')) {
                    return false;
                }
                sLocation++;
                pLocation++;
            }
        }
        return false;
    }
}
