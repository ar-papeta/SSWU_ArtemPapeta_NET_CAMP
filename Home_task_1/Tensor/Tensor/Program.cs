using Tensor;

/*
        Use case 1.  
    Create a tensor with initial data and dimensions length
 */
Tensor<int> tensor = new(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, }, 3, 3);

//You can add single value to tensor
tensor.TryAddItems(7);

//Or matrix
tensor.TryAddItems(new int[] { 8, 9});

//You can iterate tensor object by index
for (int i = 0; i < tensor.ItemsCount; i++)
{
    Console.WriteLine(tensor[i]);
}

//Or change value by its index
tensor[0] = 123;
tensor[1, 1] = -1233; 
tensor[2, 2] = -12;

for (int i = 0; i < tensor.ItemsCount; i++)
{
    Console.WriteLine(tensor[i]);
}
Console.WriteLine("---------------");

/*
        Use case 1.  
    Create a tensor with array of dimensions with its length 
 */
Tensor<int> tensor2 = new(2, 2, 2);

//Add data to tensor from any data structur with lower or similar dimention
tensor2.TryAddItems(new int[] { 1, 2, 3});
tensor2.TryAddItems(4);
tensor2.TryAddItems(new int[,] { { 5, 6 }, { 7, 8 } });

if (!tensor2.TryAddItems(1))
{
    Console.WriteLine("Can not add data in case of tensor overflowing");
}

for (int i = 0; i < tensor2.ItemsCount; i++)
{
    Console.WriteLine(tensor2[i]);
}

