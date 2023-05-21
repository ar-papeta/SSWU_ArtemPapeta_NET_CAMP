namespace Task1.Models.OrderModels;

public class Order
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    private readonly IList<IDish> _dishes;
    public Order()
    {
        _dishes = new List<IDish>();
    }

    public void AddToOrder(IDish dish) => _dishes.Add(dish);

    public void RemoveFromOrder(IDish dish) => _dishes.Remove(dish);

}
