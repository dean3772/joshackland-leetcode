/*
20. Valid Parentheses
Easy
Topics
premium lock icon
Companies
Hint
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 

Example 1:

Input: s = "()"

Output: true

Example 2:

Input: s = "()[]{}"

Output: true

Example 3:

Input: s = "(]"

Output: false

Example 4:

Input: s = "([])"

Output: true

Example 5:

Input: s = "([)]"

Output: false

 

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
6,417,387/15M
Acceptance Rate
42.7%
Topics
String
Stack
icon
Companies
Hint 1
Use a stack of characters.
Hint 2
When you encounter an opening bracket, push it to the top of the stack.
Hint 3
When you encounter a closing bracket, check if the top of the stack was the opening for it. If yes, pop it from the stack. Otherwise, return false.
 template
public class Solution {
    public bool IsValid(string s) {
        
    }
}
 */
namespace LeetCode.Challenges._0020ValidParentheses;

public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> openingParentheses = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                openingParentheses.Push(c);
            }
            else
            {
                if (openingParentheses.Count == 0) return false;
                var opening = openingParentheses.Pop();

                if (opening == '(' && c != ')'
                    || opening == '{' && c != '}'
                    || opening == '[' && c != ']') return false;
            }
        }

        if (openingParentheses.Count > 0) return false;

        return true;
    }
}

public static class _0020ValidParentheses
{
    private static List<string> Inputs = new List<string>() { "()", "()[]{}", "(]" };
    private static List<bool> ExpectedOutputs = new List<bool>() { true, true, false };
    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.IsValid(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}