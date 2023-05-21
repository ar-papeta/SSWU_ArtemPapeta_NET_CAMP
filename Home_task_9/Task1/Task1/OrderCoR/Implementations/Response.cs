using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Models;
using Task1.Models.OrderModels;
using Task1.OrderCoR.Abstractions;

namespace Task1.OrderCoR.Implementations;

public class Response : IResponse
{
    public Guid Id { get; }

    public Order Order { get; }

    public OrderExecutionInfo Info { get; }

    public Response(IReadOnlyCollection<string> messages)
    {
        
    }
}
