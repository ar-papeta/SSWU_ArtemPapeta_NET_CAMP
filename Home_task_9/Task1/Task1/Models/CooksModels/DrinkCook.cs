using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Models.OrderModels;

namespace Task1.Models.CooksModels;

public class DrinkCook : ICook<Drink>
{
    public string Name { get; set; }

    public Drink Cooking(Drink dish)
    {
        throw new NotImplementedException();
    }
}
