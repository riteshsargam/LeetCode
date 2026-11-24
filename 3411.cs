public class Solution {
    private long Gcd(long a, long b) {
        while (b != 0L) {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;public class Solution
{
    static int[] divisors = InitDivisors(max: 10);

    public int MaxLength(int[] nums)
    {
        var left = 0;
        var hasDivisors = 0;
        var result = Math.Min(nums.Length, 2);

        for (var right = 0; right < nums.Length; right++)
        {
            var newDivisors = divisors[nums[right]];

            while ((newDivisors & hasDivisors) != 0)
                hasDivisors ^= divisors[nums[left++]];

            result = Math.Max(result, right - left + 1);
            hasDivisors |= newDivisors;
        }

        return result;
    }

    static int[] InitDivisors(int max)
    {
        var divisors = new int[max + 1];

        for (var i = 2; i <= max; i += 1)
        for (var j = i; j <= max; j += i)
        {
            // 'j' is divisible by 'i'
            divisors[j] |= 1 << i;
        }

        return divisors;
    }
}
    }

    private long Lcm(long a, long b) {
        return (a / Gcd(a, b)) * b;
    }

    public int MaxLength(int[] nums) {
        int n = nums.Length;
        int maxLen = 0;
        for (int i = 0; i < n; i++) {
            long currentProd = 1L;
            long currentGcd = nums[i];
            long currentLcm = nums[i];

            for (int j = i; j < n; j++) {
                long val = nums[j];
                if (currentProd > 1000000000000L / val) {
                    currentProd = 2000000000000L;
                } else {
                    currentProd *= val;
                }

                if (j > i) {
                    currentGcd = Gcd(currentGcd, val);
                    currentLcm = Lcm(currentLcm, val);
                }

                if (currentProd == currentLcm * currentGcd) {
                    if (j - i + 1 > maxLen) {
                        maxLen = j - i + 1;
                    }
                }
            }
        }
        return maxLen;
    }
}
