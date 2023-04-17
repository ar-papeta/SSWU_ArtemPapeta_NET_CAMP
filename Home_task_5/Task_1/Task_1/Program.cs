// See https://aka.ms/new-console-template for more information

using Task_1;

Tree[] trees = new Tree[7];
trees[0] = new (0, 3);
trees[1] = new (2, 3);
trees[2] = new (1, 1);
trees[3] = new (2, 1);
trees[4] = new (3, 0);
trees[5] = new (0, 0);
trees[6] = new (3, 3);

Garden garden1 = new(trees.ToList());
var hull = garden1.GardenConvexHull();


foreach (var tree in hull)
{
    Console.WriteLine($"({tree.X}, {tree.Y})");
}

Console.WriteLine($"Garden perimetr: {garden1.HullLength()}");

Garden garden2 = new(new() { new(0, 100) , new(10, 3), new(1, 33), new(123, 3) });

if(garden2 > garden1)
{
    Console.WriteLine($"Garden 2 with P={garden2.HullLength():0.00} greater then garden 1 with P={garden1.HullLength():0.00}");
}
else
{
    Console.WriteLine($"Garden 1 with P={garden1.HullLength():0.00} greater then garden 2 with P={garden2.HullLength():0.00}");
}
    