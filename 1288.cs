public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        int n = intervals.Length;
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            int a = intervals[i][0];
            int b = intervals[i][1];
            bool isCovered = false;

            for (int j = 0; j < n; j++)
            {
                if (i == j) continue;

                int c = intervals[j][0];
                int d = intervals[j][1];

                if (c <= a && d >= b)
                {
                    isCovered = true;
                    break;
                }
            }

            if (!isCovered)
            {
                count++;
            }
        }

        return count;
    }
}
