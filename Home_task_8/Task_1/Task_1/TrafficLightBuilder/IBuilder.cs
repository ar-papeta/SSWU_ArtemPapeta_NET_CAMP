
namespace Task_1.TrafficLightBuilder;

public interface IBuilder<T>
{
    public void Reset();
    public T Build();
}
