public class Solution
{
    public int[] LexicographicallySmallestArray(int[] nums, int limit)
    {
        var n = nums.Length;
        var sortedIndexes = new int[n];
        for (var i = 0; i < n; ++i)
            sortedIndexes[i] = i;

        Array.Sort(sortedIndexes, (a, b) => nums[a].CompareTo(nums[b]));

        // create unions

        var unionOffsets = new List<int> { 0 };
        var unionIndexes = new int[n];

        for (var i = 1; i < n; ++i)
        {
            if (nums[sortedIndexes[i]] - nums[sortedIndexes[i - 1]] > limit)
                unionOffsets.Add(i);
            unionIndexes[sortedIndexes[i]] = unionOffsets.Count - 1;
        }

        // restore the result by taking elements from unions

        var result = new int[n];
        for (var i = 0; i < n; ++i)
        {
            var unionIndex = unionIndexes[i];
            var unionOffset = unionOffsets[unionIndex];
            result[i] = nums[sortedIndexes[unionOffset]];
            unionOffsets[unionIndex]++;
        }

        return result;
    }
}
