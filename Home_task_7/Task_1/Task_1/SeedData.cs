using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Models;
using Task_1.Services;
using Task_1.View;

namespace Task_1;

public static class SeedData
{
    public static TrafficLightsManagerService Manager = new(
        new()
        {
            GreenSpan = TimeSpan.FromSeconds(3),
            GreenBlinkingSpan = TimeSpan.FromSeconds(1),
            YellowSpan = TimeSpan.FromSeconds(1),
        },
        new()
        {
            GreenSpan = TimeSpan.FromSeconds(3),
            GreenBlinkingSpan = TimeSpan.FromSeconds(1),
            YellowSpan = TimeSpan.FromSeconds(1),
        }
        );

    public static TrafficLights NorthSouthTrafficLight = new() { Name = "North South" };
    public static TrafficLights SouthNorthTrafficLight = new() { Name = "South North" };
    public static TrafficLights WestEastTrafficLight = new () { Name = "West East" };
    public static TrafficLights EastWestTrafficLight = new () { Name = "East West" };

    public static IView View = new ConsoleView();   
}
