using Task_2;
// 1 Задача Ромбик мав би бути напрямлений до башти в стрілці від помпи. Симулятор має композиційно вежу та користувача. Він створює ці об'єкти.
Console.WriteLine("Enter string");
string? userInput = Console.ReadLine();

Console.WriteLine("Enter substring");
string? subString = Console.ReadLine();

Console.WriteLine($"\nSecond index of \"{subString}\" is {userInput!.SecondIndexOf(subString!)}");
Console.WriteLine($"Count words start with capital letter is {userInput!.FirstCapitalLetterWordCount()}");
userInput = userInput!.SwapDoubleLettersTo(subString!);
Console.WriteLine($"New string with swaped double letters to \"{subString}\": \n{userInput!}");

