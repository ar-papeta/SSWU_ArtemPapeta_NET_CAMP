
namespace Task_1;

internal class WaterTower
{
    private Pump _pump;
    private double _currentWaterLevel;
    private double _maxWaterLevel;

    public WaterTower(Pump pump, double maxWaterLevel)
    {
        _pump = pump;
        _maxWaterLevel = maxWaterLevel; 
    }

    public void WaterPumping()
    {
        while(_currentWaterLevel < _maxWaterLevel)
        {
            _currentWaterLevel += _pump.WaterPumping();
        }
    }

    public void GiveWater(double count)
    {
        _currentWaterLevel -= count;
    }

    public override string ToString()
    {
        return $"Current water level {_currentWaterLevel}/{_maxWaterLevel}";
    }
}
