public class Solution {
    public int Divide(int dividend, int divisor) {
        if (dividend == int.MinValue && divisor == -1) 
        {
            return int.MaxValue;
        }

        long quotient = 0;
        bool isNegative = (dividend < 0) ^ (divisor < 0);
        
        long absDividend = Math.Abs((long)dividend);
        long absDivisor = Math.Abs((long)divisor);

        while (absDividend >= absDivisor) {
            long tempDivisor = absDivisor;
            long multiple = 1;
            
            while ((tempDivisor << 1) <= absDividend) {
                tempDivisor <<= 1;
                multiple <<= 1;
            }
            
            absDividend = Substract(absDividend, tempDivisor);
            
            quotient = Sum(quotient, multiple);
        }

        return isNegative ? (int)Substract(0, quotient) : (int)quotient;
    }

    public long Sum(long first, long second)
    {
        long carry = second;

        while(carry != 0)
        {
            long newCarry = first & carry;
            first = first ^ carry;

            carry = newCarry << 1;
        }

        return first;
    }

    public long Substract(long first, long second)
    {
        return Sum(first, Sum(~second, 1));
    }
}
