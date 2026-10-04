public class Solution {
    public bool CheckValidString(string s) {
         var lo = 0;
 var hi = 0;
 foreach (var ch in s)
 {
     lo += ch == '(' ? 1 : -1;
     hi += ch != ')' ? 1 : -1;
     if (hi < 0) return false;
     lo = Math.Max(lo, 0);
 }

 return lo == 0;
    }
}
