namespace Algorithms.Tests.Sorting;

public abstract class SortingTest
{
    public static List<object?[]> Collections =>
    [
        [new IComparable[] {2, 1}],
        [new IComparable[] { 1, 8, 100, 88, -5, 20 }],
        [new IComparable[] { 8, 100, -5 }],
        [new IComparable[] { 0 }],
        [new IComparable[] { 1000000 }],
        [new IComparable[] { 0.1 }],
        [new IComparable[] { 0.3, 0.5, 50.0, -1.0, -10.0, 8000000.0 }],
        [new IComparable[] { -1, 0, 1 }],
        [new IComparable[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }],
        [new IComparable[] { 50, 60, 70, 80 }],
        [new IComparable[] { 8289, 8289, 8289, 8289, 8289, 8289 }],
        [new IComparable[] { 8289, 8289 }],
        [Array.Empty<IComparable>()]
    ];
}