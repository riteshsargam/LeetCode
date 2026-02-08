public class Solution {
    public string GetHint(string secret, string guess) {
          var counts = new int[10];
  foreach (var ch in secret)
      counts[ch - '0']++;

  int a = 0, b = 0;
  for (int i = 0; i < guess.Length; i++)
  {
      if (guess[i] == secret[i])
      {
          a++;
          if (counts[guess[i] - '0'] > 0)
              counts[guess[i] - '0']--;
          else
              b--;
          continue;
      }

      if (counts[guess[i] - '0'] > 0)
      {
          b++;
          counts[guess[i] - '0']--;
      }
  }

  return $"{a}A{b}B";
    }
}
