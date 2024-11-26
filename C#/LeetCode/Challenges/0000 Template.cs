﻿namespace LeetCode.Challenges._0000Template;

public class Solution
{
    public int Template(int x)
    {
        return x + 1;
    }
}

public static class _0000Template
{
    private static List<int> Inputs = new List<int>() { 1, 2, 3 };
    private static List<int> ExpectedOutputs= new List<int>() { 2, 3, 4 };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Template(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}