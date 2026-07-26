public class Solution {
    public int MaximumProduct(int[] nums) {
        if (nums.Length == 3) return nums[0]*nums[1]*nums[2];

        PriorityQueue<int, int> pos = new PriorityQueue<int, int>();
        PriorityQueue<int, int> neg = new PriorityQueue<int, int>();
        int negCount = 0;

        foreach (int i in nums) {
            if (pos.Count < 3) {
                pos.Enqueue(i, i);
            } else if (pos.Peek() < i) {
                pos.Dequeue();
                pos.Enqueue(i, i);
            }
            if (i < 0) {
                int j = i*-1;
                if (neg.Count < 2) {
                    neg.Enqueue(j, j);
                } else if (neg.Peek() < j) {
                    neg.Dequeue();
                    neg.Enqueue(j, j);
                }
                negCount++;
            }
        }

        // edge cases where all nums are negative
        // so we have to just take the 3 largest nums
        if (negCount == nums.Length) {
            return pos.Dequeue()*pos.Dequeue()*pos.Dequeue();
        }
        if (neg.Count == 2) {
            // case where we have 2 negative nums, so we take the max product
            int i = neg.Dequeue()*neg.Dequeue();
            int j = pos.Dequeue()*pos.Dequeue();
            return pos.Dequeue()*Math.Max(i, j);
        } else { // Case where negative nums are irrelevant
            return pos.Dequeue()*pos.Dequeue()*pos.Dequeue();
        }
    }
}
