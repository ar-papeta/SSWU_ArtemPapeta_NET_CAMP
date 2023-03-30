
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
        if(rate <= 0)
        {
            throw new Exception($"Unreal rate for {rate} pump");
        }
        Rate = rate;
    }

    public void OnPump() => State = PumpState.On;
    public void OffPump() => State = PumpState.Off;

    public double WaterPumpingUp()
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
