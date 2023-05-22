namespace Task1.Models.OrderModels;

public class Order
{
    public Guid Id { get; init; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    private readonly IList<IDish> _dishes;
    public Order()
    {
        _dishes = new List<IDish>();
        Id = Guid.NewGuid();
    }

    public void AddToOrder(IDish dish) => _dishes.Add(dish);

    public void RemoveFromOrder(IDish dish) => _dishes.Remove(dish);

    public T TakeFirstFromOrder<T>() where T : IDish
    {
        var dish = _dishes.FirstOrDefault(d => d.GetType() == typeof(T));
        if(dish is not null)
        {
            RemoveFromOrder(dish);
        }

        return (T)dish!;
    }

    public bool IsOrderComplete()
    {
        return !_dishes.Any();
    }

}
