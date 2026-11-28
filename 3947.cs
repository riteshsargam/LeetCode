public class Solution {
    public int MaximumSaleItems(int[][] items, int budget) {
        Array.Sort(items, (a, b) => a[1].CompareTo(b[1]));
        int mx = 0;
        foreach (var item in items) {
            mx = Math.Max(mx, item[0]);
        }
        int[] freq = new int[mx + 1];
        foreach (var item in items) {
            freq[item[0]]++;
        }
        for (int i = 1; i <= mx; i++) {
            if (freq[i] > 0) {
                for (int j = i * 2; j <= mx; j += i) {
                    freq[i] += freq[j];
                }
            }
        }

        int mn = items[0][1];
        int ans = 0;
        foreach (var item in items) {
            int factor = item[0], price = item[1];
            if (price - mn > mn) {
                break;
            }
            int cnt = freq[factor] - 1;
            int take = Math.Min(cnt, budget / price);
            ans += take * 2;
            budget -= take * price;
        }
        ans += budget / mn;
        return ans;
    }
}
