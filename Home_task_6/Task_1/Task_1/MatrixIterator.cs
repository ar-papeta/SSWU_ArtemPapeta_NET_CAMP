
using System.Collections;

namespace Task_1;

internal class MatrixIterator : IEnumerable
{
    private readonly int[,] _values;
    public int GetSize() => _values.GetLength(0);
    public MatrixIterator(int n)
    {
        _values = new int[n,n];
    }

    public MatrixIterator(int[,] values)
    {
        _values = (values.Clone() as int[,])!;
    }

    public int this[int i, int j]
    {
        get { return _values[i,j]; }
        set { _values[i, j] = value; }
    }

    public void FillRandom(int minValue, int maxValue)
    {
        Random random = new();
        for (int i = 0; i < _values.GetLength(0); i++)
        {
            for (int j = 0; j < _values.GetLength(1); j++)
            {
                _values[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        int elementNumber = 1;
        int diagonalNumber = 0;
        int dir = 1;
        int n = _values.GetLength(0);
        while (elementNumber <= n * n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i + j) == diagonalNumber)
                    {
                        if (dir == 1) 
                        {
                            elementNumber++;
                            yield return _values[i, j];
                        }
                        else
                        {
                            elementNumber++;
                            yield return _values[j, i];
                        }
                    }
                }
            }
            diagonalNumber++;
            dir = -dir;
        }
    }
}



