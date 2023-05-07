using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Models;

public class PeriodStatesTimeSpanModel
{
    public TimeSpan GreenSpan { get; set; }
    public TimeSpan GreenBlinkingSpan { get; set; }
    public TimeSpan YellowSpan { get; set; }
}
