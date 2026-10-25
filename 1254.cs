public class Solution {
    public int ClosedIsland(int[][] grid) {
        int h = grid.Length, w = grid[0].Length;

        void DFS(int y, int x, ref bool isValid)
        {
            if (y == 0 || y == h - 1 || x == 0 || x == w - 1)
            {
                isValid = false;
            }

            grid[y][x] = 2;

            // up
            if (y - 1 >= 0 && grid[y - 1][x] == 0)
            {
                DFS(y - 1, x, ref isValid);
            }

            // right
            if (x + 1 < w && grid[y][x + 1] == 0)
            {
                DFS(y, x + 1, ref isValid);
            }

            // down
            if (y + 1 < h && grid[y + 1][x] == 0)
            {
                DFS(y + 1, x, ref isValid);
            }

            // left
            if (x - 1 >= 0 && grid[y][x - 1] == 0)
            {
                DFS(y, x - 1, ref isValid);
            }
        }

        int result = 0;
        for (int i = 0; i < h * w; i++)
        {
            int y = i / w, x = i % w;
            if (grid[y][x] > 0)
            {
                continue;
            }

            bool isValid = true;
            DFS(y, x, ref isValid);
            if (isValid)
            {
                result++;
            }
        }

        return result;
    }
}
