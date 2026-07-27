public class Solution {
    public int MaxProduct(int[] nums) {
                    int m = int.MinValue, n = int.MinValue;
            foreach (var num in nums)
            {
                if (num > n)
                    if (num >= m)
                    {
                        n = m;
                        m = num;
                    }
                    else
                        n = num;
            }

            return (m - 1) * (n - 1);
    }
}
