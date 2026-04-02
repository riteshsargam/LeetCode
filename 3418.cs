public class Solution {
    public int MaximumAmount(int[][] coins) {
        int m=coins.Length,n=coins[0].Length;
        int NEG=int.MinValue/2;

        int[][] dp=new int[n][];
        for(int i=0;i<n;i++) dp[i]=new int[]{NEG,NEG,NEG};

        for(int k=0;k<3;k++)
            dp[0][k]=k>0?Math.Max(coins[0][0],0):coins[0][0];

        for(int j=1;j<n;j++)
            for(int k=2;k>=0;k--){
                dp[j][k]=Math.Max(dp[j][k], dp[j-1][k]+coins[0][j]);
                if(k>0) dp[j][k]=Math.Max(dp[j][k], dp[j-1][k-1]);
            }

        for(int i=1;i<m;i++){
            int[][] ndp=new int[n][];
            for(int j=0;j<n;j++) ndp[j]=new int[]{NEG,NEG,NEG};

            for(int j=0;j<n;j++)
                for(int k=2;k>=0;k--){
                    if(dp[j][k]!=NEG)
                        ndp[j][k]=Math.Max(ndp[j][k], dp[j][k]+coins[i][j]);
                    if(k>0 && dp[j][k-1]!=NEG)
                        ndp[j][k]=Math.Max(ndp[j][k], dp[j][k-1]);
                    if(j>0){
                        if(ndp[j-1][k]!=NEG)
                            ndp[j][k]=Math.Max(ndp[j][k], ndp[j-1][k]+coins[i][j]);
                        if(k>0 && ndp[j-1][k-1]!=NEG)
                            ndp[j][k]=Math.Max(ndp[j][k], ndp[j-1][k-1]);
                    }
                }
            dp=ndp;
        }

        return dp[n-1][2];
    }
}
