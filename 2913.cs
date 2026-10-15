using System;
using System.Collections.Generic;

public class Solution {
    private const int MaxNum = 100;

    public int SumCounts(IList<int> nums) {
        int sum = 0;
        int n = nums.Count;

        // 1. Iterate over all possible subarray starting positions
        for (int i = 0; i < n; ++i) {
            // Reset distinct element tracker for the new starting position
            // stackalloc avoids heap allocation, maximizing C# performance
            Span<bool> numMask = stackalloc bool[MaxNum + 1];
            int uniqueCnt = 0;

            // 2. Extend subarray to the right and dynamically track unique elements
            for (int j = i; j < n; ++j) {
                int num = nums[j];
                
                // 3. Register newly discovered distinct elements
                if (!numMask[num]) {
                    numMask[num] = true;
                    ++uniqueCnt;
                }

                // 4. Accumulate the squared distinct count for the current subarray
                sum += uniqueCnt * uniqueCnt;
            }
        }
        
        return sum;
    }
}
