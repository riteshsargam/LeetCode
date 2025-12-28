public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        var testHashSet = new HashSet<string>();
var finalHashSet = new HashSet<string>();
var fAns = new List<string>();
if (s.Length <= 10) return fAns;

var sb = new StringBuilder();

for (int i = 0; i < 10; i++)
{
    sb.Append(s[i]);
}

testHashSet.Add(sb.ToString());

for (int r = 10; r < s.Length; r++)
{
    sb.Append(s[r]);
    sb.Remove(0, 1);
    if (!testHashSet.Add(sb.ToString()))
    {
        finalHashSet.Add(sb.ToString());
    }
}

foreach (string str in finalHashSet)
{
    fAns.Add(str);
}

return fAns;
    }
}
