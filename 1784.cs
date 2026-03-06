public class Solution {
    public bool CheckOnesSegment(string s) {
        for(int i = 1; i < s.Length; i++) {
            if(s[i] == '1' && s[i - 1] == '0') return false;
        }
        return true;
    }
}
