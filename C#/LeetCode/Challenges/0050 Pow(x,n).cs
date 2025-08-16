/*
50. Pow(x, n)
Medium
Topics
premium lock icon
Companies
Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

 

Example 1:

Input: x = 2.00000, n = 10
Output: 1024.00000
Example 2:

Input: x = 2.10000, n = 3
Output: 9.26100
Example 3:

Input: x = 2.00000, n = -2
Output: 0.25000
Explanation: 2-2 = 1/22 = 1/4 = 0.25
 

Constraints:

-100.0 < x < 100.0
-231 <= n <= 231-1
n is an integer.
Either x is not zero or n > 0.
-104 <= xn <= 104
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,348,375/6.3M
Acceptance Rate
37.4%
Topics
Math
Recursion
template
public class Solution {
    public double MyPow(double x, int n) {
        
    }
}
 */
namespace LeetCode.Challenges._0050PowXN;

public class Solution
{
    public double MyPow(double x, int n)
    {
        if (x == 1) return x;
        if (n == 0) return 1;

        double current = x;

        if (n < 0)
        {
            x = 1 / x;
            current = x;
            if (n != Int32.MinValue)
            {
                n = n * -1;
            }
            else
            {
                current *= current;
                n = (n / 2) * -1;
            }
        }

        double output = 1;

        while (n > 0)
        {
            if (n % 2 == 1)
            {
                output *= current;
            }

            current *= current;
            n /= 2;
        }


        return output;
    }
}

public static class _0050PowXN
{
    private static List<double> Inputs = new List<double>() 
    { 
        -1,
        2,
        2,
        2.1,
        2
    };
    private static List<int> Ns = new List<int>()
    {
        -2147483648,
        -2147483648,
        10,
        3,
        -2
    };
    private static List<double> ExpectedOutputs= new List<double>()
    {
        1,
        0,
        1024,
        9.261,
        0.25
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var n = Ns[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.MyPow(input, n);
            Console.WriteLine($"Input: {input}, N: {n}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}