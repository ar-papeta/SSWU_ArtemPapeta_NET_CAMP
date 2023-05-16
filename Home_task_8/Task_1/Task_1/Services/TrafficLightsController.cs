using Task_1.TrafficLightBuilder;

namespace Task_1.Services;

public class TrafficLightsController
{
    private Timer? _timeLoop = null!;

    public event Action<TimeSpan> NotifyTimeStamp = null!;
    private SortedSet<TimeSpan> _timeStamps = new();
    private readonly List<TrafficLights> _trafficLights = new();

    public void StartTrafficLightsControl()
    {
        _timeLoop = new Timer(DoWork, null, TimeSpan.Zero, Timeout.InfiniteTimeSpan);
    }

    public (string name, string state)[] GetAllTrafficLightsInfo()
    {
        return _trafficLights.Select(x => (x.Name, x.GetStateStr())).ToArray()!;
    }

    private void DoWork(object? state)
    {
        var newTimeSpan = GetNextTimeTrigger(out TimeSpan trigger);
        NotifyTimeStamp?.Invoke(trigger);

        _timeLoop!.Change(newTimeSpan, Timeout.InfiniteTimeSpan);
    }

    private int _currIndex = 0;
    private TimeSpan _nextSpan = TimeSpan.Zero;
    private TimeSpan GetNextTimeTrigger(out TimeSpan trigger)
    {
        
        trigger = _timeStamps.Skip(_currIndex++).First();
        
        if (_currIndex >= _timeStamps.Count) 
        {
            _currIndex = 0;
            return _timeStamps.Skip(_currIndex).First();
        }
        else
        {
            _nextSpan = _timeStamps.Skip(_currIndex).First();
        }
        
        var nextTs = _nextSpan - trigger;
        return nextTs;
    }

    public void AddTrafficLigthsToControl(TrafficLights tl)
    {
        _trafficLights.Add(tl);
        NotifyTimeStamp += tl.CheckTriggerChangeState;
        foreach (var item in tl.GetTriggersTimings())
        {
            _timeStamps.Add(item);
        }
    }
}
