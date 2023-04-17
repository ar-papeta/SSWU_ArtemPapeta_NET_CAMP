using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Models;

internal class ElectricityQuarterInfoModel
{
    public int Quarter { get; set; }
    public List<ConsumerModel> Consumers { get; set; } = new();
    public int ConsumersCount { get; set; }
}
