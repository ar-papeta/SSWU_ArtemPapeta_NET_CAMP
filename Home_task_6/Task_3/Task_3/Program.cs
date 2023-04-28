// See https://aka.ms/new-console-template for more information
using Task_3;

string text = "Sasha was walking along the highway and eating dried fruit\tCan\ti\ttake\tdried\tfruit";
foreach (var word in text.UniqueWords())
{
    Console.WriteLine(word);
}


