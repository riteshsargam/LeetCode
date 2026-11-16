public class Solution {
    public string DigitSum(string s, int k) => s.Length <= k
        ? s
        : DigitSum(string.Concat(s.Chunk(k).Select(m => m.Sum(n => char.GetNumericValue(n)).ToString())), k);
}
