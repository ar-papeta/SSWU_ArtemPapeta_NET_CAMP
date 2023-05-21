using Task1.Models.OrderModels;

namespace Task1.OrderCoR.Abstractions;

public interface IRequest
{
    Guid Id { get; }
    Order Order { get; }
}