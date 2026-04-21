
public class Solution
{
    private int[] parent;

    private int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);

        return parent[x];
    }

    private void Unite(int a, int b)
    {
        parent[Find(a)] = Find(b);
    }

    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        int n = source.Length;
        parent = new int[n];

        for (int i = 0; i < n; i++)
            parent[i] = i;

        foreach (var swap in allowedSwaps)
        {
            Unite(swap[0], swap[1]);
        }

        var groups = new Dictionary<int, Dictionary<int, int>>();

        for (int i = 0; i < n; i++)
        {
            int root = Find(i);

            if (!groups.ContainsKey(root))
                groups[root] = new Dictionary<int, int>();

            if (!groups[root].ContainsKey(source[i]))
                groups[root][source[i]] = 0;

            groups[root][source[i]]++;
        }

        int hammingDist = 0;

        for (int i = 0; i < n; i++)
        {
            int root = Find(i);
            var freq = groups[root];

            if (freq.ContainsKey(target[i]) && freq[target[i]] > 0)
            {
                freq[target[i]]--;
            }
            else
            {
                hammingDist++;
            }
        }

        return hammingDist;
    }
}
