
using System.Globalization;
using System.Reflection;
using Task_3.Models;

namespace Task_3;

internal static class ElectricityQuarterInfoParser
{
    public static ElectricityQuarterInfoModel ParseModelFromText(string rawText)
    {
        var model = new ElectricityQuarterInfoModel();
        var lines = rawText.Split('\n');

        var (quarter, consumersCount) = FirstLineParse(lines[0]);
        model.Quarter = quarter;
        model.ConsumersCount = consumersCount;

        ParseModelConsumers(ref model, consumersCount, lines.Skip(1).ToArray());

        return model;
    }
    public static ElectricityQuarterInfoModel ParseModelFromFile(string path)
    {
        return ParseModelFromText(File.ReadAllText(path));
    }

    private static (int, int) FirstLineParse(string firstLine)
    {
        var firstLineInfo = firstLine.Split('\t');
        if(firstLineInfo.Length != 2) 
        {
            throw new Exception("First line parse error");
        }

        return (Convert.ToInt32(firstLineInfo[0]), Convert.ToInt32(firstLineInfo[1]));
    }

    private static void ParseModelConsumers(ref ElectricityQuarterInfoModel model, int count, string[] lines)
    {
        for (int i = 0; i < count; i++)
        {          
            var parts = lines[i].Split('\t');

            if(parts.Length != 11)
            {
                throw new Exception("invalid consumer line");
            }
            ConsumerModel consumerModel = new();

            consumerModel.FlatNumber = Convert.ToInt32(parts[0]);
            consumerModel.Street = parts[1];
            consumerModel.Lastname = parts[2];
            consumerModel.InitialCounterReading = double.Parse(parts[3], CultureInfo.InvariantCulture);
            consumerModel.FinalCounterReading = double.Parse(parts[4], CultureInfo.InvariantCulture);
            consumerModel.CounterReadings = new()
            {
                new(){ Reading = double.Parse(parts[6], CultureInfo.InvariantCulture), Date = Convert.ToDateTime(parts[5])},
                new(){ Reading = double.Parse(parts[8], CultureInfo.InvariantCulture), Date = Convert.ToDateTime(parts[7])},
                new(){ Reading = double.Parse(parts[10], CultureInfo.InvariantCulture), Date = Convert.ToDateTime(parts[9])},

            };
            model.Consumers.Add(consumerModel);
        }
    }
    
}
