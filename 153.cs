public class Solution {
    public int FindMin(int[] nums) {
        int l=0, h=nums.Length-1;

        while(l<h){
            int m= l+(h-l)/2;
            if(nums[m]>nums[h]){
                l=m+1;
            }else{
                h=m;
            }
        }
        return nums[l];
    }
}
