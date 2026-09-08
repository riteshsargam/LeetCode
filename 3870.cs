public class Solution {
    public int CountCommas(int n) {
        int res = 0;
        for (int a = 1; a <= n; ++a) {
            if (a > 999) {
                res += 1;
            }
        }
        return res;
    }
}
