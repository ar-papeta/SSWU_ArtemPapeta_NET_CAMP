using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models.OrderModels;

public class Drink : Dish, IDish
{
    public Task<IDish> CookAsync()
    {
        return this;
    }
}
