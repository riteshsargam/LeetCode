//C# Code
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
    List<int> res = new List<int>();
    private void preOrder(TreeNode root){
        if(root == null)
            return;
        
        res.Add(root.val);
        preOrder(root.left);
        preOrder(root.right);
    }
    public IList<int> PreorderTraversal(TreeNode root) {
        preOrder(root);
        return res;
    }
}
