public class Solution {
    public int MaxDistance(int[] colors) {
        int max = 0, length = colors.Length;
        for(int i = 0; i < length; i++){
            if(colors[0] != colors[i])
                max = Math.Max(max, i);
            if(colors[length-1] != colors[i])
                max = Math.Max(max, length-i-1);
        }
        return max;
    }
}
