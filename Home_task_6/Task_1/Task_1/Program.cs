// See https://aka.ms/new-console-template for more information
using Task_1;


int[,] ints = { {1,3,4,10,11 }, {2,5,9,12,19 }, {6,8,13,18,20 }, { 7,14,17,21,24}, {15,16,22,23,25 } };

MatrixIterator matrix = new(ints);

ints[0,0] = 77777; //HAS NO EFFECT FOR matrix class array !!!

//Print original matrix
Console.WriteLine("Print original matrix");
for (int i = 0; i < ints.GetLength(0); i++)
{
    for(int j = 0; j < ints.GetLength(0); j++)
    {
        Console.Write(matrix[i, j] + "\t");
    }
    Console.WriteLine(  );
}
Console.WriteLine("\n");
int counter = 1;

//Print enumerated matrix
Console.WriteLine("Print enumerated matrix");
foreach (var item in matrix)
{
    if(ints.GetLength(0) < counter)
    {
        counter = 1;
        Console.WriteLine();
    }
    counter++;
    Console.Write(item + "\t");
}


//RANDOM FILL CASE
Console.WriteLine("\n\n\n-------------------");
Console.WriteLine("RANDOM FILL CASE");

MatrixIterator matrix2 = new(7);
matrix2.FillRandom(0, 99);
//Print original matrix
Console.WriteLine("Print original matrix");
for (int i = 0; i < matrix2.GetSize(); i++)
{
    for (int j = 0; j < matrix2.GetSize(); j++)
    {
        Console.Write(matrix2[i, j] + "\t");
    }
    Console.WriteLine();
}
Console.WriteLine("\n");

int counter2 = 1;

//Print enumerated matrix
Console.WriteLine("Print enumerated matrix");
foreach (var item in matrix2)
{
    if (matrix2.GetSize() < counter2)
    {
        counter2 = 1;
        Console.WriteLine();
    }
    counter2++;
    Console.Write(item + "\t");
}