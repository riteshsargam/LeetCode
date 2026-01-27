public class Solution {
    public int MissingNumber(int[] nums) {      
        int originalSum=0;
        int expectedSum=0;
        for(int i=0;i<nums.Length+1;i++){
            if(i<nums.Length){
               originalSum+=nums[i];
            }
            expectedSum+=i;
        }
        return expectedSum-originalSum;
    }
}
