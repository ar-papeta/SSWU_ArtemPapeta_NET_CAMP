namespace Task1.Models.OrderModels;

public interface IDish
{
    public Task<IDish> CookAsync();
}