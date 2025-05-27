namespace Algorithms.Sorting;

public static class MergeSortExtensions
{
    public static IComparable[] MergeSort(this IComparable[] array)
    {
        var count = array.Length;
        
        if (count <= 1)
        {
            return array;
        }
        
        var mid = count / 2;
        var lItems = MergeSort(array[..mid]);
        var rItems = MergeSort(array[mid..]);

        var buffer = new IComparable[array.Length];

        var left = 0;
        var right = 0;
        var index = 0;

        while (left < lItems.Length || right < rItems.Length)
        {
            if (right == rItems.Length
                || left < lItems.Length && lItems[left].CompareTo(rItems[right]) < 0)
            {
                buffer[index] = lItems[left];
                left++;
            }
            else
            {
                buffer[index] = rItems[right];
                right++;
            }

            index++;
        }

        return buffer;
    }
}