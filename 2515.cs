public class Solution {
    public int ClosestTarget(string[] words, string target, int startIndex) {
        (int min, int l) = (int.MaxValue, words.Length);
        for (int i = 0; i < l; i++)
        {
            if (words[i] != target)
            {
                continue;
            }

            min = Math.Min(min, Math.Min(
                Math.Abs(startIndex - i),
                Math.Min(
                    l - i + startIndex,
                    l - startIndex + i
                ))
            );
        }

        return min == int.MaxValue ? -1 : min;
    }
}
