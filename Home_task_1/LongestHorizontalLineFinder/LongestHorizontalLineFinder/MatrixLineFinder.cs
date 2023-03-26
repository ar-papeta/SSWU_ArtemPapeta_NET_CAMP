
namespace LongestHorizontalLineFinder;

internal class MatrixLineFinder
{
    public int N { get; set; }
    public int M { get; set; }

    private readonly int[,] _matrix;

    private MatrixColorLineInfoModel _lineInfo = new();

    public MatrixLineFinder(int n, int m)
    {
        N = n;
        M = m;
        _matrix = new int[n,m];
    }
    public MatrixLineFinder(int[,] matrix)
    {
        _matrix = matrix;
        N = _matrix.GetLength(0);
        M = _matrix.GetLength(1);
    }

    public void RandomFill()
    {
        Random random = new();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                _matrix[i, j] = random.Next(0, 17);
            }
        }
    }

    public void Proceed()
    {
        int sameColorLineLen = 1;
        for (int i = 0; i < N; i++)
        {
            for (int j = 1; j < M; j++)
            {
                if (_matrix[i,j] == _matrix[i, j - 1])
                {
                    sameColorLineLen++;
                }
                else
                {
                    sameColorLineLen = 1;
                }
                if (sameColorLineLen > _lineInfo.Length)
                {
                    _lineInfo.Length = sameColorLineLen;
                    _lineInfo.StartPoint = (i, j - sameColorLineLen);
                    _lineInfo.EndPoint = (i, j);
                    _lineInfo.Color = _matrix[i, j];
                    _lineInfo.MatrixLineIndex = i;
                }
            }
        }
    }
    public void PrintInfoToConsole()
    {
        Console.WriteLine(this);
        
        Console.WriteLine(_lineInfo);

        Console.WriteLine("------------------------------------");
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
