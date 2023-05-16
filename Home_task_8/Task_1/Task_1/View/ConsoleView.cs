
using Task_1.Services;

namespace Task_1.View;

public class ConsoleView : IView
{
    public event Func<(string name, string state)[]> PrintInfoNotify = null!;
    public void PrintInfo(int time)
    {
        var info = PrintInfoNotify?.Invoke();
        Validator.ValidateViewInfo(info!);
        ShowFullReport(info!, time);
    }

    public void ShowFullReport((string name, string state)[] dataList , int i)
    {
        Console.WriteLine($"T = {i} sec");
        Console.Write(StrFormat(), "Traffic light");
        foreach (var (name, _) in dataList)
        {
            Console.Write(StrFormat(), name);
        }

        Console.Write(StrFormat(), "\nColor");
        foreach (var (_, state) in dataList)
        {
            Console.Write(StrFormat(), state.ToString());
        }
        Console.WriteLine('\n');
    }

    private static string StrFormat()
    {
        return string.Format("{{0, -{0}}}\t", "Traffic light".Length);
    }
}
