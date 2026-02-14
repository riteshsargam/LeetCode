public class Solution {
     public bool IsAdditiveNumber(string num)
 {
     return IsAdditiveNumberInner(num, i: 0, previous: new List<int>());
 }

 private static bool IsAdditiveNumberInner(string num, int i, List<int> previous)
 {
     if (i == num.Length)
     {
         return previous.Count > 2;
     }

     if (num[i] == '0')
     {
         if (previous.Count >= 2 && ((previous[^1] + previous[^2]) != 0))
         {
             return false;
         }

         previous.Add(0);
         var result = IsAdditiveNumberInner(num, i + 1, previous);
         previous.RemoveAt(previous.Count - 1);

         return result;
     }

     for (var n = 0; i < num.Length; ++i, n *= 10)
     {
         n += (num[i] - '0');

         var firstTwo = previous.Count < 2;
         var sumOfPreviousTwo = (previous.Count >= 2) && (n == (previous[^1] + previous[^2]));
         if (!firstTwo && !sumOfPreviousTwo)
         {
             continue;
         }

         previous.Add(n);
         if (IsAdditiveNumberInner(num, i + 1, previous))
         {
             return true;
         }
         previous.RemoveAt(previous.Count - 1);
     }

     return false;
 }
}
