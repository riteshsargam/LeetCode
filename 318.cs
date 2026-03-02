public class Solution {
    public int MaxProduct(string[] words) {
        int n = words.Length;
int[] masks = new int[n];
int[] lens = new int[n];

for (int i = 0; i < n; i++)
{
    int mask = 0;
    foreach (char c in words[i])
    {
        mask |= (1 << (c - 'a'));
    }
    masks[i] = mask;
    lens[i] = words[i].Length;
}

int max = 0;
for (int i = 0; i < n; i++)
{
    for (int j = i + 1; j < n; j++)
    {
        if ((masks[i] & masks[j]) == 0)
        {
            max = Math.Max(max, lens[i] * lens[j]);
        }
    }
}

return max;
    }
}
