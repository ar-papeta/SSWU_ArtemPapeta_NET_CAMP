using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.OrderCoR.Abstractions;

public interface IHandler
{
    IHandler SetNextHandler(IHandler next);
    IResponse Handle(IRequest request);
}
