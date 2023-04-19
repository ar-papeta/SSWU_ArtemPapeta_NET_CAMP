
using Newtonsoft.Json;
using Task_2.Controllers;
using Task_2.Models;

namespace Task_2.Views;

internal class ConsoleView : IView
{
    private readonly ShopService _service;
    private ShopCategoryModel _currCategory = new();
    public ConsoleView(ShopService service)
    {
        _service = service;
    }

    public void ShowMenu()
    {
        CreateShop();
        ShowShopStartMenu();
    }

    public void ShowShopStartMenu()
    {
        Console.WriteLine($"1 - Add category to root shop {_service.GetShopName()}");
        Console.WriteLine("2 - Show shop structure");
        int key = Convert.ToInt32(Console.ReadLine());
        if(key == 1) 
        {
            AddCategory();
            CategoryMenu();
        }
        else if(key == 2)
        {
            PrintShopStructure();
        }
    }

    public void CategoryMenu()
    {
        Console.WriteLine($"1 - Add subcategory to {_currCategory.Name}");
        Console.WriteLine($"2 - Add item to {_currCategory.Name}");
        Console.WriteLine("3 - Go to up menu");
        int key = Convert.ToInt32(Console.ReadLine());
        if(key == 1) 
        {
            AddCategory();
            CategoryMenu();
        }
        if(key == 2)
        {
            AddItemToCategoryMenu();
            CategoryMenu();
        }
        if(key == 3)
        {
            if(_currCategory.ParentCategoryId is not null && _currCategory.ParentCategoryId != Guid.Empty)
            {
                _currCategory = _service.GetCategoryById(_currCategory.ParentCategoryId);
                CategoryMenu();
            }
            else
            {
                _currCategory = new();
                ShowShopStartMenu();
            }
        }

    }

    public void CreateShop()
    {
        Console.WriteLine("Create shop with name: ");
        _service.ChangeShopName(Console.ReadLine());
    }

    public void AddCategory()
    {
        ShopCategoryModel model = new()
        {
            ParentCategoryId = _currCategory.Id,
            ParentCategory = _currCategory,
            Id = Guid.NewGuid(),
            Box = new()
        };
        Console.WriteLine("Add category: ");
        Console.Write("Name: ");
        model.Name = Console.ReadLine();
        if (_currCategory.Id == Guid.Empty)
        {
            _service.AddCategory(model);
        }
        else
        {
            _service.AddCategory(model);
            _currCategory.ChildCategories.Add(model);
            _currCategory.ChangeBoxSize(model.Box);
        }

        _currCategory = model;

       
    }

    public void AddItemToCategoryMenu()
    {
        ShopItemModel model = new()
        {
            Id = Guid.NewGuid(),
            CategoryName = _currCategory.Name
        };
        Console.WriteLine($"Add new item to category {_currCategory.Name}");
        Console.WriteLine($"Item GUID: {model.Id}");
        Console.Write("Item name: ");
        model.Name = Console.ReadLine();
        Console.Write("Item length: ");
        model.Box.Length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Item height: ");
        model.Box.Height = Convert.ToDouble(Console.ReadLine());
        Console.Write("Item width: ");
        model.Box.Width = Convert.ToDouble(Console.ReadLine());

        _currCategory.AddShopItem(model);
       
    }

    public void PrintShopStructure()
    {
        _service.ChangeBox(new()
        {
            Height = _service.GetShopCategories().Sum(x => x.Box.Height),
            Width = _service.GetShopCategories().Max(x => x.Box.Width),
            Length = _service.GetShopCategories().Max(x => x.Box.Length),
        });
        Console.WriteLine("******************");
        Console.WriteLine($"Shop {_service.GetShopName()} with: ");
        string json = JsonConvert.SerializeObject(_service.GetShop(), Formatting.Indented);
        Console.WriteLine(json);
     
    }
}
