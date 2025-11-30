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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        IList<IList<int>> result = new List<IList<int>>();

        helper(result, new List<int>(), root, targetSum);
        return result;
    }

    void helper(IList<IList<int>> result, IList<int> curr, TreeNode root, int sum){
        
        if(root == null) return;
        curr.Add(root.val);
        int remSum = sum - root.val;

        if(root.left == null && root.right == null){
            if(remSum == 0) {
                result.Add(new List<int>(curr));
                return;
            } 
        }

        helper(result, curr, root.left, remSum);
        if(root.left != null){
            curr.RemoveAt(curr.Count-1);
        }
 
        helper(result, curr, root.right, remSum);
        if(root.right != null){
            curr.RemoveAt(curr.Count-1);
        }
    }
}
