/*
3. Longest Substring Without Repeating Characters
Medium
Given a string s, find the length of the longest substring without duplicate characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 
Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
7,946,976/21.3M
Acceptance Rate
37.3%
Topics
Hash Table
String
Sliding Window
Hint 1
Generate all possible substrings & check for each substring if it's valid and keep updating maxLen accordingly. 
template they give
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        
    }
}

 */
namespace LeetCode.Challenges._0003LongestSubstringWithoutRepeatingCharacters;
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int count = 0;
        
        int currentCount = 0;
        var currentLetters = new List<char>();
        int startingIndex = 0;

        for (int i = 0; i < s.Length; i++){
            if (currentCount == 0){
                startingIndex = i+1;
            }
            if (currentLetters.Contains(s[i])){
                if (count < currentCount){
                    count = currentCount;
                }
                currentLetters = new List<char>();
                i = startingIndex-1;
                currentCount = 0;
            }
            else {
                currentCount++;
                currentLetters.Add(s[i]);
            }
        }

        if (count < currentCount){
            return currentCount;
        }

        return count;
    }
}