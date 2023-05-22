using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models.OrderModels;

public class Pizza : IDish
{
    public string Name { get; set; }
    public int CookingTimeInSec { get; set; }
    public bool IsReady { get; set; }
    public async Task<IDish> CookAsync()
    {
        return new Pizza();
    }
}
