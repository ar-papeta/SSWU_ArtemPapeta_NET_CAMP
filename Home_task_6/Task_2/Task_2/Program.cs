using Task_2;

var matrix = MatrixEnumerator.EnumerateMatrix(
    new[] { -100, 1, 2, 3, 4, 5, 6 },
    new[] { 11, 2, 23, 4, 5, 36 },
    new[] { 10, 22, 33, 44, 55, 6, 777 },
    new int[] {  },
    new[] { 1000 }

    );
foreach (var item in matrix)
{
    Console.Write($"{item}  ");
}
Console.WriteLine("\n");



