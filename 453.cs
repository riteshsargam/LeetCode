public class Solution {
    public int MinMoves(int[] nums) {
         var min = nums.Min();
 var count = 0;
 foreach (var num in nums)
     count += num - min;

 return count;
    }
}
