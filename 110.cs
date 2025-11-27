/**
 * Definition for a binary tree node.
 * public class TreeNode 
 * {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
 *     {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution 
{
    public bool IsBalanced(TreeNode root) 
    {
        if (root == null)
        {
            return true;
        }

        int differHigh = int.Abs(TreeHeight(root.left) - TreeHeight(root.right));
        if (differHigh > 1)
        {
            return false;
        }

        return IsBalanced(root.left) && IsBalanced(root.right);
    }

    public int TreeHeight(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        return int.Max(TreeHeight(root.left), TreeHeight(root.right)) + 1;
    }
}
