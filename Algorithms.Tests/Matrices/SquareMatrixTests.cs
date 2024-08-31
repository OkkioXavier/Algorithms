using Algorithms.Matrices;
using FluentAssertions;

namespace Algorithms.Tests.Matrices;

public class SquareMatrixTests
{    public static IEnumerable<object?[]> ReverseCases => new List<object?[]>
    {
        new object?[]
        {
            new [,]
            {
                {1, 2},
                {3, 4},
            },
            new [,]
            {
                {2, 1},
                {4, 3},
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
                { 5, 4, 3, 2, 1 },
                { 10, 9, 8 , 7, 6 },
                { 15, 14, 13, 12, 11 },
                { 20, 19, 18, 17, 16 },
                { 25, 24, 23, 22, 21 },
            }
        }
    };
    public static IEnumerable<object?[]> TransposeCases => new List<object?[]>
    {
        new object?[]
        {
            new [,]
            {
                {1, 2},
                {3, 4},
            },
            new [,]
            {
                {1, 3},
                {2, 4},
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
                { 1, 6, 11, 16, 21 },
                { 2, 7, 12, 17, 22 },
                { 3, 8, 13, 18, 23 },
                { 4, 9, 14, 19, 24 },
                { 5, 10, 15, 20, 25 },
            }
        }
    };
    
    public static IEnumerable<object?[]> RotationCases =>
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
    [MemberData(nameof(RotationCases))]
    public void Rotate90RotatesCorrectly(int[,] array, int[,] expectation)
    {
        var matrix = new SquareMatrix(array);

        var result = matrix.Rotate90();
        
        AssertMatrix(result, expectation);
    }

    [Theory]
    [MemberData(nameof(RotationCases))]
    public void Rotate90InPlaceRotatesCorrectly(int[,] array, int[,] expectation)
    {
        var matrix = new SquareMatrix(array);

        matrix.Rotate90InPlace();

        AssertMatrix(matrix, expectation);
    }

    [Theory]
    [MemberData(nameof(TransposeCases))]
    public void TransposeWorks(int [,] array, int [,] expectation)
    {
        var matrix = new SquareMatrix(array);

        matrix.TransposeInPlace();
        
        AssertMatrix(matrix, expectation);
    }
    
    [Theory]
    [MemberData(nameof(ReverseCases))]
    public void ReverseWorks(int [,] array, int [,] expectation)
    {
        var matrix = new SquareMatrix(array);

        matrix.ReverseInPlace();
        
        AssertMatrix(matrix, expectation);
    }

    [Theory]
    [MemberData(nameof(RotationCases))]
    public void RotationIsEquivalentToTransposePlusReverse(int[,] array, int[,] expectation)
    {
        var array2 = new int[array.GetLength(0),array.GetLength(1)];

        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
            {
                array2[i, j] = array[i, j];
            }
        }

        var matrix1 = new SquareMatrix(array);
        var matrix2 = new SquareMatrix(array2);
        
        matrix1.Rotate90InPlace();
        matrix2.TransposeInPlace();
        matrix2.ReverseInPlace();
        
        AssertMatrix(matrix1, expectation);
        AssertMatrix(matrix2, expectation);
    }

    private static void AssertMatrix(SquareMatrix matrix, int[,] expectation)
    {
        for (var i = 0; i < expectation.GetLength(0); i++)
        {
            for (var j = 0; j < expectation.GetLength(1); j++)
            {
                matrix[i, j].Should().Be(expectation[i, j]);
            }
        }
    }
}