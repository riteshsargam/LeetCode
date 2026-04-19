public class Solution {
    public int MaxDistance(int[] nums1, int[] nums2) {
        int maxDist = 0;
        int j = 0;  // pointer in nums2

        for (int i = 0; i < nums1.Length; i++) {
            // Move j as far right as possible while nums1[i] <= nums2[j] and j >= i
            while (j < nums2.Length && nums1[i] <= nums2[j]){
                maxDist = Math.Max(maxDist, j - i);
                j++;
            }
        }

        return maxDist;
    }
}
