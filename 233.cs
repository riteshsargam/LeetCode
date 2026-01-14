public class Solution {
    public int CountDigitOne(int n) {
        if (n <= 0) return 0;
        long m = 1;
        long count = 0;

        while (m <= n) {
            long high = n / (m * 10);
            long cur = (n / m) % 10;
            long low = n % m;

            if (cur == 0) {
                count += high * m;
            } else if (cur == 1) {
                count += high * m + (low + 1);
            } else {
                count += (high + 1) * m;
            }

            m *= 10;
        }

        return (int)count;
    }
}
