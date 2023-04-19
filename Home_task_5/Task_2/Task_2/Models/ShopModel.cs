using Newtonsoft.Json;


namespace Task_2.Models;

internal class ShopModel
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public BoxModel? Box { get; set; }
    public string? Name { get; set; }
    public List<ShopCategoryModel>? Categories { get; set; } = new();
    
}
