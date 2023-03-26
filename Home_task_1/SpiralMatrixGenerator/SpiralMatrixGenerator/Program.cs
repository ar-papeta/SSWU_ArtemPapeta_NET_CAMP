using SpiralMatrixGenerator;

MatrixGenerator generator1 = new(6, 9, Direction.CCW);
generator1.Generate();
Console.WriteLine(generator1);

Console.WriteLine("------------------------------------");

MatrixGenerator generator2 = new(6, 8, Direction.CW);
generator2.Generate();
Console.WriteLine(generator2);

Console.WriteLine("------------------------------------");

MatrixGenerator generator3 = new(6, 4, Direction.CCW);
generator3.Generate();
Console.WriteLine(generator3);

Console.WriteLine("------------------------------------");

MatrixGenerator generator4 = new(5, 4, Direction.CW);
generator4.Generate();
Console.WriteLine(generator4);

Console.WriteLine("------------------------------------");

MatrixGenerator generator5 = new(5, 5, Direction.CCW);
generator5.Generate();
Console.WriteLine(generator5);
