
public class Solution
{
    int[] link;
    int find(int x)
    {
        while (x != link[x]) x = link[x];
        return x;
    }
    bool same(int x, int y)
    {
        return find(x) == find(y);
    }
    void unite(int x, int y)
    {
        x = find(x);
        y = find(y);
        link[y] = link[x];
    }
    void dsu(int n)
    {
        link = new int[n];
        for (int i = 0; i < n; i++)
        {
            link[i] = i;
        }
    }
    public int MaxStability(int n, int[][] edges, int k)
    {
        int cnt = 0 ;
        dsu(n);
        int ans = int.MaxValue;
        for (int i = 0; i < edges.Length; i++)
            if (edges[i][3] == 1)
            {
                if (same(edges[i][0], edges[i][1])) return -1;
                ans = Math.Min(ans, edges[i][2]);
                cnt++;
                unite(edges[i][0], edges[i][1]);
            }
        Array.Sort(edges, (a, b) => b[2].CompareTo(a[2]));
        for (int i = 0; i < edges.Length; i++)
            if (edges[i][3] == 0)
            {
                if (same(edges[i][0], edges[i][1])) continue;
                if( k > 0 && ( n - 1 - cnt <= k ))   
                    edges[i][2] *= 2 ;
                cnt++;
                ans = Math.Min(edges[i][2],ans);
                unite(edges[i][0], edges[i][1]);
            }
        return cnt == n - 1 ? ans : -1;
    }
}
