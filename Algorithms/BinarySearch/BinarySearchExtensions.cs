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
        
        return sortedItems.BinarySearch(target, 0, count - 1, isDescending);
    }

    static int BinarySearch<T>(this IOrderedEnumerable<T> items, T target, int start, int end, bool isDescending) where T : IComparable
    { 
        var middle = (start + end) / 2;
        var difference = items.ElementAt(middle).CompareTo(target);

        if (difference == 0)
        {
            return middle;
        }
        else if (start == end)
        {
            return -1;
        }

        if (difference > 0)
        {
            return isDescending 
                ? items.BinarySearch(target, middle + 1, end, isDescending)  // Search Right
                : items.BinarySearch(target, start, middle - 1, isDescending); // Search Left
        }

        return isDescending 
            ? items.BinarySearch(target, start, middle - 1, isDescending) // Search Left
            : items.BinarySearch(target, middle + 1, end, isDescending); // Search Right
    }
}
