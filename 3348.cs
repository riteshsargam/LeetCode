// My logic revolves around factorizing t and attempting to form the smallest possible number by using digits 2, 3, 5, 6, 7, 8, and 9, which correspond to prime factorizations
// And AddMin() function tries to place digits in num such that the product of the digits matches t
// I use some methods are used to handle prime factorization, digit formation and comparison

// TODO : 
// Walkthrough the code with specific inputs to show how each function works
// Focus on smaller tasks like factorizing t and building a number from factors
// Factorize t, generate the smallest number, compare with num, adjust num and return the result
// Provide a variety of inputs to highlight edge cases and ensure every results

public class Solution {
    public string SmallestNumber(string num, long t) {

        // Factorize the number t to get the prime factors 2, 3, 5, 7 and check if it's possible to create such a number
        var factors = GetFactors(t);
        var min = GetMin(factors.p2, factors.p3, factors.p5, factors.p7);

        // I check if t has prime factors other than 2, 3, 5, 7
        if (factors.r != 1)
        return "-1";

        // Compare the smallest valid number min with the input number num to check if f min is greater than or equal to num
        if (Compare(min, num.TrimStart('0', '1')) >= 0) 
        {
            if (min.Length >= num.Length) 
            {
                return min;
            } 
            else 
            {
                return new string('1', num.Length - min.Length) + min;
            }
        }

        // If min is smaller than num, I try to adjust num by placing the right digits using AddMin
        StringBuilder resbuild = new StringBuilder(num);

        if (AddMin(0, (factors.p2, factors.p3, factors.p5, factors.p7), resbuild))
        return resbuild.ToString();

        string prefix = new string('1', num.Length - min.Length + 1);

        return prefix + min;
    }

    // I use recursion to check all possibilities for the smallest valid number
    // Start at the first digit of num, if the current digit can't satisfy the factors, increment it until it does
    // Recursively check the next digit, if no solution is possible, replace the current digit with 1
    private bool AddMin(int start, (int p2, int p3, int p5, int p7) factors, StringBuilder num) {

        // If I have processed all digits, check if all factors have been satisfied
        if (start >= num.Length)
        return factors.p2 == 0 && factors.p3 == 0 && factors.p5 == 0 && factors.p7 == 0;

        int suffix = num.Length - start;

        // If the remaining factors cannot be completed with the remaining digits
        if (MinLength(factors.p2, factors.p3, factors.p5, factors.p7) > suffix) 
        {
            num[start] = '1';

            return false;
        }

        // I try to increment the current digit until the factors are satisfied
        int current = num[start] - '0';

        if (current == 0) 
        {
            var min = GetMin(factors.p2, factors.p3, factors.p5, factors.p7);
            int posMin = min.Length - 1;
            int posNum = num.Length - 1;

            // I start replacing digits from right to left with the digits in min
            while (posNum >= start) 
            {
                if (posMin >= 0) 
                {
                    num[posNum--] = min[posMin--];
                } 
                else 
                {
                    num[posNum--] = '1';
                }
            }
            return true;
        } 
        else 
        {
            // I try all possible digits from the current digit
            for (int cd = current; cd <= 9; cd++) 
            {
                int nd = cd;
                int np2 = factors.p2, np3 = factors.p3, np5 = factors.p5, np7 = factors.p7;

                // Reduce the factors based on the current digit
                while (np2 > 0 && nd % 2 == 0) 
                { 
                    np2--; nd /= 2; 
                }
                while (np3 > 0 && nd % 3 == 0) 
                { 
                    np3--; nd /= 3; 
                }
                while (np5 > 0 && nd % 5 == 0) 
                { 
                    np5--; nd /= 5; 
                }
                while (np7 > 0 && nd % 7 == 0) 
                { 
                    np7--; nd /= 7; 
                }
                // Check if it's possible with the current digit
                if (AddMin(start + 1, (np2, np3, np5, np7), num)) 
                {
                    num[start] = (char)('0' + cd);
                    
                    return true;
                }
            }
            // If no valid digit found
            num[start] = '1';

            return false;
        }
    }

    // Keep dividing t by 2, 3, 5, and 7 until it’s no longer divisible
    // The remaining number r tells us if there are other prime factors, if r ≠ 1, t cannot be built with just digits
    private (int p2, int p3, int p5, int p7, long r) GetFactors(long n) {

        int p2 = 0, p3 = 0, p5 = 0, p7 = 0;

        // I just keep dividing n by 2, 3, 5, and 7 until it is no longer divisible by these primes
        while (n % 2 == 0) 
        { 
            p2++; n /= 2; 
        }
        while (n % 3 == 0) 
        { 
            p3++; n /= 3; 
        }
        while (n % 5 == 0) 
        { 
            p5++; n /= 5; 
        }
        while (n % 7 == 0) 
        { 
            p7++; n /= 7; 
        }
        return (p2, p3, p5, p7, n);
    }

    private int MinLength(int p2, int p3, int p5, int p7) {

        // Combine the factors into the smallest possible digits like 9, 8, 6 and count the digits needed
        int n9 = p3 / 2;
        p3 %= 2;
        int n8 = p2 / 3;
        p2 %= 3;
        int n7 = p7;
        int n6 = Math.Min(p2, p3);
        p2 -= n6;
        p3 -= n6;
        int n5 = p5;
        int n4 = p2 / 2;
        p2 %= 2;
        int n3 = p3;
        int n2 = p2;

        return n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9;
    }

    // Use the factors to create the smallest possible number
    // Group factors into digits like 9 (3 × 3), 8 (2 × 2 × 2), 6 (2 × 3)
    // I build a string with the required number of each digit
    private string GetMin(int p2, int p3, int p5, int p7) {

        // Form the smallest number by taking as many of each possible digit as needed
        int n9 = p3 / 2;
        p3 %= 2;
        int n8 = p2 / 3;
        p2 %= 3;
        int n7 = p7;
        int n6 = Math.Min(p2, p3);
        p2 -= n6;
        p3 -= n6;
        int n5 = p5;
        int n4 = p2 / 2;
        p2 %= 2;
        int n3 = p3;
        int n2 = p2;

        // I return the number as a string of digits
        return
        new string('2', n2) +
        new string('3', n3) +
        new string('4', n4) +
        new string('5', n5) +
        new string('6', n6) +
        new string('7', n7) +
        new string('8', n8) +
        new string('9', n9);
    }

    // I ensure the result at least as large as num, write a simple Compare function
    // I compare the lengths of the numbers first, if the lengths are equal then compare them digit by digit
    private int Compare(string a, string b) {

        // If lengths different, the shorter string is considered smaller
        if (a.Length != b.Length) 
        return a.Length.CompareTo(b.Length);
        // If lengths are the same, compare the strings
        return string.Compare(a, b);
    }
}
