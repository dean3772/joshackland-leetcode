/*
15. 3Sum
Medium
Topics
premium lock icon
Companies
Hint
Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

 

Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.
Example 2:

Input: nums = [0,1,1]
Output: []
Explanation: The only possible triplet does not sum up to 0.
Example 3:

Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: The only possible triplet sums up to 0.
 

Constraints:

3 <= nums.length <= 3000
-105 <= nums[i] <= 105
Seen this question in a real interview before?
1/5
Yes
No
Accepted
5,006,362/13.4M
Acceptance Rate
37.5%
Topics
Array
Two Pointers
Sorting
icon
Companies
Hint 1
So, we essentially need to find three numbers x, y, and z such that they add up to the given value. If we fix one of the numbers say x, we are left with the two-sum problem at hand!
Hint 2
For the two-sum problem, if we fix one of the numbers, say x, we have to scan the entire array to find the next number y, which is value - x where value is the input parameter. Can we change our array somehow so that this search becomes faster?
Hint 3
The second train of thought for two-sum is, without changing the array, can we use additional space somehow? Like maybe a hash map to speed up the search? 
template
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        
    }
}
 */
namespace LeetCode.Challenges._00153Sum;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {        
        var output = new List<IList<int>>();

        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 1 && nums[i] == nums[i - 1]) continue;

            int low = i + 1;
            int high = nums.Length - 1;

            while (low < high)
            {
                int sum = nums[i] + nums[low] + nums[high];

                if (sum == 0)
                {
                    var numlist = new List<int>() { nums[i], nums[low], nums[high] };
                    bool exists = false;
                    foreach (var nlist in output)
                    {
                        if (nlist[0] == numlist[0] && nlist[1] == numlist[1] && nlist[2] == numlist[2])
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        output.Add(numlist);
                    }

                    while (low < high && nums[low] == nums[low + 1])
                    {
                        low++;
                    }
                    while (low < high && nums[high] == nums[high - 1])
                    {
                        high--;
                    }

                    low++;
                    high--;
                }
                else if (sum < 0)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }
        }

        return output;
    }
}

public static class _00153Sum
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { -1, 0, 1, 2, -1, -4 },
        new int[] { 0, 1, 1 },
        new int[] { 0, 0, 0 },
    };
    private static List<List<List<int>>> ExpectedOutputs= new List<List<List<int>>>() 
    { 
        new List<List<int>> { 
            new List<int> { -1, -1, 2 },
            new List<int> { -1, 0, 1 }
        },
        new List<List<int>>(),
        new List<List<int>> {
            new List<int> { 0, 0, 0 },
        }
    };
    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.ThreeSum(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}