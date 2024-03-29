﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Models;

namespace Task_1.View;

public interface IView
{// Я б називала в інтерфейсі Show, а не Print
    public event Func<(string name, TrafficLightState state)[]> PrintInfoNotify;
    public void PrintInfo(int time);
}
