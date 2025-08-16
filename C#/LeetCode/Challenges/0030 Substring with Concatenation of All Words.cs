/*
30. Substring with Concatenation of All Words
Hard
Topics
premium lock icon
Companies
You are given a string s and an array of strings words. All the strings of words are of the same length.

A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.

For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.

 

Example 1:

Input: s = "barfoothefoobarman", words = ["foo","bar"]

Output: [0,9]

Explanation:

The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.

Example 2:

Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]

Output: []

Explanation:

There is no concatenated substring.

Example 3:

Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]

Output: [6,9,12]

Explanation:

The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"].
The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"].
The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"].

 

Constraints:

1 <= s.length <= 104
1 <= words.length <= 5000
1 <= words[i].length <= 30
s and words[i] consist of lowercase English letters.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
608,142/1.8M
Acceptance Rate
33.2%
Topics
Hash Table
String
Sliding Window
template
public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        
    }
}
 */
namespace LeetCode.Challenges._0030SubstringWithConcatenationOfAllWords;

public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var indices = new List<int>();
        int wordLength = words[0].Length;
        int totalWords = words.Length;
        int concatLength = wordLength * totalWords;
        int lastIndex = s.Length - concatLength;

        var wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!wordCount.ContainsKey(word)) wordCount[word] = 0;
            wordCount[word]++;
        }

        for (int i = 0; i <= lastIndex; i++)
        {
            var seenWords = new Dictionary<string, int>();

            int concatWords = 0;

            while (concatWords < totalWords)
            {
                string currentWord = s.Substring(i + concatWords * wordLength, wordLength);

                if (!wordCount.ContainsKey(currentWord)) break;

                if (!seenWords.TryGetValue(currentWord, out int seenWordCount)
                    || seenWordCount < wordCount[currentWord])
                {
                    if (!seenWords.ContainsKey(currentWord)) seenWords[currentWord] = 0;
                    seenWords[currentWord]++;
                    concatWords++;
                }
                else
                {
                    break;
                }
            }

            if (concatWords == totalWords)
            {
                indices.Add(i);
            }
        }

        return indices;
    }
}

public static class _0030SubstringWithConcatenationOfAllWords
{
    private static List<string> Inputs = new List<string>() 
    {
        "thethethethe",
        "ababababab",
        "wordgoodgoodgoodbestword",
        "barfoothefoobarman",
        "wordgoodgoodgoodbestword",
        "barfoofoobarthefoobarman"
    };
    private static List<string[]> Words = new List<string[]>()
    {
        new string[] { "foo","foo","the","man" },
        new string[] { "ababa","babab" },
        new string[] { "word","good","best","good" },
        new string[] { "foo", "bar" },
        new string[] { "word","good","best","word" },
        new string[] { "bar","foo","the" },
    };
    private static List<List<int>> ExpectedOutputs= new List<List<int>>()
    {
        new List<int>{},
        new List<int>{0},
        new List<int>{8},
        new List<int>{0,9},
        new List<int>{},
        new List<int>{6,9,12},
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var words = Words[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.FindSubstring(input, words);
            Console.WriteLine($"Input: {input}, Words: {string.Join(',', words)}, Expected Output: {string.Join(',', expectedOutput)}, Actual Output: {string.Join(',', actualOutput)}");
        }
    }
}