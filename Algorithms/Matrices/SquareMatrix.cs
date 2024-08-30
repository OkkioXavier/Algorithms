namespace Algorithms.Matrices;

public class SquareMatrix
{
    private readonly int[,] _matrix;

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
    }

    // Indexer declaration
    public int this[int row, int column]
    {
        get => _matrix[row, column];
        set => _matrix[row, column] = value;
    }

    enum Direction
    {
        Left,
        Right,
        Up,
        Down
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
    /// Rotates the matrix in place by iteratively rotating each ring formed by the outermost columns and rows
    /// </summary>
    public void Rotate90InPlace()
    {
        var offsetVert = 0;
        var offsetHor = 0;

        while (offsetHor * 2 < _matrix.GetLength(0))
        {
            var lastElement = _matrix[offsetVert, offsetHor];
            var column = offsetHor + 1; // Because we set lastElement to the first element above, so we want to place it at the second position
            var row = offsetVert;
            var direction = Direction.Right;
            var rightMost = _matrix.GetLength(0) - offsetHor - 1;
            var bottomMost = _matrix.GetLength(0) - offsetVert - 1;

            var length = _matrix.GetLength(0) - offsetHor * 2;
            var elementsInMatrix = length * length;
            var elementsInInnerMatrix = (length - 2) * (length - 2);
            var elementsAroundEdge = elementsInMatrix - elementsInInnerMatrix;
            var swapsToMoveEachElementToCorrectPosition = length - 1;
            var requiredSwaps = swapsToMoveEachElementToCorrectPosition * elementsAroundEdge;
            
            var swaps = 0;
            
            while (swaps < requiredSwaps)
            {
                (lastElement, _matrix[row, column]) = (_matrix[row, column], lastElement);

                switch (direction)
                {
                    case Direction.Left:
                        if (column > offsetHor)
                        {
                            column--;
                        }
                        else
                        {
                            direction = Direction.Up;
                            row--;
                        }

                        break;
                    case Direction.Right:
                        if (column < rightMost)
                        {
                            column++;
                        }
                        else
                        {
                            direction = Direction.Down;
                            row++;
                        }

                        break;
                    case Direction.Up:
                        if (row > offsetVert)
                        {
                            row--;
                        }
                        else
                        {
                            direction = Direction.Right;
                            column++;
                            lastElement = _matrix[offsetVert, offsetHor];
                        }

                        break;
                    case Direction.Down:
                        if (row < bottomMost)
                        {
                            row++;
                        }
                        else
                        {
                            direction = Direction.Left;
                            column--;
                        }

                        break;
                }

                swaps++;
            }

            offsetHor++;
            offsetVert++;
        }
    }
}