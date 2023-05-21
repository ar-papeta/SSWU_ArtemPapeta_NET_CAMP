
using Task1.Models.OrderModels;

namespace Task1.Models.CooksModels;

public class PizzaCook : ICook<Pizza>
{
    public string Name { get; set; }

    public Pizza Cooking(Pizza dish)
    {
        throw new NotImplementedException();
    }
}
