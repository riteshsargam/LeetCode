public class Solution {
    public int MinMoves2(int[] nums) {
        int median = (nums.Length / 2);
nums = nums.OrderBy(i => i).ToArray();
int moves = 0;
for (int i = 0; i < nums.Length; i++)
{
    moves += Math.Abs(nums[i] - nums[median]);
}
return moves;
    }
}
