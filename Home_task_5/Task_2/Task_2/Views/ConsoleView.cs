
using Newtonsoft.Json;
using Task_2.Controllers;
using Task_2.Models;

namespace Task_2.Views;

internal class ConsoleView : IView
{
    private readonly ShopService _service;
    private ShopCategoryModel _currentCategory = new() { };
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
        Console.WriteLine($"1 - Add subcategory to {_currentCategory.Name}");
        Console.WriteLine($"2 - Add item to {_currentCategory.Name}");
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
            if(_currentCategory.ParentCategoryId is not null && _currentCategory.ParentCategoryId != Guid.Empty)
            {
                _currentCategory = _service.GetCategoryById(_currentCategory.ParentCategoryId);
                CategoryMenu();
            }
            else
            {
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
            ParentCategoryId = _currentCategory.Id,
            Id = Guid.NewGuid(),
            Box = new()
        };
        Console.WriteLine("Add category: ");
        Console.Write("Name: ");
        model.Name = Console.ReadLine();
        if (_currentCategory.Id == Guid.Empty)
        {
            _service.AddCategory(model);
        }
        else
        {
            _currentCategory.ChildCategories.Add(model);
        }

        _currentCategory = model;

       
    }

    public void AddItemToCategoryMenu()
    {
        ShopItemModel model = new()
        {
            Id = Guid.NewGuid(),
            CategoryName = _currentCategory.Name
        };
        Console.WriteLine($"Add new item to category {_currentCategory.Name}");
        Console.WriteLine($"Item GUID: {model.Id}");
        Console.Write("Item name: ");
        model.Name = Console.ReadLine();
        Console.Write("Item length: ");
        model.Box.Length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Item height: ");
        model.Box.Height = Convert.ToDouble(Console.ReadLine());
        Console.Write("Item width: ");
        model.Box.Width = Convert.ToDouble(Console.ReadLine());

        _currentCategory.AddShopItem(model);
    }

    public void PrintShopStructure()
    {
        Console.WriteLine("******************");
        Console.WriteLine($"Shop {_service.GetShopName()} with: ");
        string json = JsonConvert.SerializeObject(_service.GetShopCategories(), Formatting.Indented);
        Console.WriteLine(json);
     
    }
}
