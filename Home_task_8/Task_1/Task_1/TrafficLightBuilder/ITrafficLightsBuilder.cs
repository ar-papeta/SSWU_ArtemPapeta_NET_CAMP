using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Models.Sections;

namespace Task_1.TrafficLightBuilder;

public interface ITrafficLightsBuilder : IBuilder<TrafficLights>
{
    ITrafficLightsBuilder AddRedLight(TimeSpan from, TimeSpan to);
    ITrafficLightsBuilder AddYellowGRLight(TimeSpan from, TimeSpan to);
    ITrafficLightsBuilder AddYellowRGLight(TimeSpan from, TimeSpan to);
    ITrafficLightsBuilder AddGreenBasicLight(TimeSpan from, TimeSpan to);
    ITrafficLightsBuilder AddLeftTurnGreenLight(TimeSpan from, TimeSpan to);
    ITrafficLightsBuilder AddRightTurnGreenLight(TimeSpan from, TimeSpan to);
    ITrafficLightsBuilder AddStraightOnlyGreenLight(TimeSpan from, TimeSpan to);
    ITrafficLightsBuilder WithName(string name);
    //ITrafficLightsBuilder WithGreenBlinkingTime(TimeSpan duration);
    //ITrafficLightsBuilder WithRedBlinkingTime(TimeSpan duration);
}
