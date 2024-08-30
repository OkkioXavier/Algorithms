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

    /// <summary>
    /// Rotates the matrix recursively by rotating each ring formed by the outermost columns and rows
    /// </summary>
    public void Rotate()
    {
        var offsetVert = 0;
        var offsetHor = 0;

        while (offsetHor * 2 < _matrix.GetLength(0))
        {
            var lastOverwrite = _matrix[offsetVert, offsetHor];
            var column = offsetHor + 1; // Because we take the last overwrite above
            var row = offsetVert;
            var direction = Direction.Right;
            var length = _matrix.GetLength(0) - offsetHor * 2;
            var swaps = 0;
            
            var elementsInMatrix = length * length;
            var elementsInInnerMatrix = (length - 2) * (length - 2);
            var elementsAroundEdge = elementsInMatrix - elementsInInnerMatrix;
            var swapsToMoveEachElementToCorrectPosition = length - 1;
            var requiredSwaps = swapsToMoveEachElementToCorrectPosition * elementsAroundEdge;
            
            while (swaps < requiredSwaps)
            {
                switch (direction)
                {
                    case Direction.Left:
                        if (column >= 0 + offsetHor)
                        {
                            (lastOverwrite, _matrix[row, column]) = (_matrix[row, column], lastOverwrite);
                            column--;
                            swaps++;
                        }
                        else
                        {
                            direction = Direction.Up;
                            row--;
                            column++;
                        }
                        break;
                    case Direction.Right:
                        if (column < _matrix.GetLength(0) - offsetHor)
                        {
                            (lastOverwrite, _matrix[row, column]) = (_matrix[row, column], lastOverwrite);
                            column++;
                            swaps++;
                        }
                        else 
                        {
                            direction = Direction.Down;
                            row++;
                            column--;
                        }
                        break;
                    case Direction.Up:
                        if (row >= 0 + offsetVert)
                        {
                            (lastOverwrite, _matrix[row, column]) = (_matrix[row, column], lastOverwrite);
                            row--;
                            swaps++;
                        }
                        else 
                        {
                            direction = Direction.Right;
                            column++;
                            row++;
                            lastOverwrite = _matrix[offsetVert, offsetHor];
                        }
                        break;
                    case Direction.Down:
                        if (row  < _matrix.GetLength(0) - offsetVert)
                        {
                            (lastOverwrite, _matrix[row, column]) = (_matrix[row, column], lastOverwrite);
                            row++;
                            swaps++;
                        }
                        else
                        {
                            direction = Direction.Left;
                            column--;
                            row--;
                        }
                        break;
                }
            }
            
            offsetHor++;
            offsetVert++;
        }
    }
}