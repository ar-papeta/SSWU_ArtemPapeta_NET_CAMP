using Task_2.Models;
using Task_2.ShippingVisitor;

// Create instances of different products
var apple = new Food { Weight = 0.2, IsUrgent = true, Dimensions = new ProductDimensions { Height = 10.0, Length = 5.0, Width = 2.0 } };
var tv = new Electronics { Weight = 15.0, Price = 1000.0, Dimensions = new ProductDimensions { Height = 30.0, Length = 20.0, Width = 10.0 } };
var shirt = new Clothing { Weight = 5.3, Dimensions = new ProductDimensions { Height = 5.0, Length = 5.0, Width = 1.0 } };


var visitor = new ShippingCostVisitor();

Console.WriteLine($"Shipping cost on start (withot products): {visitor.ShippingCost}");

apple.Accept(visitor);
Console.WriteLine($"Shipping cost after add food: {visitor.ShippingCost}");

tv.Accept(visitor);
Console.WriteLine($"Shipping cost after add electronics: {visitor.ShippingCost}");

shirt.Accept(visitor);
Console.WriteLine($"Shipping cost after add clothing: {visitor.ShippingCost}");
