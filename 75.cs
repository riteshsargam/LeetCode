public class Solution {
    public void SortColors(int[] nums) {
        // Initialize frequency Array.
        int[] freq = new int[3];

        // Counting Frequencies of Colors.
        foreach (int color in nums) freq[color]++;

        // Soring numbers based on their frequiencies.
        int i = 0, j = 0;
        while (i < freq.Length) {
            int len = freq[i] + j;
            while (j < len) nums[j++] = i;
            i++;
        }
    }
}
