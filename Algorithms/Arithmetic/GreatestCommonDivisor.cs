namespace Algorithms.Arithmetic;

public static class GreatestCommonDivisor
{
    public static long Calculate(long number1, long number2)
    {
        ArgumentOutOfRangeException.ThrowIfZero(number1);
        ArgumentOutOfRangeException.ThrowIfZero(number2);
        
        long temp = number1; 
        number1 = Math.Max(number1, number2);
        number2 = Math.Min(temp, number2);
        
        while (true)
        {
            long remainder = number1 % number2;

            if (remainder == 0)
            {
                return Math.Abs(number2);
            }

            number1 = number2;
            number2 = remainder;
        };
    }
}