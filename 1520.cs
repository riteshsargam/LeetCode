public class Solution {
    class Seg {
        public int left;
        public int right;

        public Seg(int left = -1, int right = -1) {
            this.left = left;
            this.right = right;
        }
    }

    public IList<string> MaxNumOfSubstrings(string s) {
        Seg[] seg = new Seg[26];

        for (int i = 0; i < 26; i++) {
            seg[i] = new Seg();
        }

        // Preprocess the left and right endpoints.
        for (int i = 0; i < s.Length; i++) {
            int charIdx = s[i] - 'a';

            if (seg[charIdx].left == -1) {
                seg[charIdx].left = seg[charIdx].right = i;
            } else {
                seg[charIdx].right = i;
            }
        }

        for (int i = 0; i < 26; i++) {
            if (seg[i].left != -1) {
                int j = seg[i].left;

                while (j <= seg[i].right) {
                    int charIdx = s[j] - 'a';

                    if (seg[i].left <= seg[charIdx].left &&
                        seg[charIdx].right <= seg[i].right) {
                    } else {
                        seg[i].left = Math.Min(seg[i].left, seg[charIdx].left);
                        seg[i].right =
                            Math.Max(seg[i].right, seg[charIdx].right);
                        j = seg[i].left;
                    }

                    j++;
                }
            }
        }

        // Greedily select intervals.
        Array.Sort(seg, (a, b) => {
            if (a.right == b.right) {
                return b.left.CompareTo(a.left);
            }

            return a.right.CompareTo(b.right);
        });

        IList<string> ans = new List<string>();
        int end = -1;

        foreach (Seg segment in seg) {
            int left = segment.left;
            int right = segment.right;

            if (left == -1) {
                continue;
            }

            if (end == -1 || left > end) {
                end = right;
                ans.Add(s.Substring(left, right - left + 1));
            }
        }

        return ans;
    }
}
