/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int PairSum(ListNode head) {
        ListNode slow = head;
        ListNode fast = head.next;

        //list to store first n/2 linked-list elements
        //then add remaining n/2 linked-list elements in reverse order
        List<int> temp = new List<int>();
        temp.Add(slow.val);
        
        //using slow-fast pointer approach
        //to find mid-point of linked-list
        while (fast.next != null)
        {
            slow = slow.next;
            temp.Add(slow.val);
            fast = fast.next.next;
        }

        //find maximum twin-sum
        int maxTwinSum = int.MinValue;
        for (int i = temp.Count - 1; i >= 0; i--)
        {
            slow = slow.next;
            temp[i] += slow.val;
            maxTwinSum = Math.Max(maxTwinSum, temp[i]);
        }

        return maxTwinSum;
    }
}
