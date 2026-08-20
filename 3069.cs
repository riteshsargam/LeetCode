public class Solution {
    public int[] ResultArray(int[] nums) {
        int n1 = nums[0], n2 = nums[1];
        List<int> arr1 = new([n1]), arr2 = new([n2]);
        for(int i = 2; i < nums.Length; i++)
        {
            if(n1 > n2)
            {
                arr1.Add(nums[i]);
                n1 = nums[i];
            }
            else
            {
                arr2.Add(nums[i]);
                n2 = nums[i];
            }
        }
        arr1.AddRange(arr2);  
        return arr1.ToArray();  
    }
}
