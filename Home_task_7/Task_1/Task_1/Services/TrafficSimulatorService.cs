using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task_1.Models;
using Task_1.View;

namespace Task_1.Services;

public class TrafficSimulatorService 
{
    private static Timer? _timer= null;
    private TrafficLightsManagerService _manager;
    private int _simulationTimeSec;
    private IView _view;
    public TrafficSimulatorService(int sec, TrafficLightsManagerService manager, IView view) 
    {
        _manager = manager;
        _simulationTimeSec = sec;
        _view = view;
        _view.PrintInfoNotify += _manager.GetAllTrafficLightsInfo;
    }

    public void StartSimulation()
    {
        _manager.StartTrafficLights();
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(1050)); //замість секунди, щоб не потрапляти на граничні значення
    }

    public void ChangeTimings(PeriodStatesTimeSpanModel newPeriod1, PeriodStatesTimeSpanModel newPeriod2)
    {
        _manager.ChangePeriod1(newPeriod1);
        _manager.ChangePeriod2(newPeriod2);
    }


    private int i = 1;
    private void DoWork(object? o)
    {
        _view.PrintInfo(i);

        if (++i > _simulationTimeSec) 
        {
            Environment.Exit(0);
            //_timer!.Dispose();
        }
    }
}
