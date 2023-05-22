namespace Task1.Models.OrderModels;

public interface IDish
{
    public string Name { get; set; }
    public int CookingTimeInSec { get; set; }
    public bool IsReady { get; set; }
    public Task<IDish> CookAsync();
}