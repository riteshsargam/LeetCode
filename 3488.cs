public class Solution {
    public IList<int> SolveQueries(int[] nums, int[] queries) {
        (int m, int n) = (nums.Length, queries.Length);
        Dictionary<int, List<int>> indices = new();
        for (int i = 0; i < m; i++)
        {
            if (!indices.TryAdd(nums[i], [i]))
            {
                indices[nums[i]].Add(i);
            }
        }

        int[] output = new int[n];

        List<int> values;
        for (int i = 0; i < n; i++)
        {
            int query = queries[i];
            values = indices[nums[query]];
            int count = values.Count;
            if (count == 1)
            {
                output[i] = -1;
                continue;
            }

            (int l, int r, int pivot) = (0, count - 1, -1);
            while (l <= r)
            {
                pivot = l + (r - l) / 2;
                if (values[pivot] == query)
                {
                    break;
                }
                else if (query < values[pivot])
                {
                    r = pivot - 1;
                }
                else
                {
                    l = pivot + 1;
                }
            }

            (int previous, int next) = 
            (values[(pivot - 1 + count) % count], values[(pivot + 1) % count]);
            output[i] = Math.Min(
                Math.Min(
                    Math.Abs(query - next),
                    Math.Abs(next - query + m) % m),
                Math.Min(
                    Math.Abs((query - previous + m) % m),
                    Math.Abs((previous - query + m) % m))
            );
        }

        return output;
    }
}
