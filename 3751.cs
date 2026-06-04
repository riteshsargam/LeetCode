public class Solution {
    public int TotalWaviness(int num1, int num2) {
        int res = 0;

        for (int i = num1; i <= num2; i++) {
            var temp = i.ToString();
            int waviness = 0; 
            for (int j = 1; j < temp.Length - 1; j++) {
                if (temp[j - 1] < temp[j] && temp[j] > temp[j + 1]) {
                    waviness++;
                }

                if (temp[j - 1] > temp[j] && temp[j] < temp[j + 1]) {
                    waviness++;
                }
            }
            res += waviness;
        }
        return res;
    }
}
