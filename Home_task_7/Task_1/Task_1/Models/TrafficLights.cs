using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Models.Sections;

namespace Task_1.Models;

public enum TrafficLightState
{
    Off,
    Red,
    Yellow,
    Green,
    GreenBlinking,
}
public class TrafficLights
{
   
    private TrafficLightState _state = TrafficLightState.Off;
    private List<GreenSection>? _greenSections;
    public RedSection? RedSection { get; set; }
    public YellowSection? YellowSection { get; set; }
    public string? Name { get; set; }
    
    public void SetState(TrafficLightState newState)
    {
        _state = newState;
    }

    public TrafficLightState GetCurrentState() => _state;

}
