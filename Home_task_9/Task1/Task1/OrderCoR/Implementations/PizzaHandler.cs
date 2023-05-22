
using Task1.Models.CooksModels;
using Task1.Models.OrderModels;
using Task1.OrderCoR.Abstractions;

namespace Task1.OrderCoR.Implementations;

public class PizzaHandler : HandlerBase
{
    public PizzaCook Cook { get; set; }
    public PizzaHandler(PizzaCook cook)
    {
        Cook = cook;
    }
    public override IResponse Handle(IRequest request)
    {
        var pizza = request.Order.TakeFirstFromOrder<Pizza>();
        if (pizza is not null)
        {
            Cook.Cooking(pizza);
        }


        if (!request.Order.IsOrderComplete() && NextHandler is not null)
        {
            return NextHandler.Handle(request);
        }

        return new Response();
    }
}
