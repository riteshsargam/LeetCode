public class Solution {
    public int SmallestNumber(int n, int t) {
        for (int x = n; ; x++) {
            int num = x;
            int product = 1;

            while (num > 0) {
                int digit = num % 10;

                if (digit == 0)
                    return x;

                product *= digit;
                num /= 10;
            }

            if (product % t == 0)
                return x;
        }
    }
}
