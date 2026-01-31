public class Solution {
     List<string> result = new List<string>();

 public IList<string> AddOperators(string num, int target)
 {
     int d0 = num[0] - '0';
     Generate(num, 1, target, 0, d0, d0, d0.ToString());
     return result;
 }

 void Generate(string num, int idx, long target, long num1 = 0, long num2 = 0, long num2_prevMult = 0, string expression = "")
 {
     if (idx == num.Length)
     {
         if (num1 + num2 == target)
             result.Add(expression);

         return;
     }

     int d = num[idx] - '0';

     Generate(num, idx + 1, target, num1 + num2, +d, d, expression + "+" + d);
     Generate(num, idx + 1, target, num1 + num2, -d, d, expression + "-" + d);
     Generate(num, idx + 1, target, num1, num2 * d, d, expression + "*" + d);

     if (num2_prevMult != 0)
     {
         long newMult = num2_prevMult * 10 + d;
         Generate(num, idx + 1, target, num1, num2 / num2_prevMult * newMult, newMult, expression + d.ToString());
     }
     // else -> num2_prevMult == 0 -> Cannot concat
 }
}
