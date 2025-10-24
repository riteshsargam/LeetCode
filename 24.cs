public class Solution {
    public ListNode SwapPairs(ListNode head) {
        ListNode dummy = new ListNode(0), prev;
        dummy.next = head;
        prev = dummy;

        while(prev.next != null && prev.next.next != null)
        {
            ListNode node1 = prev.next, node2 = prev.next.next, node3 = node2.next;

            prev.next = node2;
            node2.next = node1;
            node1.next = node3;
            
            prev = node1;
        }

        return dummy.next;
    }
}
