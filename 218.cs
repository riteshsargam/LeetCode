public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        List<(int x, int h)> events = new();
        foreach (var b in buildings) {
            events.Add((b[0], -b[2])); // start
            events.Add((b[1], b[2]));  // end
        }

        events.Sort((a, b) => a.x != b.x ? a.x.CompareTo(b.x) : a.h.CompareTo(b.h));

        var result = new List<IList<int>>();
        var heights = new SortedDictionary<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        heights[0] = 1; // ground level
        int prevHeight = 0;

        foreach (var (x, h) in events) {
            if (h < 0) {
                // start of building
                if (!heights.ContainsKey(-h)) heights[-h] = 0;
                heights[-h]++;
            } else {
                // end of building
                heights[h]--;
                if (heights[h] == 0) heights.Remove(h);
            }

            int currHeight = heights.First().Key;
            if (currHeight != prevHeight) {
                result.Add(new List<int> { x, currHeight });
                prevHeight = currHeight;
            }
        }

        return result;
    }
}
