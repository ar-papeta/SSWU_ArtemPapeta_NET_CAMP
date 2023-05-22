using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Models.OrderModels;
using Task1.OrderCoR.Abstractions;

namespace Task1.OrderCoR.Implementations;


public class Request : IRequest
{
    public Guid Id { get; }
    public Order Order { get; }

    public Request(Order order)
    {
        Id = Guid.NewGuid();
        Order = order;
    }
}

