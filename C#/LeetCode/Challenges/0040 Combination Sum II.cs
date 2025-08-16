/*
40. Combination Sum II
Medium
Topics
premium lock icon
Companies
Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.

 

Example 1:

Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]
Example 2:

Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
[1,2,2],
[5]
]
 

Constraints:

1 <= candidates.length <= 100
1 <= candidates[i] <= 50
1 <= target <= 30
Seen this question in a real interview before?
1/5
Yes
No
Accepted
1,466,745/2.5M
Acceptance Rate
58.0%
Topics
Array
Backtracking
template
public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        
    }
}
 */
namespace LeetCode.Challenges._0040CombinationSumII;

public class Solution
{
    public List<IList<int>> output;
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        output = new List<IList<int>>();

        Array.Sort(candidates);

        Sum(0, candidates.ToList(), target, new List<int>());

        return output;
    }

    public void Sum(int sum, List<int> candidates, int target, List<int> combination)
    {
        var candidatesCopy = new List<int>(candidates);
        int previousNum = 0;

        foreach (int candidate in candidates)
        {
            if (candidate == previousNum)
            {
                candidatesCopy.RemoveAt(0);
                continue;
            }
            previousNum = candidate;

            List<int> combinationCopy = new List<int>(combination);
            int sumcopy = sum + candidate;

            if (sumcopy > target) return;

            combinationCopy.Add(candidate);

            if (sumcopy == target)
            {
                output.Add(combinationCopy);
                return;
            }

            candidatesCopy.RemoveAt(0);
            Sum(sumcopy, candidatesCopy, target, combinationCopy);
        }
    }
}

public static class _0040CombinationSumII
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { 10,1,2,7,6,1,5 },
        new int[] { 2,5,2,1,2 },
    };
    private static List<int> Targets = new List<int>()
    {
        8,
        5,
    };
    private static List<List<List<int>>> ExpectedOutputs= new List<List<List<int>>>() 
    { 
        new List<List<int>>
        {
            new List<int> { 1, 1, 6 },
            new List<int> { 1, 2, 5 },
        },
        new List<List<int>>
        {
            new List<int> { 1, 2, 2 },
            new List<int> { 5 },
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
            var actualOutput = solution.CombinationSum2(input, target);
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