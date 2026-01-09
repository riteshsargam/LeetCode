public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        ListNode current = head;
        ListNode nextNode = null;
        
        while (current != null) {
            nextNode = current.next; // Save the next node
            current.next = prev; // Reverse the link
            prev = current; // Move pointers one position ahead
            current = nextNode;
        }
        
        // 'prev' now points to the new head of the reversed list
        return prev;
    }
}
