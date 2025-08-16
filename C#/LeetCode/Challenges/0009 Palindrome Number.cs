/*
9. Palindrome Number
Easy

Hint
Given an integer x, return true if x is a palindrome, and false otherwise.

Example 1:

Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.
Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 

Constraints:

-231 <= x <= 231 - 1
 

Follow up: Could you solve it without converting the integer to a string?
Seen this question in a real interview before?
1/5
Yes
No
Accepted
6,787,412/11.4M
Acceptance Rate
59.5%
Topics
Math
icon
Companies
Hint 1
Beware of overflow when you reverse the integer. 
template
public class Solution {
    public bool IsPalindrome(int x) {
        
    }
}
 */
namespace LeetCode.Challenges._0009PalindromeNumber;

public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 0) return false;

        string strX = x.ToString();

        for (int i = 0; i < strX.Length / 2; i++){
            if (strX[i] != strX[strX.Length -1 - i]) return false;
        }

        return true;
    }
}