public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        int minDistance = int.MaxValue;
        Dictionary<int, int> dict = [];
        for (int i = 0; i < nums.Length; ++i)
        {
            if (dict.TryGetValue(nums[i], out int firstOccurence))
            {
                minDistance = Math.Min(i - firstOccurence, minDistance);
                int reversedNum = ReverseNumber(nums[i]);
                dict[reversedNum] = i;
            }
            else
            {
                int reversedNum = ReverseNumber(nums[i]);
                dict[reversedNum] = i;
            }
        }
        return minDistance == int.MaxValue ? -1 : minDistance;
    }

    private int ReverseNumber(int num)
    {
        int reversed = 0;
        while(num > 0) {
            reversed = reversed * 10 + num % 10;
            num /= 10;
        }
        return reversed;
    }
}
