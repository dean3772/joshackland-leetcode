/*
 60. Permutation Sequence
Hard
Topics
premium lock icon
Companies
The set [1, 2, 3, ..., n] contains a total of n! unique permutations.

By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

"123"
"132"
"213"
"231"
"312"
"321"
Given n and k, return the kth permutation sequence.

 

Example 1:

Input: n = 3, k = 3
Output: "213"
Example 2:

Input: n = 4, k = 9
Output: "2314"
Example 3:

Input: n = 3, k = 1
Output: "123"
 

Constraints:

1 <= n <= 9
1 <= k <= n!
Seen this question in a real interview before?
1/5
Yes
No
Accepted
499,035/989.1K
Acceptance Rate
50.5%
Topics
Math
Recursion
template
public class Solution {
    public string GetPermutation(int n, int k) {
        
    }
}
 */

namespace LeetCode.Challenges._0060PermutationSequence;

public class Solution
{ 
    public class Permutation
    {
        public int k;
        public int PermutationCount;
    }
    public string GetPermutation(int n, int k)
    {
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = i+1;
        }

        string output = Permutations(nums.ToList(), new List<int>(), new Permutation { k = k, PermutationCount = 0 });

        return output;
    }

    public string Permutations(List<int> nums, List<int> currentPermutation, Permutation p)
    {
        string permutation = "";

        if (nums.Count == 1)
        {
            currentPermutation.Add(nums[0]);
            p.PermutationCount++;
            return string.Join("", currentPermutation);
        }

        for (int i = 0; i < nums.Count; i++)
        {
            List<int> copyPermutation = new List<int>(currentPermutation);
            List<int> copyNums = new List<int>(nums);

            copyPermutation.Add(nums[i]);
            copyNums.RemoveAt(i);

            permutation = Permutations(copyNums, copyPermutation, p);

            if (p.PermutationCount == p.k) return permutation;
        }

        return permutation;
    }
}

public static class _0060PermutationSequence
{
    private static List<int> Inputs = new List<int>()
    {
        3,
        4,
        3
    };
    private static List<int> Ks = new List<int>()
    {
        3, 
        9, 
        1
    };
    private static List<string> ExpectedOutputs = new List<string>()
    {
        "213",
        "2314",
        "123"
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var k = Ks[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.GetPermutation(input, k);
            Console.WriteLine($"Input: {input}, K: {k}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}