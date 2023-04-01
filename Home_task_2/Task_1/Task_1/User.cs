using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1;

internal class User
{
    public Guid Id { get; }
    public double WaterBalance { get; set; }
    public double CurrentConsumption { get; set; }
    public double ConsumptionRatePerSecond { get; set; }

    public User(double waterBalance)
    {
        if(waterBalance < 0)
        {
            throw new Exception("Negative balance!");
        }
        WaterBalance = waterBalance;
    }

    public User()
    {
        Id = Guid.NewGuid();
    }

    public void ConsumeWater(double amount)
    {
        CurrentConsumption += amount;
        WaterBalance -= amount;
    }

    public void ConsumeWater(TimeSpan time)
    {
        
    }

    public void StartConsumption()
    {

    }
    public void StopConsumption()
    {

    }

    public void AddToBalance(double balance)
    {
        WaterBalance += balance;
    }

    public void RemoveFromBalance(double balance)
    {
        WaterBalance -= balance;
    }

    public override string ToString()
    {
        return $"User {Id} has balance {WaterBalance} and consumption {CurrentConsumption}";
    }
}
