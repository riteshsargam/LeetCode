public class Solution {
    public int NumberOfSubstrings(string s) {
        const int kTotChr = 3;
        const int kNoIdx = -1;
        const int kCntOffset = 1;
        const char kChrSetFirst = 'a';
        
        int[] latestIdxPerChr = { kNoIdx, kNoIdx, kNoIdx };
        int substrTot_ = 0;
        
        for (int idx_ = 0; idx_ < s.Length; ++idx_) {
            latestIdxPerChr[s[idx_] - kChrSetFirst] = idx_;
            
            // Manual min calculation for optimal performance
            int minIdx = latestIdxPerChr[0];
            if (latestIdxPerChr[1] < minIdx) minIdx = latestIdxPerChr[1];
            if (latestIdxPerChr[2] < minIdx) minIdx = latestIdxPerChr[2];
            
            substrTot_ += kCntOffset + minIdx;
        }
        
        return substrTot_;
    }
}
