public class Solution {
    public char FindKthBit(int n, int k) {
        return FindKthBit(k-1) ? '1' : '0';
    }
    public bool FindKthBit(int k) {
        if (k == 0)
            return false; // 0
        if (k == 1)
            return true; // 1
        var mask = 0; // the pivot
        var temp = k;
        while (temp > 0){
            temp /= 2;
            mask = mask * 2 + 1;
        }
        if (k == mask) // if k is the pivot '1'
            return true;
        mask /= 2;
        return !FindKthBit(mask - (k - mask));
        // reverse position is at mask - (k - mask)
        // inverted bit by "!"
    }
}
