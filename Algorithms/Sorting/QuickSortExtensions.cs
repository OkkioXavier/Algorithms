namespace Algorithms.Sorting;

public static class QuickSortExtensions
{
    public static void QuickSort<T>(this IList<T> items) where T : IComparable
    {
        items.QuickSort(0, items.Count - 1);
    }

    static void QuickSort<T>(this IList<T> items, int start, int end) where T : IComparable
    {
        if (start >= end) return;
        
        var partitionIndex = Partition(items, start, end);

        QuickSort(items, start, partitionIndex);
        QuickSort(items, partitionIndex + 1, end);
    }

    private static int Partition<T>(IList<T> items, int start, int end) where T : IComparable
    {
        var middle = (start + end) / 2;
        var pivot = items[middle];

        var low = start - 1;
        var high = end + 1;
        
        while (true)
        {
            while (pivot.CompareTo(items[++low]) > 0) ;

            while (pivot.CompareTo(items[--high]) < 0) ;

            if (low >= high)
            {
                return high;
            }
            
            (items[low], items[high]) = (items[high], items[low]);
        }
    }
}