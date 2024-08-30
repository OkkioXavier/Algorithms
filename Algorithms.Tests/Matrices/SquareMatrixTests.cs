using Algorithms.Matrices;
using FluentAssertions;

namespace Algorithms.Tests.Matrices;

public class SquareMatrixTests
{
    public static IEnumerable<object?[]> Cases =>
        new List<object?[]>
        {
            new object[] { new[,] { { 1 } }, new[,] { { 1 } } },
            new object?[]
            {
                new[,]
                {
                    { 1, 2 },
                    { 3, 4 }
                },
                new[,]
                {
                    { 3, 1 },
                    { 4, 2 }
                }
            },
            new object?[]
            {
                new[,]
                {
                    { 1, 2, 3 },
                    { 4, 5, 6 },
                    { 7, 8, 9 }
                },
                new[,]
                {
                    { 7, 4, 1 },
                    { 8, 5, 2 },
                    { 9, 6, 3 }
                }
            },
            new object?[]
            {
                new[,]
                {
                    { 1, 2, 3, 4 },
                    { 5, 6, 7, 8 },
                    { 9, 10, 11, 12 },
                    { 13, 14, 15, 16 }
                },
                new[,]
                {
                    { 13, 9, 5, 1 },
                    { 14, 10, 6, 2 },
                    { 15, 11, 7, 3 },
                    { 16, 12, 8, 4 }
                }
            },
            new object?[]
            {
                new[,]
                {
                    { 1, 2, 3, 4, 5 },
                    { 6, 7, 8, 9, 10 },
                    { 11, 12, 13, 14, 15 },
                    { 16, 17, 18, 19, 20 },
                    { 21, 22, 23, 24, 25 },
                },
                new[,]
                {
                    { 21, 16, 11, 6, 1 },
                    { 22, 17, 12, 7, 2 },
                    { 23, 18, 13, 8, 3 },
                    { 24, 19, 14, 9, 4 },
                    { 25, 20, 15, 10, 5 },
                }
            }
        };

    [Theory]
    [MemberData(nameof(Cases))]
    public void MatrixIsRotatedCorrectly(int[,] array, int[,] expectation)
    {
        var matrix = new SquareMatrix(array);

        matrix.Rotate();

        for (var i = 0; i < expectation.GetLength(0); i++)
        {
            for (var j = 0; j < expectation.GetLength(1); j++)
            {
                matrix[i, j].Should().Be(expectation[i, j]);
            }
        }
    }
}