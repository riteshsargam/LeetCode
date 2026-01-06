public class Solution {
   public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
 {
     var buckets = new Dictionary<int, int>(); // label key -> element in bucket with label key, note we only care about 
                                               // 1 element in a bucket, if we have more than 1, we know we have found a pair, and note bucketsize = valueDiff + 1;

     var bucketSize = valueDiff + 1; // e.g. if valueDiff = 3, then a bucket is [0, 3] and this bucket contains 4 elements
                                     // and any pair of element (x1, x2) from this bucket its difference should be |x1-x2| <= valueDiff = 3;

     int min = nums.Min();
     for (int i = 0; i < nums.Length; i++)
     {
         var shift = nums[i] - min;
         var label = shift / bucketSize;

         // if there already exists a bucket with the same label, it means, this bucket contains an element
         // which its difference with the current nums[i] will be satified with the 
         // valueDiff as well as the indexDiff(because the windows size is indexDiff in order word, indexDiff previous
         // elements from index i)
         if (buckets.ContainsKey(label))
         {
             return true;
         }

         // elements from left bucket can potentially have nums that its difference with current nums[i] <= valueDiff
         if (buckets.ContainsKey(label - 1) && Math.Abs(buckets[label - 1] - nums[i]) <= valueDiff)
         {
             return true;
         }

         // elements from right bucket can potentially have nums that its difference with current nums[i] <= valueDiff
         if (buckets.ContainsKey(label + 1) && Math.Abs(buckets[label + 1] - nums[i]) <= valueDiff)
         {
             return true;
         }

         // more notes to the above three if statments: 
         // [bucket-left][bucket-label][bucket-right] are the only buckets that contain numbers that can
         // pair with current nums[i] which their difference is <= valueDiff, any other buckets will not meet this requirement
         // because the bucketSize = valueDiff + 1;

         buckets[label] = nums[i];

         // slide the windows when we reach max possible size since
         // the far left element is no longer satified with the indexDiff condition with the next element position
         if (buckets.Count == indexDiff + 1)
         {
             var farLeftShift = nums[i - indexDiff] - min;
             var farLeftLabel = farLeftShift / bucketSize;
             buckets.Remove(farLeftLabel);
         }
     }

     return false;
 }
}
