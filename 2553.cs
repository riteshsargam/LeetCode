public class Solution {
    public int[] SeparateDigits(int[] nums) {
        return (string.Join(null, nums).ToCharArray()).Select(item => item - '0').ToArray();
    }
}
