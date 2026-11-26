public class Solution {
    public bool CanAliceWin(int n) {
        int take = 10, k = 0;
        while (n >= take) {
            n -= take;
            take--;
            k++;
        }
        return k % 2 == 1;
    }
}
