namespace Task1.Models.OrderModels;

public class Dish : IDish
{
    public string Name { get; set; }
    public int CookingTimeInSec { get; set; }
    public bool IsReady { get; set; }
    public ConsoleColor Color { get; set; } = ConsoleColor.White;

    public async Task<IDish> CookAsync()
    {
        Console.WriteLine($"Start cooking {Name}", Console.ForegroundColor = Color);
        await BeginCookingAsync();
        Console.WriteLine($"Stop cooking {Name}", Console.ForegroundColor = Color);
        return this;
    }

    private async Task<Dish> BeginCookingAsync()
    {
        await Task.Run(async () =>
        {
            for (int i = 0; i < CookingTimeInSec; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine($"Remain sec for {Name}: {CookingTimeInSec - i - 1}", Console.ForegroundColor = Color);
            }
            IsReady = true;

        });
        return this;
    }

    public override string? ToString()
    {
        return $"Dish {Name}\t Is ready: {IsReady}";
    }
}
