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
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
     private ListNode head = null;

 public TreeNode SortedListToBST(ListNode head)
 {
     var p = head;
     var length = 0;
     while (p != null)
     {
         p = p.next;
         length++;
     }

     this.head = head;

     return SortedListToBST(0, length);
 }

 public TreeNode SortedListToBST(int l, int r)
 {
     if (l >= r) return null;
     var mid = l + (r - l) / 2;

     var left = SortedListToBST(l, mid);
     var node = new TreeNode(head.val);
     node.left = left;
     this.head = this.head.next;
     node.right = SortedListToBST(mid + 1, r);
     return node;
 }
}
