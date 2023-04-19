using Newtonsoft.Json;


namespace Task_2.Models;

internal class ShopModel
{
    [JsonIgnore]
    public Guid Id { get; private set; } = Guid.Empty;
    public BoxModel? Box { get; set; }
    public string? Name { get; set; }
    public ShopCategoryModel? NodeCategory { get; set; } = new();
    
}
