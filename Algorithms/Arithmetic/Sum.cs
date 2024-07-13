using System.Numerics;

namespace Algorithms.Arithmetic;

public static class Sum
{
    public static T SumRecursive<T>(this IEnumerable<T> numbers) where T: INumber<T>
    {
        if (!numbers.Any())
        {
            return default;
        }
        
        return numbers.SumRecursive(0, numbers.Count() - 1);
    }

    private static T SumRecursive<T>(this IEnumerable<T> numbers, int start, int end) where T: INumber<T>
    {
        if (start == end)
        {
            return numbers.ElementAt(end);
        }
        
        return numbers.ElementAt(start) + SumRecursive(numbers, start + 1, end);
    }
    
}