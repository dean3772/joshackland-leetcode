/*
39. Combination Sum
Medium
Topics
premium lock icon
Companies
Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the frequency of at least one of the chosen numbers is different.

The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

 

Example 1:

Input: candidates = [2,3,6,7], target = 7
Output: [[2,2,3],[7]]
Explanation:
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.
7 is a candidate, and 7 = 7.
These are the only two combinations.
Example 2:

Input: candidates = [2,3,5], target = 8
Output: [[2,2,2,2],[2,3,3],[3,5]]
Example 3:

Input: candidates = [2], target = 1
Output: []
 

Constraints:

1 <= candidates.length <= 30
2 <= candidates[i] <= 40
All elements of candidates are distinct.
1 <= target <= 40
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,693,340/3.6M
Acceptance Rate
75.1%
Topics
Array
Backtracking
template
public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        
    }
}
 */
namespace LeetCode.Challenges._0039CombinationSum;

public class Solution
{
    public List<IList<int>> output;
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        output = new List<IList<int>>();

        Array.Sort(candidates);

        Sum(0, candidates.ToList(), target, new List<int>());

        return output;
    }

    public void Sum(int sum, List<int> candidates, int target, List<int> combination)
    {
        var candidatesCopy = new List<int>(candidates);

        foreach (int candidate in candidates)
        {
            List<int> combinationCopy = new List<int>(combination);
            int sumcopy = sum + candidate;

            if (sumcopy > target) return;

            combinationCopy.Add(candidate);

            if (sumcopy == target)
            {
                output.Add(combinationCopy);
                return;
            }

            Sum(sumcopy, candidatesCopy, target, combinationCopy);
            candidatesCopy.RemoveAt(0);
        }
    }
}

public static class _0039CombinationSum
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { 8,7,4,3 },
        new int[] { 2, 3, 6, 7 },
        new int[] { 2, 3, 5 },
        new int[] { 2 },
    };
    private static List<int> Targets = new List<int>()
    {
        11,
        7,
        8,
        1
    };
    private static List<List<List<int>>> ExpectedOutputs= new List<List<List<int>>>() 
    { 
        new List<List<int>>
        {
            new List<int> { 8, 3 },
            new List<int> { 7, 4 },
            new List<int> { 4, 4, 3 },
        },
        new List<List<int>>
        {
            new List<int> { 2, 2, 3 },
            new List<int> { 7 },
        },
        new List<List<int>>
        {
            new List<int> { 2, 2, 2, 2 },
            new List<int> { 2, 3, 3 },
            new List<int> { 3, 5 },
        },
        new List<List<int>>
        {
        },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.CombinationSum(input, target);
            Console.WriteLine($"Input: {string.Join(',',input)}, Target: {target}, Expected Output: {JoinLists(expectedOutput)}, Actual Output: {JoinLists(actualOutput)}");
        }
    }

    private static string JoinLists(List<List<int>> list)
    {
        string output = "\n";

        foreach (var nums in list)
        {
            output += string.Join(',', nums) + "\n";
        }

        return output;
    }
    private static string JoinLists(IList<IList<int>> list)
    {
        string output = "\n";

        foreach (var nums in list)
        {
            output += string.Join(',', nums) + "\n";
        }

        return output;
    }
}