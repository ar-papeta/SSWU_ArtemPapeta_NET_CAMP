
namespace SpiralMatrixGenerator;

internal enum Direction
{
    CW,
    CCW,
}

internal class MatrixGenerator
{
    private int[,] _matrix;
    public int N { get; set; }
    public int M { get; set; }
    public Direction Direction { get; set; }
    private int _currentNumber = 1;

    public MatrixGenerator(int n, int m, Direction direction)
    {
        N = n;
        M = m;  
        Direction = direction;
        _matrix = new int[N, M];
    }

    public void Generate()
    {
        _currentNumber = 1;

        if (Direction == Direction.CW) 
        {
            ProccessCwDir(); 
        }
        else
        {
            ProccessCcwDir();
        }
    }

    private void ProccessCcwDir()
    {
        int loop = 0;
        while (loop < N && loop < M)
        {
            for (int i = loop; i < N - loop; i++)
            {
                if (_matrix[i, loop] != 0)
                {
                    break;
                }
                _matrix[i, loop] = _currentNumber++;
            }

            for (int i = loop + 1; i < M - loop; i++)
            {
                if (_matrix[N - 1 - loop, i] != 0)
                {
                    break;
                }
                _matrix[N - 1 - loop, i] = _currentNumber++;
            }

            for (int i = N - loop - 2; i >= loop; i--)
            {
                if (_matrix[i, M - loop - 1] != 0)
                {
                    break;
                }
                _matrix[i, M - loop - 1] = _currentNumber++;
            }

            for (int i = M - loop - 2; i > loop ; i--)
            {
                if (_matrix[loop, i] != 0)
                {
                    break;
                }
                _matrix[loop, i] = _currentNumber++;
            }

            loop++;
        }
    }

    
    public void ProccessCwDir()
    {
        int loop = 0;
        while(loop < N && loop < M)
        {
            for (int i = loop; i < M - loop - 1; i++)
            {
                if(_matrix[loop, i] != 0)
                {
                    break;
                }
                _matrix[loop, i] = _currentNumber++;
            }

            for (int i = loop; i < N - loop - 1; i++)
            {
                if (_matrix[i, M - loop - 1] != 0)
                {
                    break;
                }
                _matrix[i, M - loop - 1] = _currentNumber++;
            }

            for (int i = M - loop - 1; i >= loop; i--)
            {
                if (_matrix[N - 1 - loop, i] != 0)
                {
                    break;
                }
                _matrix[N - 1 - loop, i] = _currentNumber++;
            }

            for (int i = N - loop - 2; i > loop; i--)
            {
                if (_matrix[i, loop] != 0)
                {
                    break;
                }
                _matrix[i, loop] = _currentNumber++;
            }
            loop++;
        } 
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                result += $"{_matrix[i, j]}\t";
            }
            result += '\n';
        }

        return result;
    }
}
