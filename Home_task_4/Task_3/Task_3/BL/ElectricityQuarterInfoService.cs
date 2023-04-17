using Task_3.Models;

namespace Task_3.BL;

internal class ElectricityQuarterInfoService
{
    private const double CostKW = 3.1415;
    private const double EPS = 0.0000001;
    private readonly ElectricityQuarterInfoModel _model;
    public ElectricityQuarterInfoService(ElectricityQuarterInfoModel model)
    {
        _model = model;
    }

    public ElectricityQuarterInfoModel GetModel() => _model;

    public string FindBiggestDebtLastname()
    {
        return _model.Consumers.MaxBy(x => x.FinalCounterReading - x.InitialCounterReading)!.Lastname;
    }

    public int[] FlatsNoWithoutConsamption()
    {
        return _model.Consumers.Where(x => Math.Abs(x.FinalCounterReading - x.InitialCounterReading) < EPS).Select(x => x.FlatNumber).ToArray();
    }

    public double ExpenseAmount(double initial, double final)
    {
        return (final - initial) * CostKW;
    }

    public int DaysAfterLastReading()
    {
        return _model.Consumers.Min(x => x.CounterReadings.Min(t => DateTime.Now - t.Date)).Days;
    }

}
