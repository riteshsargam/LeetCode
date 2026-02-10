public class NumArray {
private readonly int[] sums;
    public NumArray(int[] nums) {
         sums = new int[nums.Length];

 var sum = 0;
 for (int i = 0; i < nums.Length; i++)
 {
     sum += nums[i];
     sums[i] = sum;
 }
    }
    
    public int SumRange(int left, int right) {
        if (left == 0)
    return sums[right];
else
    return sums[right] - sums[left - 1];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */
