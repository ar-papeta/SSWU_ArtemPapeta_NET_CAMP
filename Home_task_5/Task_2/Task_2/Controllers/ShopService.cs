using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Models;
using Task_2.Views;

namespace Task_2.Controllers
{
    internal class ShopService
    {
        private readonly ShopModel _shopModel;

        public ShopService()
        {
            _shopModel = new()
            {
                Id = Guid.NewGuid(),
                Box = new BoxModel(),
            };
        }
        public ShopService(ShopModel shopModel)
        {
            _shopModel = shopModel;
        }
        public void ChangeShopName(string? name) => _shopModel.Name ??= name;

        public void AddCategory(ShopCategoryModel category)
        {
            if (category.Box!.Width > _shopModel.Box!.Width)
            {
                _shopModel.Box.Width = category.Box.Width;
            }

            if (category.Box!.Length > _shopModel.Box!.Length)
            {
                _shopModel.Box.Length = category.Box.Length;
            }

            _shopModel.Box.Height += category.Box.Height;

            _shopModel.Categories!.Add(category);
        }

        public ShopCategoryModel GetCategoryById(Guid? id)
        {
            return _shopModel.Categories.Find(g => g.Id == id);
        }

        public string GetShopName() => _shopModel?.Name ?? string.Empty;

        public List<ShopCategoryModel> GetShopCategories() => _shopModel.Categories;
    }
}
