using SpiralMatrixGenerator;

MatrixGenerator generator = new(6, 9, Direction.CW);
generator.Create();
Console.WriteLine(generator);
