
using Task_1.Models.Sections;

namespace Task_1.Services;

public static class Validator
{
    public static void ValidateViewInfo((string name, string state)[] info)
    {
        ArgumentNullException.ThrowIfNull(info, nameof(info));
    }

    public static void ValidateSimulationTime(int time)
    {
        if(time <= 0)
        {
            throw new ArgumentException($"Simulation time can not be less then 1: actual is {time}");
        }
    }

    public static void ValidateName(string? name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
    }

    public static void ValidateLightsTimings(TimeSpan from, TimeSpan to)
    {
        if(from >= to)
        {
            throw new ArgumentException($"Argument from {from} can not be greater or equal then argument to {to}");
        }
    }
    public static void ValidateSection(Section section)
    {
        ArgumentNullException.ThrowIfNull(section, nameof(section));
    }
    public static void ValidateGreenSectionsList(List<GreenSection>? sections)
    {
        ArgumentNullException.ThrowIfNull(sections, nameof(sections));
    }
}
