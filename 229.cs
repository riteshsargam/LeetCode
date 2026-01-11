public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        int? candidate1 = null, candidate2 = null, count1 = 0, count2 = 0;
        foreach (int num in nums) {
            if (candidate1.HasValue && num == candidate1) {
                count1++;
            } else if (candidate2.HasValue && num == candidate2) {
                count2++;
            } else if (count1 == 0) {
                candidate1 = num;
                count1 = 1;
            } else if (count2 == 0) {
                candidate2 = num;
                count2 = 1;
            } else {
                count1--;
                count2--;
            }
        }
        
        var result = new List<int>();
        if (nums.Count(n => n == candidate1) > nums.Length / 3) result.Add(candidate1.Value);
        if (nums.Count(n => n == candidate2) > nums.Length / 3) result.Add(candidate2.Value);
        return result;
    }
}
