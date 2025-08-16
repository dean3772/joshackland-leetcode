/*
5. Longest Palindromic Substring
Medium

Given a string s, return the longest palindromic substring in s.

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
Example 2:

Input: s = "cbbd"
Output: "bb"
 
Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
4,061,547/11.2M
Acceptance Rate
36.2%
Topics
Two Pointers
String
Dynamic Programming
Hint 1
How can we reuse a previously computed palindrome to compute a larger palindrome?
Hint 2
If “aba” is a palindrome, is “xabax” a palindrome? Similarly is “xabay” a palindrome?
Hint 3
Complexity based hint:
If we use brute-force and check whether for every start and end position a substring is a palindrome we have O(n^2) start - end pairs and O(n) palindromic checks. Can we reduce the time for palindromic checks to O(1) by reusing some previous computation. 
template they give
public class Solution {
    public string LongestPalindrome(string s) {
        
    }
}
 */
namespace LeetCode.Challenges._0005LongestPalindrome;

public class Solution {
    public string LongestPalindrome(string s) {
        string LongestPalindrome = s[0].ToString();

        for (int i = 0; i < s.Length - 1; i++){
            if (s.Length - i < LongestPalindrome.Length) break;
            string currentString = s[i].ToString();

            for (int j = i+1; j < s.Length; j++){
                currentString += s[j].ToString();
                if (currentString.Length <= LongestPalindrome.Length) continue;

                int currentStringLength = currentString.Length;
                
                bool palindrome = true;
                for (int index = 0; index < currentString.Length / 2; index++){
                    if (currentString[index] != currentString[currentString.Length-1-index]){
                        palindrome = false;
                        break;
                    }
                }
                if (palindrome) LongestPalindrome = currentString;
            }
        }

        return LongestPalindrome;
    }
}