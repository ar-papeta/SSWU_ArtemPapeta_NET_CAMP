using Microsoft.VisualBasic;
using Task_3.BL;
using Task_3.Models;

namespace Task_3.View;

internal class ElectricityQuarterInfoViewConsole : IElectricityQuarterInfoView
{
    private readonly ElectricityQuarterInfoService _service;
    public ElectricityQuarterInfoViewConsole(ElectricityQuarterInfoService service)
    {
        _service = service;
    }

    public void ShowDaysAfterLastReading()
    {
        Console.WriteLine($"Days after last reading {_service.DaysAfterLastReading()}\n\n");
    }

    public void ShowFlatsNoWithoutConsamption()
    {
        Console.Write("Flats # without consamption: ");
        foreach (var item in _service.FlatsNoWithoutConsamption())
        {
            Console.Write(item);
        }
        Console.WriteLine("\n\n");
    }

    public void ShowBiggestDebtLastname()
    {
        Console.Write($"Biggest debt lastname: {_service.FindBiggestDebtLastname()} \n\n\n");
    }

    public void ShowSingleConsumerReport(ConsumerModel consumer)
    {
        Console.WriteLine($"Flat # {consumer.FlatNumber}");
        Console.WriteLine($"Street: {consumer.Street}");
        Console.WriteLine($"Lastname: {consumer.Lastname}");
        Console.WriteLine($"Readings:");
        foreach (var item in consumer.CounterReadings)
        {
            Console.WriteLine($"\t{item.Date:dd.MM.yy}\t{item.Reading}");
        }
        Console.WriteLine($"Expense amount: {_service.ExpenseAmount(consumer.InitialCounterReading, consumer.FinalCounterReading)}$");
        Console.WriteLine('\n');

    }

    public void ShowFullReport()
    {
        var flatNoColumn = new List<string>() { "#", "-"};
        var lastnameColumn = new List<string>() { "Lastname", "--------" };
        var initialConsColumn = new List<string>() { "Init reading", "------------" };
        var finalConsColumn = new List<string>() { "Final reading", "-------------" };
        var firstMonthColumn = new List<string>() { GetMonthNameFromQuarter(_service.GetModel().Quarter, 1), "----------------" };
        var secondMonthColumn = new List<string>() { GetMonthNameFromQuarter(_service.GetModel().Quarter, 2), "----------------" };
        var thirdMonthColumn = new List<string>() { GetMonthNameFromQuarter(_service.GetModel().Quarter, 3), "----------------" };
        var expenseAmountColumn = new List<string>() { "Expense", "-------" };

        foreach (var item in _service.GetModel().Consumers)
        {
            flatNoColumn.Add(item.FlatNumber.ToString());
            lastnameColumn.Add(item.Lastname);
            initialConsColumn.Add(item.InitialCounterReading.ToString());
            finalConsColumn.Add(item.FinalCounterReading.ToString());
            firstMonthColumn.Add($"{item.CounterReadings[0].Date:dd.MM.yy}  {item.CounterReadings[0].Reading}");
            secondMonthColumn.Add($"{item.CounterReadings[1].Date:dd.MM.yy}  {item.CounterReadings[1].Reading}");
            thirdMonthColumn.Add($"{item.CounterReadings[2].Date:dd.MM.yy}  {item.CounterReadings[2].Reading}");
            expenseAmountColumn.Add(_service.ExpenseAmount(item.InitialCounterReading, item.FinalCounterReading).ToString());
        }
       

        for (int i = 0; i< flatNoColumn.Count; i++)
        {
            Console.Write(StrFormat(flatNoColumn), flatNoColumn[i]);
            Console.Write(StrFormat(lastnameColumn), lastnameColumn[i]);
            Console.Write(StrFormat(initialConsColumn), initialConsColumn[i]);
            Console.Write(StrFormat(finalConsColumn), finalConsColumn[i]);
            Console.Write(StrFormat(firstMonthColumn), firstMonthColumn[i]);
            Console.Write(StrFormat(secondMonthColumn), secondMonthColumn[i]);
            Console.Write(StrFormat(thirdMonthColumn), thirdMonthColumn[i]);
            Console.Write(StrFormat(expenseAmountColumn), expenseAmountColumn[i]);
            Console.WriteLine();
        }
        Console.WriteLine('\n');
    }

    private static string StrFormat(List<string> column)
    {
        return string.Format("{{0, -{0}}}\t", column.Max(s => s.Length));
    }

    private static string GetMonthNameFromQuarter(int quarter, int monthNo)
    {
        if(quarter == 1) 
        {
            if (monthNo == 1)
                return "Januarry";
            else if (monthNo == 2)
                return "February";
            else if (monthNo == 3)
                return "March";
        }
        if (quarter == 2)
        {
            if (monthNo == 1)
                return "April";
            else if (monthNo == 2)
                return "May";
            else if (monthNo == 3)
                return "June";
        }
        if (quarter == 3)
        {
            if (monthNo == 1)
                return "July";
            else if (monthNo == 2)
                return "August";
            else if (monthNo == 3)
                return "September";
        }
        if (quarter == 4)
        {
            if (monthNo == 1)
                return "October";
            else if (monthNo == 2)
                return "November";
            else if (monthNo == 3)
                return "December";
        }

        return string.Empty;
    }
}
