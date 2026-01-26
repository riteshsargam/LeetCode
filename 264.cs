public class Solution {
    public int NthUglyNumber(int n) {
        HashSet<long> seen = new HashSet<long>();
        PriorityQueue<long, long> heap = new PriorityQueue<long, long>();
        
        // Initial ugly number is 1
        heap.Enqueue(1, 1);
        seen.Add(1);
        
        long[] primes = { 2, 3, 5 };
        long ugly = 1;
        
        for (int i = 0; i < n; i++) {
            // Extract the smallest ugly number
            ugly = heap.Dequeue();
            
            // Generate new ugly numbers and add them to the heap
            foreach (long prime in primes) {
                long newUgly = ugly * prime;
                if (!seen.Contains(newUgly)) {
                    seen.Add(newUgly);
                    heap.Enqueue(newUgly, newUgly);
                }
            }
        }
        
        return (int)ugly;
    }
}
