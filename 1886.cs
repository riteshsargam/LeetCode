public class Solution {
    public bool FindRotation(int[][] mat, int[][] target) {
        for (int k = 0; k < 4; k++) {
            if (AreEqual(mat, target)) return true;
            Rotate(mat);
        }
        return false;
     }

    private void Rotate(int[][] mat) {
        int n = mat.Length;

        for (int i = 0 ; i < n ; i++) {
            for(int  j = i ; j < n ; j++) {
                int temp = mat[i][j];
                mat[i][j] = mat[j][i];
                mat[j][i] = temp;
            }
        }

        for(int i = 0 ; i < n ; i++) {
            Array.Reverse(mat[i]);
        }
    }

    private bool AreEqual(int[][] mat , int[][] target) {
        int n = mat.Length;
        // Check rows
        if (n != target.Length) return false;

        for (int i = 0; i < n; i++) {
            // Check columns
            if (mat[i].Length != target[i].Length) return false;

            for (int j = 0; j < mat[i].Length; j++) {
                if (mat[i][j] != target[i][j]) {
                    return false;
                }
            }
        }

        return true;
    }
}
