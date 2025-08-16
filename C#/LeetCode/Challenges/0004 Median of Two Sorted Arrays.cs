/*
4. Median of Two Sorted Arrays
Hard

Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 

Constraints:

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
Seen this question in a real interview before?
1/5
Yes
No
Accepted
3,600,602/8.1M
Acceptance Rate
44.4%
Topics
Array
Binary Search
Divide and Conquer 
template they give
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
    }
}
 */
namespace LeetCode.Challenges._0004MedianOfTwoSortedArrays;

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int length = nums1.Length + nums2.Length;
        int indexStop = (int)Math.Ceiling((double)length / 2) - 1;

        int nums1Index = 0;
        int nums2Index = 0;

        for (int i = 0; i < length; i++)
        {
            bool smallestIsNums1 = false;
            if (nums2Index >= nums2.Length || nums1Index < nums1.Length && nums1[nums1Index] < nums2[nums2Index]){
                nums1Index++;
                smallestIsNums1 = true;
            } else {
                nums2Index++;
            }

            if (i == indexStop){
                if (length % 2 == 0){
                    int evenNum1 = smallestIsNums1 ? nums1[nums1Index - 1] : nums2[nums2Index - 1];

                    int evenNum2 = nums2Index >= nums2.Length || nums1Index < nums1.Length && nums1[nums1Index] < nums2[nums2Index] ? nums1[nums1Index] : nums2[nums2Index];
                    return ((double)evenNum1 + (double)evenNum2) / 2;
                }
                else {
                    if (smallestIsNums1){
                        return nums1[nums1Index - 1];
                    } else {
                        return nums2[nums2Index - 1];
                    }
                }
            }
        }
        return 0;
    }
}