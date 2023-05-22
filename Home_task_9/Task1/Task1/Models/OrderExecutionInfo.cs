namespace Task1.Models;

public class OrderExecutionInfo
{
    public Guid OrderGuid { get; init; }
    public List<DishExecutionInfo> DishesInfos { get; init; }
    public OrderExecutionInfo()
    {
        DishesInfos = new();
    }
}