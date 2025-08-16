/*
38. Count and Say
Medium
Topics
premium lock icon
Companies
Hint
The count-and-say sequence is a sequence of digit strings defined by the recursive formula:

countAndSay(1) = "1"
countAndSay(n) is the run-length encoding of countAndSay(n - 1).
Run-length encoding (RLE) is a string compression method that works by replacing consecutive identical characters (repeated 2 or more times) with the concatenation of the character and the number marking the count of the characters (length of the run). For example, to compress the string "3322251" we replace "33" with "23", replace "222" with "32", replace "5" with "15" and replace "1" with "11". Thus the compressed string becomes "23321511".

Given a positive integer n, return the nth element of the count-and-say sequence.

 

Example 1:

Input: n = 4

Output: "1211"

Explanation:

countAndSay(1) = "1"
countAndSay(2) = RLE of "1" = "11"
countAndSay(3) = RLE of "11" = "21"
countAndSay(4) = RLE of "21" = "1211"
Example 2:

Input: n = 1

Output: "1"

Explanation:

This is the base case.

 

Constraints:

1 <= n <= 30
 

Follow up: Could you solve it iteratively?
Seen this question in a real interview before?
1/5
Yes
No
Accepted
1,269,316/2.1M
Acceptance Rate
61.0%
Topics
String
template
public class Solution {
    public string CountAndSay(int n) {
        
    }
}
 */
namespace LeetCode.Challenges._0038CountAndSay;

public class Solution
{
    public string CountAndSay(int n)
    {
        if (n == 1) return "1";

        string num = "1";

        for (int i = 2; i <= n; i++)
        {
            List<int> numbers = new List<int>();
            int currentNum = Convert.ToInt32(num.Substring(0, 1));
            numbers.Add(1);
            numbers.Add(currentNum);

            for (int j = 1; j < num.Length; j++)
            {
                currentNum = Convert.ToInt32(num.Substring(j, 1));
                int length = numbers.Count;
                if (currentNum == numbers[length - 1])
                {
                    numbers[length - 2]++;
                }
                else
                {
                    numbers.Add(1);
                    numbers.Add(currentNum);
                }
            };

            num = string.Join("", numbers);
        }

        return num;
    }
}

public static class _0038CountAndSay
{
    private static List<int> Inputs = new List<int>() 
    { 
        1,
        4
    };
    private static List<string> ExpectedOutputs= new List<string>()
    {
        "1",
        "1211"
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.CountAndSay(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}