using LongestHorizontalLineFinder;
//Вітаю. Перше завдання по створенню репозиторію Ви виконали, однак не дотримались вимог до найменування підзадач.
int[,] matrix =
{
    { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
    { 1, 1, 0, 0, 1, 0, 0, 1, 2, 2 },
    { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
    { 0, 1, 2, 3, 1, 1, 1, 1, 1, 0 },

};
//MatrixLineFinder finder1 = new(10, 30);
//finder1.RandomFill();
//finder1.Proceed();
//finder1.PrintInfoToConsole();

MatrixLineFinder finder2 = new(matrix);
finder2.Proceed();
finder2.PrintInfoToConsole();

