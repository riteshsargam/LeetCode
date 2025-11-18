public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) 
    {
        List<IList<int>> result= new List<IList<int>>();
        Array.Sort(nums);
        Backtrack(nums, 0, new List<int>(),result);
        return result;
    }

    private void Backtrack(int[] nums, int start, List<int> current, List<IList<int>> result){
        result.Add(new List<int>(current)); // Add current subset to the result 

        for(int i=start;i<nums.Length;i++){
            if(i>start && nums[i]==nums[i-1]) continue; //Skipping Duplicates

            current.Add(nums[i]);
            Backtrack(nums,i+1,current,result);
            current.RemoveAt(current.Count-1); // Backtrack and exclude the current element added.
        }
    }
}
