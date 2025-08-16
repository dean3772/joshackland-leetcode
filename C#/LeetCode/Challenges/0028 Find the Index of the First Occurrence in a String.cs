/*
28. Find the Index of the First Occurrence in a String
Easy
Topics
premium lock icon
Companies
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

 

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 

Constraints:

1 <= haystack.length, needle.length <= 104
haystack and needle consist of only lowercase English characters.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
3,493,186/7.7M
Acceptance Rate
45.3%
Topics
Two Pointers
String
String Matching
template
public class Solution {
    public int StrStr(string haystack, string needle) {
        
    }
}
 */
namespace LeetCode.Challenges._0028FindTheIndexOfTheFirstOccurrenceInAString
    ;

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        int needleLength = needle.Length;

        for (int i = 0; i <= haystack.Length - needleLength; i++)
        {
            if (haystack.Substring(i, needleLength) == needle) return i;
        }

        return -1;
    }
}

public static class _0028FindTheIndexOfTheFirstOccurrenceInAString
{
    private static List<string> Haystacks = new List<string>() 
    { 
        "stadbutsad",
        "leetcode"
    };
    private static List<string> Needles = new List<string>()
    {
        "sad",
        "leeto"
    };
    private static List<int> ExpectedOutputs= new List<int>() { 0, -1 };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Haystacks.Count; i++) 
        {
            var haystack = Haystacks[i];
            var needle = Needles[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.StrStr(haystack, needle);
            Console.WriteLine($"Haystack: {haystack}, Needle: {needle}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}