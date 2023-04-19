
using Newtonsoft.Json;

namespace Task_2.Models;

internal class ShopCategoryModel
{
    [JsonIgnore]
    public Guid Id { get; set; }

    [JsonIgnore]
    public Guid? ParentCategoryId { get; set; }
    public string? Name { get; set; }
    public BoxModel? Box { get; set; }
    public List<ShopCategoryModel> ChildCategories { get; set; } = new();
    public List<ShopItemModel> Items { get; private set; } = new();

    public void AddShopItem(ShopItemModel item)
    {
        if (item.Box!.Width > Box!.Width)
        {
            Box.Width = item.Box.Width;
        }

        if (item.Box!.Length > Box!.Length)
        {
            Box.Length = item.Box.Length;
        }

        Box.Height += item.Box.Height;

        Items.Add(item);
    }

}
