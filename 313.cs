public class Solution {
    public int NthSuperUglyNumber(int n, int[] primes) {
         long[] nums = new long[n]; nums[0] = 1;
 int m = primes.Length; // Array.Sort(primes); - skipped
 int[] counts = new int[m];
 // Main cycle
 for (int i = 1; i < n; i++)
 {
     long min = long.MaxValue;
     for (int j = 0; j < m; j++)
     {
         if (min > nums[counts[j]] * primes[j])
         {
             min = nums[counts[j]] * primes[j];
         }
     }
     nums[i] = min;
     for (int j = 0; j < m; j++)
     {
         if (min == nums[counts[j]] * primes[j]) counts[j]++;
     }
 }
 return (int)nums[n - 1];
    }
}
