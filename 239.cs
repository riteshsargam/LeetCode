public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        int n=nums.Length;
        int[] result= new int[n-k+1];

        //Deque stores indices
        LinkedList<int> deque= new LinkedList<int>();

        for(int i=0;i<n;i++){

            //Window ranges from [i-k+1,i], if it is out of the window, remove it from deque;
            if(deque.Count>0 && deque.First.Value<=i-k) deque.RemoveFirst();

            //Remove indices from the back if their value is less than current nums[i]
            //because they are useless now.
            while(deque.Count>0 && nums[deque.Last.Value]<nums[i]) deque.RemoveLast();

            //Add current index to the back
            deque.AddLast(i);

            //add max to the result array (when atleast k element processed, max at the front of deque)
            if(i>=k-1) result[i-k+1]=nums[deque.First.Value];
        }

        return result;
        
    }
}
