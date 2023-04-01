﻿
namespace Task_1;

internal class WaterTower
{
    private Pump _pump;
    private double _currentWaterLevel;
    private double _maxWaterLevel;
    private double _minWaterLevel = 0;  //Minimum level for turn on pump if level is lower

    public double CurrentWaterLevel
    {
        get
        {
            return _currentWaterLevel;
        }
        set
        {
            if (value <= 0)
            {
                StartWaterPumpingUp();
                value = 0;
            }
            _currentWaterLevel = value;
        }
    }

    public WaterTower(Pump pump, double maxWaterLevel)
    {
        _pump = pump;
        _maxWaterLevel = maxWaterLevel; 

    }

    public void StartWaterPumpingUp()
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
