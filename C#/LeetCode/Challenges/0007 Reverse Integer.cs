/*
7. Reverse Integer
Medium

Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:

Input: x = 123
Output: 321
Example 2:

Input: x = -123
Output: -321
Example 3:

Input: x = 120
Output: 21
 

Constraints:

-231 <= x <= 231 - 1
Seen this question in a real interview before?
1/5
Yes
No
Accepted
4,286,358/14M
Acceptance Rate
30.6%
Topics
Math 
template
public class Solution {
    public int Reverse(int x) {
        
    }
}
 */
namespace LeetCode.Challenges._0007ReverseInteger;

public class Solution {
    public int Reverse(int x) {     
        bool isNegative = x < 0;

        if (isNegative){
            x = x * -1;
        }

        char[] charArray = x.ToString().ToCharArray();
        Array.Reverse(charArray);
        string strReverseX = new string(charArray);

        int reverseNum = 0;
        bool isNumeric = int.TryParse(strReverseX, out reverseNum);

        if (!isNumeric) return 0;

        return isNegative ? reverseNum * -1 : reverseNum;
    }
}