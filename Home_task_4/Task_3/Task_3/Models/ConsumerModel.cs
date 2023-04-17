using System.Diagnostics.Metrics;

namespace Task_3.Models;

internal class ConsumerModel
{
    public int FlatNumber { get; set; }
    public string Street { get; set; }
    public string Lastname { get; set; }
    public double InitialCounterReading { get; set; }
    public double FinalCounterReading { get; set; }
    public List<CounterReading> CounterReadings { get; set; } = new();
}