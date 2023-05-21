using Task1.Models.OrderModels;

IDish dish1 = new Dish() { Name = "Pizza", CookingTimeInSec = 5, Color = ConsoleColor.Cyan };
IDish dish2 = new Dish() { Name = "Salmon", CookingTimeInSec = 10, Color = ConsoleColor.DarkYellow };
IDish dish3 = new Dish() { Name = "Salmon", CookingTimeInSec = 10, Color = ConsoleColor.DarkYellow };

Order order = new Order();
Console.WriteLine("Start _________");

var t1 = dish1.CookAsync();
var t2 = dish2.CookAsync();

Task.WaitAll(t1, t2);


Console.WriteLine("Stop ___________");
Console.ReadLine();
