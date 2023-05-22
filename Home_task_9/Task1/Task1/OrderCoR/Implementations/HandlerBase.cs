using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.OrderCoR.Abstractions;

namespace Task1.OrderCoR.Implementations;

public abstract class HandlerBase : IHandler
{
    protected IHandler NextHandler = null!;

    public virtual IHandler SetNextHandler(IHandler next)
    {
        NextHandler = next;
        return next;
    }

    public abstract IResponse Handle(IRequest request);
}
