public class Codec {
    //  Serialize: BFS traversal with null markers
    public string serialize(TreeNode root) {
        if (root == null) return "null";

        var queue = new Queue<TreeNode>();
        var result = new List<string>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            if (node == null) {
                result.Add("null");
                continue;
            }

            result.Add(node.val.ToString());
            queue.Enqueue(node.left);  // even if null
            queue.Enqueue(node.right); // even if null
        }

        return string.Join(",", result);
    }

    //  Deserialize: rebuild tree from BFS string
    public TreeNode deserialize(string data) {
        if (data == "null") return null;

        var nodes = data.Split(',');
        var root = new TreeNode(int.Parse(nodes[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (queue.Count > 0 && i < nodes.Length) {
            var parent = queue.Dequeue();

            // Left child
            if (nodes[i] != "null") {
                parent.left = new TreeNode(int.Parse(nodes[i]));
                queue.Enqueue(parent.left);
            }
            i++;

            // Right child
            if (i < nodes.Length && nodes[i] != "null") {
                parent.right = new TreeNode(int.Parse(nodes[i]));
                queue.Enqueue(parent.right);
            }
            i++;
        }

        return root;
    }
}
