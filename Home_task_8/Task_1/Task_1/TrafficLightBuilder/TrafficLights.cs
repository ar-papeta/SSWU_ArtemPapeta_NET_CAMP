using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Models.Sections;
using Task_1.Models;
using Task_1.Services;

namespace Task_1.TrafficLightBuilder;

public class TrafficLights
{
    public enum TrafficLightTrigger
    {
        RedOn,
        RedOff,
        YellowGROn,
        YellowGROff,
        YellowRGOn,
        YellowRGOff,
        BasicGreenOn,
        BasicGreenOff,
        LeftTurnGreenOn,
        LeftTurnGreenOff,
        RightTurnGreenOn,
        RightTurnGreenOff,
        StraightOnlyGreenOn,
        StraightOnlyGreenOff,
    }

    private readonly Dictionary<TrafficLightTrigger, TimeSpan> _triggers;
    private List<GreenSection>? _greenSections;
    private RedSection? _redSection;
    private YellowSection? _yellowSection;

    public string? Name { get; set; }
    private TrafficLights() 
    {
        _triggers = new();
        _greenSections = new();
        _redSection = new();
        _yellowSection = new();
    }

    public void CheckTriggerChangeState(TimeSpan time)
    {
        var timeTriggers = _triggers.Where(x => x.Value == time);
        foreach (var trigger in timeTriggers)
        {
            ChangeState(trigger.Key);
        }
    }
    private GreenSection? GetGreenSection(SectionType type)
    {
        Validator.ValidateGreenSectionsList(_greenSections!);
        return _greenSections!.FirstOrDefault(s => s.Type == type);
    }

    private void ChangeState(TrafficLightTrigger trigger)
    {
        switch (trigger)
        { 
            case TrafficLightTrigger.BasicGreenOff:
                var dsoff = GetGreenSection(SectionType.Default);
                Validator.ValidateSection(dsoff!);
                dsoff!.State = SectionState.Off;
                break;
            case TrafficLightTrigger.RedOn:
                Validator.ValidateSection(_redSection!);
                _redSection!.State = SectionState.On;
                break;
            case TrafficLightTrigger.RedOff:
                Validator.ValidateSection(_redSection!);
                _redSection!.State = SectionState.Off;
                break;
            case TrafficLightTrigger.YellowGROn:
                Validator.ValidateSection(_yellowSection!);
                _yellowSection!.State = SectionState.On;
                
                break;
            case TrafficLightTrigger.YellowGROff:
                Validator.ValidateSection(_yellowSection!);
                _yellowSection!.State = SectionState.Off;
                break;
            case TrafficLightTrigger.YellowRGOn:
                Validator.ValidateSection(_yellowSection!);
                _yellowSection!.State = SectionState.On;
                break;
            case TrafficLightTrigger.YellowRGOff:
                Validator.ValidateSection(_yellowSection!);
                _yellowSection!.State = SectionState.Off;
                break;
            case TrafficLightTrigger.BasicGreenOn:
                var dson = GetGreenSection(SectionType.Default);
                Validator.ValidateSection(dson!);
                dson!.State = SectionState.On;
                break;
            case TrafficLightTrigger.LeftTurnGreenOn:
                var lson = GetGreenSection(SectionType.LeftTurn);
                Validator.ValidateSection(lson!);
                lson!.State = SectionState.On;
                break;
            case TrafficLightTrigger.LeftTurnGreenOff:
                var lsoff = GetGreenSection(SectionType.LeftTurn);
                Validator.ValidateSection(lsoff!);
                lsoff!.State = SectionState.Off;
                break;
            case TrafficLightTrigger.RightTurnGreenOn:
                var rson = GetGreenSection(SectionType.RightTurn);
                Validator.ValidateSection(rson!);
                rson!.State = SectionState.On;
                break;
            case TrafficLightTrigger.RightTurnGreenOff:
                var rsoff = GetGreenSection(SectionType.RightTurn);
                Validator.ValidateSection(rsoff!);
                rsoff!.State = SectionState.Off;
                break;
            case TrafficLightTrigger.StraightOnlyGreenOn:
                var sson = GetGreenSection(SectionType.StraightOnly);
                Validator.ValidateSection(sson!);
                sson!.State = SectionState.On;
                break;
            case TrafficLightTrigger.StraightOnlyGreenOff:
                var ssoff = GetGreenSection(SectionType.StraightOnly);
                Validator.ValidateSection(ssoff!);
                ssoff!.State = SectionState.Off;
                break;
        }
    }

    public IEnumerable<TimeSpan> GetTriggersTimings()
    {
        return _triggers.Select(x => x.Value);
    }

    public string GetStateStr()
    {
        var state = string.Empty;
        if(_redSection?.State == SectionState.On)
        {
            state += "Red ";
        }
        else if (_yellowSection?.State == SectionState.On)
        {
            state += "Yellow ";
        }
        else 
        {
            foreach (var gs in _greenSections!)
            {
                if(gs.State == SectionState.On)
                {
                    if(gs.Type == SectionType.Default) 
                    {
                        state += "Green ";
                    }
                    else if(gs.Type == SectionType.LeftTurn)
                    {
                        state += "< ";
                    }
                    else if (gs.Type == SectionType.RightTurn)
                    {
                        state += "> ";
                    }
                    else if (gs.Type == SectionType.StraightOnly)
                    {
                        state += "^ ";
                    }
                }
            }
        }

        return state != string.Empty ? state : "Off";
    }

    public static TrafficLightsBuilder Builder()
    {
        return new TrafficLightsBuilder();
    }

    public class TrafficLightsBuilder : ITrafficLightsBuilder
    {
        private TrafficLights _result = null!;

        public TrafficLightsBuilder() 
        {
            Reset();
        }

        public TrafficLights Build()
        {
            return _result;
        }

        public void Reset()
        {
            _result = new();
        }

        public ITrafficLightsBuilder AddGreenBasicLight(TimeSpan from, TimeSpan to)
        {
            Validator.ValidateLightsTimings(from, to);

            _result._greenSections!.Add(new GreenSection(SectionType.Default));
            _result._triggers.Add(TrafficLightTrigger.BasicGreenOn, from);
            _result._triggers.Add(TrafficLightTrigger.BasicGreenOff, to);

            return this;
        }

        public ITrafficLightsBuilder AddLeftTurnGreenLight(TimeSpan from, TimeSpan to)
        {
            Validator.ValidateLightsTimings(from, to);

            _result._greenSections!.Add(new GreenSection(SectionType.LeftTurn));
            _result._triggers.Add(TrafficLightTrigger.LeftTurnGreenOn, from);
            _result._triggers.Add(TrafficLightTrigger.LeftTurnGreenOff, to);

            return this;
        }

        public ITrafficLightsBuilder AddRedLight(TimeSpan from, TimeSpan to)
        {
            Validator.ValidateLightsTimings(from, to);

            _result._redSection = new();
            _result._triggers.Add(TrafficLightTrigger.RedOn, from);
            _result._triggers.Add(TrafficLightTrigger.RedOff, to);

            return this;
        }

        public ITrafficLightsBuilder AddRightTurnGreenLight(TimeSpan from, TimeSpan to)
        {
            Validator.ValidateLightsTimings(from, to);

            _result._greenSections!.Add(new GreenSection(SectionType.RightTurn));
            _result._triggers.Add(TrafficLightTrigger.RightTurnGreenOn, from);
            _result._triggers.Add(TrafficLightTrigger.RightTurnGreenOff, to);

            return this;
        }

        public ITrafficLightsBuilder AddStraightOnlyGreenLight(TimeSpan from, TimeSpan to)
        {
            Validator.ValidateLightsTimings(from, to);

            _result._greenSections!.Add(new GreenSection(SectionType.StraightOnly));
            _result._triggers.Add(TrafficLightTrigger.StraightOnlyGreenOn, from);
            _result._triggers.Add(TrafficLightTrigger.StraightOnlyGreenOff, to);

            return this;
        }

        public ITrafficLightsBuilder AddYellowGRLight(TimeSpan from, TimeSpan to)
        {
            Validator.ValidateLightsTimings(from, to);

            _result._yellowSection = new();
            _result._triggers.Add(TrafficLightTrigger.YellowGROn, from);
            _result._triggers.Add(TrafficLightTrigger.YellowGROff, to);

            return this;
        }

        public ITrafficLightsBuilder AddYellowRGLight(TimeSpan from, TimeSpan to)
        {
            Validator.ValidateLightsTimings(from, to);

            _result._yellowSection = new();
            _result._triggers.Add(TrafficLightTrigger.YellowRGOn, from);
            _result._triggers.Add(TrafficLightTrigger.YellowRGOff, to);

            return this;
        }

        public ITrafficLightsBuilder WithName(string name)
        {
            Validator.ValidateName(name);

            _result.Name = name;
            return this;
        }


        //ITrafficLightsBuilder WithGreenBlinkingTime(TimeSpan duration)
        //{
        //    throw new NotImplementedException();
        //}

        //ITrafficLightsBuilder WithRedBlinkingTime(TimeSpan duration)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
