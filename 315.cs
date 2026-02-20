public class Solution {
     public IList<int> CountSmaller(int[] nums)
   {
       List<int> result = new List<int>();
       List<int> sorted = new List<int>();

       for (int i = nums.Length - 1; i >= 0; i--)
       {
           int index = Insert(sorted, nums[i]);
           result.Add(index);
           sorted.Insert(index, nums[i]);
       }

       result.Reverse();
       return result;
   }

   private int Insert(List<int> arr, int num)
   {
       int left = 0, right = arr.Count - 1;
       while (left <= right)
       {
           int mid = left + (right - left) / 2;
           if (arr[mid] < num)
           {
               left = mid + 1;
           }
           else
           {
               right = mid - 1;
           }
       }
       return left;
   }
}
