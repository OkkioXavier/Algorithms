namespace Algorithms.Arrays;

public static class ArrayExtensions
{
    public static void RotateRight<T>(this Span<T> nums, int k) {
        var pivot = k % nums.Length;
        nums.ReverseInPlace();
        nums[..pivot].ReverseInPlace();
        nums[pivot..].ReverseInPlace();
    }
    
    public static void RotateLeft<T>(this Span<T> nums, int k) {
        var pivot = k % nums.Length;
        nums[..pivot].ReverseInPlace();
        nums[pivot..].ReverseInPlace();
        nums.ReverseInPlace();
    }

    public static void ReverseInPlace<T>(this Span<T> span) {
        for (var i = 0; i < span.Length / 2; i++)
        {
            (span[i], span[^(i + 1)]) = (span[^(i + 1)], span[i]);
        }
    }
}