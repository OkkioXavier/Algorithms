namespace Algorithms.Sequences;

public static class EnumerableExtensions
{
    // Returns the longest in order subsequence
    // If multiple subsequences exist only one is returned
    // For example:
    // 1, 2, 3, 4, 5
    // 1, 6, 3, 4, 5
    // ANS: 1, 3, 4, 5
    public static IEnumerable<T> FindLongestCommonSubsequence<T>(this IEnumerable<T> sequence1, IEnumerable<T> sequence2)
    {
        var grid = new List<T>[sequence1.Count(), sequence2.Count()];
        var longest = new List<T>();

        for (var i = 0; i < sequence1.Count(); i++)
        {
            for (var j = 0; j < sequence2.Count(); j++)
            {
                grid[i, j] = [];
                var lastI = Math.Max(0, i - 1);
                var lastJ = Math.Max(0, j - 1);
                var lastInRow = grid[i, lastJ];
                var lastAbove = grid[lastI, j];
                var lastDiagonal = grid[lastI, lastJ];

                if (EqualityComparer<T>.Default.Equals(sequence1.ElementAt(i), sequence2.ElementAt(j)) &&
                    lastDiagonal.Count + 1 >= lastInRow.Count)
                {
                    if (lastAbove.Count == 0)
                    {
                        grid[i, j].Add(sequence2.ElementAt(j));
                    }
                    else
                    {
                        grid[i, j].AddRange(lastDiagonal);
                        grid[i, j].Add(sequence2.ElementAt(j));
                    }
                }
                else if (lastAbove.Count >= lastInRow.Count)
                {
                    grid[i, j] = lastAbove;
                }
                else
                {
                    grid[i, j] = lastInRow;
                }

                if (grid[i, j].Count > longest.Count)
                {
                    longest = grid[i, j];
                }
            }
        }
        return longest;
    }
}