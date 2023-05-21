
using Task1.Models.OrderModels;

namespace Task1.Models.CooksModels;

public interface ICook<T> where T : IDish
{
    public string Name { get; set; }

    public T Cooking(T dish);
}
