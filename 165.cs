public class Solution {
    public int CompareVersion(string version1, string version2) {
        string[] v1 = version1.Split('.');
        string[] v2 = version2.Split('.');
        
        int n1 = v1.Length;
        int n2 = v2.Length;
        int n = Math.Max(n1, n2);
        
        for (int i = 0; i < n; i++) {
            int num1 = (i < n1) ? int.Parse(v1[i]) : 0;
            int num2 = (i < n2) ? int.Parse(v2[i]) : 0;
            
            if (num1 < num2) {
                return -1;
            } else if (num1 > num2) {
                return 1;
            }
        }
        
        return 0;
    }
}
