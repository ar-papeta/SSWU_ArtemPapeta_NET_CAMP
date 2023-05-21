using Task1.Models;
using Task1.Models.OrderModels;

namespace Task1.OrderCoR.Abstractions;

public interface IResponse
{
    Guid Id { get; }
    Order Order { get; }
    OrderExecutionInfo Info { get; }
}