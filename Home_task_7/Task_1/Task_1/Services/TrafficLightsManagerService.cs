
using Task_1.Models;

namespace Task_1.Services;

public class TrafficLightsManagerService
{
    private int _intervalNum = 0;
    private Timer? _timerPeriod = null!;
    private PeriodStatesTimeSpanModel _period1;
    private PeriodStatesTimeSpanModel _period2;

    public event Action<TrafficLightState> FirstGroupNotify = null!;
    public event Action<TrafficLightState> SecondGroupNotify = null!;

    private readonly List<TrafficLights> _firstPeriodTrafficLights = new();
    private readonly List<TrafficLights> _secondPeriodTrafficLights = new();

    public TrafficLightsManagerService(PeriodStatesTimeSpanModel period1, PeriodStatesTimeSpanModel period2)
    {
        _period1 = period1;
        _period2 = period2;
    }

    public (string name, TrafficLightState state)[] GetAllTrafficLightsInfo()
    {
        return _firstPeriodTrafficLights.Concat(_secondPeriodTrafficLights).Select(x => (x.Name, x.GetCurrentState())).ToArray()!;
    }

    public void ChangePeriod1(PeriodStatesTimeSpanModel newPeriod)
    {
        _period1 = newPeriod;
    }

    public void ChangePeriod2(PeriodStatesTimeSpanModel newPeriod)
    {
        _period2 = newPeriod;
    }

    public void StartTrafficLights()
    {
        _timerPeriod = new Timer(DoWork, null, TimeSpan.Zero, Timeout.InfiniteTimeSpan);
    }

    public void AddToFirstGroup(TrafficLights tl)
    {
        _firstPeriodTrafficLights.Add(tl);
        FirstGroupNotify += tl.SetState;
    }

    public void AddToSecondGroup(TrafficLights tl)
    {
        _secondPeriodTrafficLights.Add(tl);
        SecondGroupNotify += tl.SetState;
    }

    public TimeSpan UpdateLights()
    {
        switch (_intervalNum) 
        {
            case 0:
                FirstGroupNotify?.Invoke(TrafficLightState.Green);
                SecondGroupNotify?.Invoke(TrafficLightState.Red);
                _intervalNum++;
                return _period1.GreenSpan;
            case 1:
                FirstGroupNotify?.Invoke(TrafficLightState.GreenBlinking);
                _intervalNum++;
                return _period1.GreenBlinkingSpan;
            case 2:
                FirstGroupNotify?.Invoke(TrafficLightState.Yellow);
                SecondGroupNotify?.Invoke(TrafficLightState.Yellow);
                _intervalNum ++;
                return _period1.YellowSpan;
            case 3:
                FirstGroupNotify?.Invoke(TrafficLightState.Red);
                SecondGroupNotify?.Invoke(TrafficLightState.Green);
                _intervalNum++;
                return _period2.GreenSpan;
            case 4:
                SecondGroupNotify?.Invoke(TrafficLightState.GreenBlinking);
                _intervalNum++;
                return _period2.GreenBlinkingSpan;
            case 5:
                FirstGroupNotify?.Invoke(TrafficLightState.Yellow);
                SecondGroupNotify?.Invoke(TrafficLightState.Yellow);
                _intervalNum = 0;
                return _period2.YellowSpan;
            default:
                //Notify wrong
                throw new Exception("Wrong something !!!");

        }
    }

    private void DoWork(object? state)
    {
        var newTimeSpan = UpdateLights();
        
        _timerPeriod!.Change(newTimeSpan, Timeout.InfiniteTimeSpan);
    }
}
