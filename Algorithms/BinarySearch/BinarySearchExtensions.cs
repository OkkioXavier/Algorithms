namespace Algorithms.BinarySearch;

public static class BinarySearchExtensions
{
    /// <summary>
    /// Searches for an element in a ordered enumerable
    /// </summary>
    /// <param name="sortedItems"></param>
    /// <param name="target">The element to find in sortedItems</param>
    /// <param name="isDescending"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>The index of the element in the enumerable</returns>
    public static int BinarySearch<T>(this IOrderedEnumerable<T> sortedItems, T target, bool isDescending = false) where T : IComparable
    {
        var count = sortedItems.Count();
        
        if (count == 0)
        {
            return -1;
        }

        var left = 0;
        var right = count -1;

        while (left <= right)
        {
            var middle = (left + right) / 2;
            var difference = sortedItems.ElementAt(middle).CompareTo(target);

            if (difference == 0)
            {
                return middle;
            }
            else if (difference > 0)
            {
                right = isDescending ? right : middle - 1;
                left = isDescending ? middle + 1 : left;
            }
            else
            {
                left = isDescending ? left : middle + 1;
                right = isDescending ? middle - 1 : right;
            }
        }
        
        return -1;
    }
}
