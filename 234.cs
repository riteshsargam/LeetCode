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
    public bool IsPalindrome(ListNode head) {
        List<int> values = new List<int>();
        while (head != null) {
            values.Add(head.val);
            head = head.next;
        }
        for (int i = 0, j = values.Count - 1; i < j; i++, j--) {
            if (values[i] != values[j]) return false;
        }
        return true;
    }
}
