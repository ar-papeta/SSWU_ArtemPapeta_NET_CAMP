
using Newtonsoft.Json;

namespace Task_2.Models;

internal class ShopItemModel
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? CategoryName { get; set; }
    public BoxModel? Box { get; set; } = new ();
}
    