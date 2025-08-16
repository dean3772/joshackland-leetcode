/*
23. Merge k Sorted Lists
Hard
Topics
premium lock icon
Companies
You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.

Merge all the linked-lists into one sorted linked-list and return it.

Example 1:

Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted linked list:
1->1->2->3->4->4->5->6
Example 2:

Input: lists = []
Output: []
Example 3:

Input: lists = [[]]
Output: []
 

Constraints:

k == lists.length
0 <= k <= 104
0 <= lists[i].length <= 500
-104 <= lists[i][j] <= 104
lists[i] is sorted in ascending order.
The sum of lists[i].length will not exceed 104.
Seen this question in a real interview before?
1/5
Yes
No
Accepted
2,612,505/4.6M
Acceptance Rate
57.4%
Topics
Linked List
Divide and Conquer
Heap (Priority Queue)
Merge Sort 
template

 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }

public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {

    }
}
*/
using System.Globalization;

namespace LeetCode.Challenges._0023MergeKSortedLists

;
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0) return null;

        var nodeList = new List<ListNode>();

        foreach ( var list in lists )
        {
            if (list == null) continue;

            nodeList.Add(list);
        }

        if (nodeList.Count == 0) return null;

        ListNode head = new ListNode();
        ListNode currentNode = head;

        while ( nodeList.Count > 0 )
        {
            KeyValuePair<int, int> smallestIndex = new KeyValuePair<int, int>(-1, int.MaxValue);

            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].val < smallestIndex.Value)
                {
                    smallestIndex = new KeyValuePair<int, int>(i, nodeList[i].val);
                }
            }

            currentNode.val = smallestIndex.Value;

            nodeList[smallestIndex.Key] = nodeList[smallestIndex.Key].next;

            if (nodeList[smallestIndex.Key] == null)
            {
                nodeList.RemoveAt(smallestIndex.Key);
            }

            if (nodeList.Count == 0) break;

            currentNode.next = new ListNode();
            currentNode = currentNode.next;
        }

        return head;
    }
}

public static class _0023MergeKSortedLists
{
    private static List<List<int[]>> Lists = new List<List<int[]>>()
    {
        new List<int[]> {
            new int[] {1, 4, 5},
            new int[] {1, 3, 4},
            new int[] {2, 6},
        },
        new List<int[]> {
        },
        new List<int[]> {
            new int[0]
        },
    };

    private static List<List<int>> ExpectedOutputs = new List<List<int>>
    {
        new List<int> { 1,1,2,3,4,4,5,6 },
        new List<int> {  },
        new List<int> {  },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Lists.Count; i++)
        {
            ListNode[] lists = new ListNode[0];
            if (Lists[i].Count > 0)
            {
                lists = new ListNode[Lists[i].Count];

                for (int j = 0; j < Lists[i].Count; j++)
                {
                    if (Lists[i][j].Length == 0) break;
                    lists[j] = new ListNode(Lists[i][j][0]);
                    ListNode prevNode = lists[j];

                    for (int k = 1; k < Lists[i][j].Length; k++)
                    {
                        var newNode = new ListNode(Lists[i][j][k]);
                        prevNode.next = newNode;
                        prevNode = newNode;
                    }
                }
            }

            ListNode expectedOutput = null;
            if (ExpectedOutputs[i].Count > 0)
            {
                if (ExpectedOutputs[i].Count > 0)
                {
                    expectedOutput = new ListNode(ExpectedOutputs[i][0]);
                    ListNode prevExpected = expectedOutput;
                    for (int j = 1; j < ExpectedOutputs[i].Count; j++)
                    {
                        var newNode = new ListNode(ExpectedOutputs[i][j]);
                        prevExpected.next = newNode;
                        prevExpected = newNode;
                    }

                }
            }

            
            var actualOutput = solution.MergeKLists(lists);
            Console.WriteLine($"Lists: {PrintListInts(Lists[i])}, Expected Output: {PrintNodeValues(expectedOutput)} Actual Output: {PrintNodeValues(actualOutput)}");
        }
    }

    public static string PrintListInts(List<int[]> ints)
    {
        string output = "{";

        foreach(var intArr in ints)
        {
            output += "[" + string.Join(',', intArr) + "]";
        }

        output += '}';
        return output;
    }

    public static string PrintNodeValues(ListNode head)
    {
        if (head == null) return "(null)";

        string output = "";
        ListNode currentNode = head;

        while (currentNode != null)
        {
            output += currentNode.val + ", ";
            currentNode = currentNode.next;
        }

        return output;
    }
}