public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) 
    {
        IList<IList<int>> result = new List<IList<int>>();
        int n = nums.Length;
        if (n < 4) return result; // Edge case
        
        Array.Sort(nums);
        for (int i = 0; i < n - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip duplicates
            // Early exit
            if ((long)nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) break;
            // Early exit
            if ((long)nums[i] + nums[n - 3] + nums[n - 2] + nums[n - 1] < target) continue;
            
            for (int j = i + 1; j < n - 2; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue; // Skip duplicates
                // Early exit
                if ((long)nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target) break;
                // Early exit
                if ((long)nums[i] + nums[j] + nums[n - 2] + nums[n - 1] < target) continue;
                
                int k = j + 1;
                int l = n - 1;
                while (k < l)
                {
                    long sum = (long)nums[i] + nums[j] + nums[k] + nums[l];
                    if (sum == target)
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[k], nums[l] });
                        k++;
                        l--;
                        // Skip duplicates
                        while (k < l && nums[k] == nums[k - 1]) k++;
                        while (k < l && nums[l] == nums[l + 1]) l--;
                    }
                    else if (sum < target) k++;
                    else  l--;
                }
            }
        }
        return result;
    }
}
