
namespace Task_1;


internal enum PumpState
{
    Off,
    On
}

internal class Pump
{
    public double Rate { get; private set; }
    public PumpState State { get; private set; }

    public Pump(double rate)
    {
        State = PumpState.Off;
        Rate = rate;
    }

    public void OnPump() => State = PumpState.On;
    public void OffPump() => State = PumpState.Off;

    public double WaterPumping()
    {
        OnPump();
        var waterCount = Rate;
        OffPump();

        return waterCount;
    }

    public override string ToString()
    {
        return $"Pump with {Rate} rate";
    }
}
