using System.Collections.Generic;

public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> check = new HashSet<int>();
        foreach (int x in nums) {
            if (!check.Add(x)) return true;
        }
        return false;
    }
}
