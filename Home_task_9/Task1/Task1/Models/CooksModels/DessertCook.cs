using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Models.OrderModels;

namespace Task1.Models.CooksModels;

public class DessertCook : ICook<Dessert>
{
    public string Name { get; set; }

    public Dessert Cooking(Dessert dish)
    {
        return dish.CookAsync().Result as Dessert;
    }
}
