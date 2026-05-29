public class Solution {
    public int MinElement(int[] nums) {
        int min = int.MaxValue;
        foreach (int num in nums)
        {
            (int temp, int sum) = (num, 0);
            while (temp != 0)
            {
                sum += temp % 10;
                temp /= 10;
            }

            min = Math.Min(min, sum);
        }

        return min;
    }
}
