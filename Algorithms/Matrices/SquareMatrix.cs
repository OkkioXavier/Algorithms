namespace Algorithms.Matrices;

public class SquareMatrix
{
    private readonly int[,] _matrix;

    private int _sideLength;

    public SquareMatrix(int[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException("The matrix must be square");
        }

        if (matrix.Rank != 2)
        {
            throw new ArgumentException("The matrix is not 2 dimensional");
        }

        _matrix = matrix;
        _sideLength = _matrix.GetLength(0);
    }

    // Indexer declaration
    public int this[int row, int column]
    {
        get => _matrix[row, column];
        set => _matrix[row, column] = value;
    }

    // Returns a new matrix rotated by 90 degrees
    public SquareMatrix Rotate90()
    {
        var matrix = new SquareMatrix(new int[_matrix.GetLength(0), _matrix.GetLength(1)]);

        for (var i = 0; i < _matrix.GetLength(0); i++)
        {
            for (var j = 0; j < _matrix.GetLength(1); j++)
            {
                matrix[j, _matrix.GetLength(0) - i - 1] = _matrix[i, j];
            }
        }

        return matrix;
    }

    /// <summary>
    /// Rotates the matrix in place by 90 degrees
    /// This two pointer solution is _very_ fast but hard to remember
    /// A much easier approach is to transpose the matrix and then reverse it
    /// <see cref="Algorithms.Tests.Matrices.RotationIsEquivalentToTransposePlusReverse"/>
    /// </summary>
    public void Rotate90InPlace()
    {
        for (var i = 0; i < (_sideLength + 1) / 2; i++)
        {
            for (var j = 0; j < _sideLength / 2; j++)
            {
                // temp = bottom left
                var temp = _matrix[_sideLength - 1 - j, i];
                
                // bottomLeft = bottomRight
                _matrix[_sideLength - 1 - j, i] = _matrix[_sideLength - 1 - i, _sideLength - 1 - j];
                
                // bottomRight = topRight
                _matrix[_sideLength - 1 - i, _sideLength - 1 - j] = _matrix[j, _sideLength - 1 - i];
                
                // topRight = topLeft
                _matrix[j, _sideLength - 1 - i] = _matrix[i, j];
        
                // topLeft = temp
                _matrix[i, j] = temp;
            }
        }
    }

    // Flips elements across the matrix's main diagonal
    public void TransposeInPlace()
    {
        for (var i = 0; i < _sideLength; i++)
        {
            for (var j = i; j < _sideLength; j++)
            {
                (_matrix[i, j], _matrix[j, i]) = (_matrix[j, i], _matrix[i, j]);
            }
        }
    }

    // Reverses the order of the elements in each row in the match
    public void ReverseInPlace()
    {
        for (var i = 0; i < _sideLength; i++)
        {
            for (var j = 0; j < _sideLength / 2; j++)
            {
                (_matrix[i, j], _matrix[i, _sideLength - 1 - j]) = (_matrix[i, _sideLength - 1 - j], _matrix[i, j]);
            }
        }
    }
}