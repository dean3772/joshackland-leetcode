/*
29. Divide Two Integers
Medium
Topics
premium lock icon
Companies
Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.

The integer division should truncate toward zero, which means losing its fractional part. For example, 8.345 would be truncated to 8, and -2.7335 would be truncated to -2.

Return the quotient after dividing dividend by divisor.

Note: Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−231, 231 − 1]. For this problem, if the quotient is strictly greater than 231 - 1, then return 231 - 1, and if the quotient is strictly less than -231, then return -231.

 

Example 1:

Input: dividend = 10, divisor = 3
Output: 3
Explanation: 10/3 = 3.33333.. which is truncated to 3.
Example 2:

Input: dividend = 7, divisor = -3
Output: -2
Explanation: 7/-3 = -2.33333.. which is truncated to -2.
 

Constraints:

-231 <= dividend, divisor <= 231 - 1
divisor != 0
Seen this question in a real interview before?
1/5
Yes
No
Accepted
989,584/5.3M
Acceptance Rate
18.6%
Topics
Math
Bit Manipulation
template
public class Solution {
    public int Divide(int dividend, int divisor) {
        
    }
}
 */
namespace LeetCode.Challenges._0029DivideTwoIntegers;

public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        bool isPositive = dividend > 0 && divisor > 0 || dividend < 0 && divisor < 0;

        long absDividend = Math.Abs((long)dividend);
        long absDivisor = Math.Abs((long)divisor);

        if (absDivisor > absDividend) return 0;

        if (absDivisor == 1)
        {
            if (!isPositive) absDividend *= -1;

            if (absDividend < Int32.MinValue) return Int32.MinValue;
            else if (absDividend > Int32.MaxValue) return Int32.MaxValue;

            return Convert.ToInt32(absDividend);
        }

        int quotient = 0;

        while (absDivisor <= absDividend)
        {
            long tempDivisor = absDivisor;
            long multiple = 1;

            while ((tempDivisor << 1) <= absDividend)
            {
                tempDivisor <<= 1;
                multiple <<= 1;
            }

            absDividend -= tempDivisor;

            if (isPositive)
            {
                if (quotient > Int32.MaxValue - multiple) return Int32.MaxValue;
                quotient += Convert.ToInt32(multiple);
            }
            else
            {
                if (quotient < Int32.MinValue + multiple) return Int32.MinValue;
                quotient -= Convert.ToInt32(multiple);
            }
        }

        return quotient;
    }
}

public static class _0029DivideTwoIntegers
{
    private static List<int> Dividends = new List<int>() {2, 10, 7 };
    private static List<int> Divisors = new List<int>() {2, 3, -3 };
    private static List<int> ExpectedOutputs= new List<int>() {1, 3, -2, };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Dividends.Count; i++)
        {
            var dividend = Dividends[i];
            var divisor = Divisors[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Divide(dividend, divisor);
            Console.WriteLine($"Dividend: {dividend}, Divisor: {divisor}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}