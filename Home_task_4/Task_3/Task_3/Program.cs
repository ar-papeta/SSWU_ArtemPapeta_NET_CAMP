// See https://aka.ms/new-console-template for more information

using Task_3;

var column1 = new List<string>() { "12345", "123", "12345678", "1234"};
var column2 = new List<string>() { "12345", "123", "12345678", "1234" };

var maxWidth = column1.Max(s => s.Length);
var formatString = string.Format("{{0, -{0}}}|", maxWidth);
var maxWidth2 = column2.Max(s => s.Length);
var formatString2 = string.Format("{{0, -{0}}}|", maxWidth2);
int i = 0;
foreach (var s in column1)
{
    Console.Write(formatString, s);
    Console.Write(formatString, column2[i++]);
    // тут наверное остальные колонки
    Console.WriteLine();
}

var model = ElectricityQuarterInfoParser.ParseModelFromText(SeedData.FirstQuarterData);
Console.WriteLine(  );

