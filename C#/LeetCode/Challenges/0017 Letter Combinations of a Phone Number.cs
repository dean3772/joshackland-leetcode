/*
17. Letter Combinations of a Phone Number
Medium
Topics
premium lock icon
Companies
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.


 

Example 1:

Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
Example 2:

Input: digits = ""
Output: []
Example 3:

Input: digits = "2"
Output: ["a","b","c"]
 

Constraints:

0 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,660,940/4.1M
Acceptance Rate
64.3%
Topics
Hash Table
String
Backtracking
template
public class Solution {
    public IList<string> LetterCombinations(string digits) {
        
    }
}
 */
namespace LeetCode.Challenges._0017LetterCombinationsOfAPhoneNumber;

public class Solution
{
    private Dictionary<string, List<string>> digitLetter = new Dictionary<string, List<string>>()
    {
        ["2"] = new List<string> { "a", "b", "c" },
        ["3"] = new List<string> { "d", "e", "f" },
        ["4"] = new List<string> { "g", "h", "i" },
        ["5"] = new List<string> { "j", "k", "l" },
        ["6"] = new List<string> { "m", "n", "o" },
        ["7"] = new List<string> { "p", "q", "r", "s" },
        ["8"] = new List<string> { "t", "u", "v" },
        ["9"] = new List<string> { "w", "x", "y", "z" },
    };

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0) return new List<string>();

        var output = new List<string>();

        output = CreateCombinations(output, "", digits);

        return output;
    }

    private List<string> CreateCombinations(List<string> combinations, string currentCombination, string remainingDigits)
    {        
        foreach (string letter in digitLetter[remainingDigits.Substring(0, 1)])
        {
            var tempCombination = currentCombination + letter;

            if (remainingDigits.Length > 1)
            {
                combinations = CreateCombinations(combinations, tempCombination, remainingDigits.Substring(1));
            }
            else
            {
                combinations.Add(tempCombination);
            }
        }

        return combinations;
    }
}

public static class _0017LetterCombinationsOfAPhoneNumber
{
    private static List<string> Inputs = new List<string>() { "23", "", "2" };
    private static List<List<string>> ExpectedOutputs= new List<List<string>>()
    {
        new List<string> {"ad","ae","af","bd","be","bf","cd","ce","cf"},
        new List<string>(),
        new List<string> {"a","b","c"},
    };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.LetterCombinations(input);
            Console.WriteLine($"Input: {input}, Expected Output: {string.Join(',', expectedOutput)}, Actual Output: {string.Join(',', actualOutput)}");
        }
    }
}