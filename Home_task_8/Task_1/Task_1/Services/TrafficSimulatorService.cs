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
    private TrafficLightsController _controller;
    private int _simulationTimeSec;
    private IView _view;

    public TrafficSimulatorService(int sec, TrafficLightsController controller, IView view)
    {
        Validator.ValidateSimulationTime(sec);

        _controller = controller;
        _simulationTimeSec = sec;
        _view = view;
        _view.PrintInfoNotify += _controller.GetAllTrafficLightsInfo;
    }

    public void StartSimulation()
    {
        _controller.StartTrafficLightsControl();
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(1050)); //замість секунди, щоб не потрапляти на граничні значення
    }


    private int i = 0;
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
