public class Solution {
    private readonly int[][] directions = [[-1, 0], [1, 0], [0, -1], [0, 1]]; // Up, Down, Left, Right
    private readonly int[][] connections = [[2, 3], [0, 1], [1, 2], [1, 3], [0, 2], [0, 3]];

    private int M, N;

    public bool HasValidPath(int[][] grid) {
        M = grid.Length; 
        N = grid[0].Length;
        return FindPath(0, 0, grid);
    }

    private bool FindPath(int r, int c, int[][] grid) {
        if (r == M - 1 && c == N - 1) return true;

        int pipeType = grid[r][c];
        grid[r][c] = 7; // Mark as visited

        foreach (int dirIdx in connections[pipeType - 1]) {
            int nr = r + directions[dirIdx][0];
            int nc = c + directions[dirIdx][1];

            if (nr < 0 || nr >= M || nc < 0 || nc >= N || grid[nr][nc] == 7) 
                continue;

            int nextPipe = grid[nr][nc] - 1;
            int neededEntry = dirIdx ^ 1;

            if (connections[nextPipe][0] == neededEntry || connections[nextPipe][1] == neededEntry) {
                if (FindPath(nr, nc, grid)) return true;
            }
        }
        return false;
    }
}
