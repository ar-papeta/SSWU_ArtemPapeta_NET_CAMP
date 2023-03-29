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

    public User()
    {
        Id = Guid.NewGuid();
    }

    public void ConsumeWater(double amount)
    {
        CurrentConsumption += amount;
        WaterBalance -= amount;
    }

    public override string ToString()
    {
        return $"User {Id} has balance {WaterBalance} and consumption {CurrentConsumption}";
    }
}
