
namespace Task_1;

internal class WaterTower
{
    private Pump _pump;
    private double _currentWaterLevel;
    private double _maxWaterLevel;
    private double _minWaterLevel = 0;  //Minimum level for turn on pump if level is lower

    public WaterTower(Pump pump, double maxWaterLevel)
    {
        _pump = pump;
        _maxWaterLevel = maxWaterLevel; 

    }

    public void WaterPumpingUp()
    {
        while(_currentWaterLevel < _maxWaterLevel)
        {
            _currentWaterLevel += _pump.WaterPumpingUp();
        }

    }

    public void GiveWater(double amount)
    {
        _currentWaterLevel -= amount;
    }

    public override string ToString()
    {
        return $"Current water level {_currentWaterLevel}/{_maxWaterLevel}";
    }
}
