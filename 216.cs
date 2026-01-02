public class Solution {
        IList<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> CombinationSum3(int k, int n) {
        BackTracking(k,n,0,new List<int>(),1);
        return result;
    }

    public void BackTracking(int k,int target, int sum, List<int> items,int index){
        if(sum==target && items.Count()==k){
            result.Add(new List<int>(items));
            return;
        }
        if(items.Count()>k) return;
        if (sum > target) return;
        for(int i=index;i<10;i++){
            if(i>target) break;
           
            items.Add(i);
            BackTracking(k, target,sum+i,items,i+1);
            items.RemoveAt(items.Count()-1);
        }
    }
}
