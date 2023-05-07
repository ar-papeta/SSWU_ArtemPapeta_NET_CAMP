using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Models;

namespace Task_1.View;

public class ConsoleView : IView
{
    public event Func<(string name, TrafficLightState state)[]> PrintInfoNotify = null!;

    public void PrintInfo(int time)
    {
        var info = PrintInfoNotify?.Invoke();
        ShowFullReport(info, time);
    }

    public static (PeriodStatesTimeSpanModel p1, PeriodStatesTimeSpanModel p2, int i) SetConfigParamsMenu()
    {
        PeriodStatesTimeSpanModel model1 = new PeriodStatesTimeSpanModel();
        PeriodStatesTimeSpanModel model2 = new PeriodStatesTimeSpanModel();
        Console.WriteLine("Green first in sec: ");
        model1.GreenSpan = TimeSpan.FromSeconds(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Green blinking first in sec: ");
        model1.GreenBlinkingSpan = TimeSpan.FromSeconds(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Yellow first in sec");
        model1.YellowSpan = TimeSpan.FromSeconds(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Green second in sec: ");
        model2.GreenSpan = TimeSpan.FromSeconds(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Green blinking second in sec: ");
        model2.GreenBlinkingSpan = TimeSpan.FromSeconds(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Yellow second in sec");
        model2.YellowSpan = TimeSpan.FromSeconds(Convert.ToInt32(Console.ReadLine()));
        Console.WriteLine("Simulation duration in sec:");
        int period = Convert.ToInt32(Console.ReadLine());

        return (model1, model2, period);
    }

    public void ShowFullReport((string name, TrafficLightState state)[] dataList , int i)
    {
        Console.WriteLine($"T = {i} sec");
        Console.Write(StrFormat(), "Traffic light");
        foreach (var item in dataList)
        {
            Console.Write(StrFormat(), item.name);
        }

        Console.Write(StrFormat(), "\nColor");
        foreach (var item in dataList)
        {
            Console.Write(StrFormat(), item.state.ToString());
        }
        Console.WriteLine('\n');

    }

    private static string StrFormat()
    {
        return string.Format("{{0, -{0}}}\t", "Traffic light".Length);
    }
}
