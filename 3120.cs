public class Solution {
    public int NumberOfSpecialChars(string word) {
        HashSet<char> chars = new();
        int count = 0;
        foreach (char c in word)
        {
            char other = c >= 65 && c <= 90
            ? (char)(c - 65 + 97)
            : (char)(c - 97 + 65);
            if (chars.Contains(c) && chars.Contains(other))
            {
                continue;
            }
            
            if (chars.Contains(other))
            {
                count++;
            }

            _ = chars.Add(c);
        }

        return count;
    }
}

// Or You can use a bool array as an optimization
public class SolutionStatic {
    public int NumberOfSpecialChars(string word) {
        bool[] chars = new bool[26 * 2];
        int count = 0;
        foreach (char c in word)
        {
            (int cIndex, int otherIndex) = c >= 65 && c <= 90
            ? (26 + c - 65, c - 65)
            : (c - 97, 26 + c - 97);
            
            if (chars[cIndex] && chars[otherIndex])
            {
                continue;
            }
            
            if (chars[otherIndex])
            {
                count++;
            }

            chars[cIndex] = true;
        }

        return count;
    }
}
