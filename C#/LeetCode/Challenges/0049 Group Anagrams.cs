/*
49. Group Anagrams
Medium
Topics
premium lock icon
Companies
Given an array of strings strs, group the anagrams together. You can return the answer in any order.

 

Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]

Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Explanation:

There is no string in strs that can be rearranged to form "bat".
The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.
Example 2:

Input: strs = [""]

Output: [[""]]

Example 3:

Input: strs = ["a"]

Output: [["a"]]

 

Constraints:

1 <= strs.length <= 104
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
4,013,081/5.6M
Acceptance Rate
71.3%
Topics
Array
Hash Table
String
Sorting
template
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        
    }
}
 */
namespace LeetCode.Challenges._0049GroupAnagrams;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();

        foreach (string str in strs)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            string sorted = new string(chars);

            if (!anagrams.ContainsKey(sorted)) anagrams[sorted] = new List<string>();

            anagrams[sorted].Add(str);
        }

        return anagrams.Select(kv => kv.Value).ToList<IList<string>>();
    }
}

public static class _0049GroupAnagrams
{
    private static List<string[]> Inputs = new List<string[]>() 
    { 
        new string[] { "eat", "tea", "tan", "ate", "nat", "bat" },
        new string[] {},
        new string[] { "a" },
    };
    private static List<List<List<string>>> ExpectedOutputs= new List<List<List<string>>>() 
    { 
        new List<List<string>>
        {
            new List<string> { "bat" },
            new List<string> { "nat", "tan" },
            new List<string> { "ate", "eat", "tea" },
        },
        new List<List<string>>
        {
            new List<string>()
        },
        new List<List<string>>
        {
            new List<string> { "a" },
        }
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.GroupAnagrams(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {DisplayOutput(expectedOutput)}, Actual Output: {DisplayOutput(actualOutput)}");
        }
    }

    private static string DisplayOutput (List<List<string>> output)
    {
        string sOutput = "\n";

        foreach (var outputItem in output)
        {
            sOutput += $"[{string.Join(',', outputItem)}]";
        }

        return sOutput;
    }

    private static string DisplayOutput(IList<IList<string>> output)
    {
        string sOutput = "\n";

        foreach (var outputItem in output)
        {
            sOutput += $"[{string.Join(',', outputItem)}]";
        }

        return sOutput;
    }
}