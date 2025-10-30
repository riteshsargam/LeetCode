using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);  // Step 1: Sort to enable pruning and duplicate skipping
        List<IList<int>> result = new List<IList<int>>();
        Backtrack(candidates, target, 0, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] candidates, int target, int start, List<int> current, List<IList<int>> result) {
        if (target == 0) {  // Valid combination found
            result.Add(new List<int>(current));
            return;
        }
        if (target < 0) return;  // Prune: exceeded target

        for (int i = start; i < candidates.Length; i++) {
            // Step 3: Skip duplicates at the same level
            if (i > start && candidates[i] == candidates[i - 1]) continue;
            
            // Prune: If current > remaining target, break (since sorted)
            if (candidates[i] > target) break;
            
            // Include the current candidate
            current.Add(candidates[i]);
            // Recurse with updated target and next start index (i+1 to avoid reusing the same element)
            Backtrack(candidates, target - candidates[i], i + 1, current, result);
            // Backtrack: Remove the last added element
            current.RemoveAt(current.Count - 1);
        }
    }
}
