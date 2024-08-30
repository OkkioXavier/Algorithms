namespace Algorithms.Patterns;

/// <summary>
/// Validates whether a sequence is balanced.
/// Balanced: (())
/// Unbalanced: (()(
/// </summary>
public class BalanceChecker
{
    public static bool Check<T>(T openSymbol, T closeSymbol, IEnumerable<T> sequence)
    {
        var stack = new Stack<T>();

        foreach (var item in sequence)
        {
            if (item?.Equals(openSymbol) == true)
            {
                stack.Push(item);
            }
            else if (item?.Equals(closeSymbol) == true)
            {
                if (stack.Count == 0 || stack.Pop()?.Equals(openSymbol) == false)
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("Contains unrecognised characters", nameof(sequence));
            }
        }

        return stack.Count == 0;
    }
}