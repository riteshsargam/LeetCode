public class Solution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        var result = new List<string>();
        foreach (var query in queries)
        {
            foreach (var word in dictionary)
            {
                int diffCount = 0;
                for (int i = 0; i < query.Length && diffCount <= 2; ++i)
                    if (query[i] != word[i])
                        diffCount++;

                if (diffCount <= 2)
                {
                    result.Add(query);
                    break;
                }
            }
        }
        return result;
    }
}
