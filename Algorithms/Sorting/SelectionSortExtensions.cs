namespace Algorithms.Sorting;

public static class SelectionSortExtensions
{
    /// <summary>
    /// Sorts a list in ascending order in-place using selection sort
    /// </summary>
    /// <param name="items"></param>
    /// <typeparam name="T"></typeparam>
    public static void SelectionSort<T>(this IList<T> items) where T : IComparable
    {
        var count = items.Count;

        for (var start = 0; start < count; start++)
        {
            var indexOfMin = start;
            var minValue = items[start];

            for (var index = start; index < count; index++)
            {
                if (items[index].CompareTo(minValue) < 0)
                {
                    indexOfMin = index;
                    minValue = items[index];
                }
            }

            var temp = items[start];
            items[start] = minValue;
            items[indexOfMin] = temp;
        }
    }
}