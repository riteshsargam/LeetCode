public class Solution {
    List<int> ans = new List<int>();

    public IList<int> InorderTraversal(TreeNode root) {
        if (root == null) return ans;
        InorderTraversal(root.left);
        ans.Add(root.val);
        InorderTraversal(root.right);
        return ans;
    }
} 
