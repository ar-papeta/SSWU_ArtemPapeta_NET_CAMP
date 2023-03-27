using Tensor;

Tensor<int> tensor = new(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, }, 3, 3);

tensor.TryAddItems(7);

tensor.TryAddItems(new int[] { 8, 9});

for (int i = 0; i < tensor.ItemsCount; i++)
{
    Console.WriteLine(tensor[i]);
}

tensor[0] = 123;
tensor[1, 1] = -1233; 
tensor[2, 2] = -12;

for (int i = 0; i < tensor.ItemsCount; i++)
{
    Console.WriteLine(tensor[i]);
}

