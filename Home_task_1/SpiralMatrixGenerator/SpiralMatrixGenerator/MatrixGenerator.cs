
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
    public int M {
        get
        {
            return ;
        }
        set
        { 
            if(value < 0)
                throw new ArgumentOutOfRangeException("value");
            M = value;
        } }
    public Direction Direction { get; set; }

    public MatrixGenerator(int n, int m, Direction direction)
    {
        N = n;
        M = m;  
        Direction = direction;
        _matrix = new int[N, M];
    }

    public void Create()
    {
        SetNLoop();  
    }


        
    
    int currentNumber = 1;
    public void SetNLoop()
    {
        var outCounter = 0;
        int loop = 0;
        while(outCounter < 4 && loop < N && loop < M)
        {
            for (int i = loop; i < M - loop - 1; i++)
            {
                if(_matrix[loop, i] != 0)
                {
                    outCounter++;
                    break;
                }
                _matrix[loop, i] = currentNumber++;
            }

            for (int i = loop; i < N - loop - 1; i++)
            {
                if (_matrix[i, M - loop - 1] != 0)
                {
                    outCounter++;
                    break;
                }
                _matrix[i, M - loop - 1] = currentNumber++;
            }

            for (int i = M - loop - 1; i >= loop; i--)
            {
                if (_matrix[N - 1 - loop, i] != 0)
                {
                    outCounter++;
                    break;
                }
                _matrix[N - 1 - loop, i] = currentNumber++;
            }

            for (int i = N - loop - 2; i > loop; i--)
            {
                if (_matrix[i, loop] != 0)
                {
                    outCounter++;
                    break;
                }
                _matrix[i, loop] = currentNumber++;
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
