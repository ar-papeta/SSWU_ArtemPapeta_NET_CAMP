
using Newtonsoft.Json;
using System.Reflection;

namespace Task_2.Models;

internal class ShopCategoryModel
{
    [JsonIgnore]
    public Guid Id { get; set; }

    [JsonIgnore]
    public Guid? ParentCategoryId { get; set; }

    [JsonIgnore]
    public ShopCategoryModel? ParentCategory { get; set; }
    public string? Name { get; set; }
    public BoxModel? Box { get; set; } = new();
    public List<ShopCategoryModel> ChildCategories { get; set; } = new();
    public List<ShopItemModel> Items { get; private set; } = new();

    public void AddShopItem(ShopItemModel item)
    {
        var c = this;
        ChangeBoxSize(item.Box!);
        while (c.ParentCategoryId != Guid.Empty)
        {
            c.ParentCategory.ChangeBoxSize(item.Box);
            c = c.ParentCategory;
        }
        Items.Add(item);
    }

    public void ChangeBoxSize(BoxModel box)
    {
        if (box!.Width > Box!.Width)
        {
            Box.Width = box.Width;
        }

        if (box!.Length > Box!.Length)
        {
            Box.Length = box.Length;
        }

        Box.Height += box.Height;
    }

}
