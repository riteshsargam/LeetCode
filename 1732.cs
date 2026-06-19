public class Solution {
    public int LargestAltitude(int[] gain) {
        int cur = 0;
        int maxnum = 0;
        foreach(int i in gain){
            cur += i;
            maxnum = Math.Max(maxnum, cur);
        }
        return maxnum;
    }
}
