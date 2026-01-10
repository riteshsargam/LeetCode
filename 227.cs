public class Solution {
    public int Calculate(string s) {
        if (string.IsNullOrEmpty(s)) return 0;

        int result = 0;
        int lastNumber = 0;
        int currentNumber = 0;
        char operation = '+';

        for (int i = 0; i < s.Length; i++) {
            char c = s[i];

            if (char.IsDigit(c)) {
                currentNumber = currentNumber * 10 + (c - '0');
            }

            if ((!char.IsDigit(c) && c != ' ') || i == s.Length - 1) {
                if (operation == '+') {
                    result += lastNumber;
                    lastNumber = currentNumber;
                } else if (operation == '-') {
                    result += lastNumber;
                    lastNumber = -currentNumber;
                } else if (operation == '*') {
                    lastNumber = lastNumber * currentNumber;
                } else if (operation == '/') {
                    lastNumber = lastNumber / currentNumber;
                }

                operation = c;
                currentNumber = 0;
            }
        }

        result += lastNumber;
        return result;
    }
}
