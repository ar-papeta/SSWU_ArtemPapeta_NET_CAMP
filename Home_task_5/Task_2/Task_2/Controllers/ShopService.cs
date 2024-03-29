﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Models;
using Task_2.Views;

namespace Task_2.Controllers
{//це не досконалий варіант контролера. Він має бути у вигляді паттерну Посередник. Будемо вчити в 2 турі.
    internal class ShopService
    {
        private readonly ShopModel _shopModel;

        public ShopService()
        {
            _shopModel = new()
            {
                Box = new BoxModel(),
            };
        }
        public ShopService(ShopModel shopModel)
        {// Не хороша прив'язка. Слід робити клон(глибоку копію)
            _shopModel = shopModel;
        }

        public void ChangeBox(BoxModel box)
        {
            _shopModel.Box = box;
            _shopModel.NodeCategory.Box = box;
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

            _shopModel.NodeCategory!.ChildCategories.Add(category);
        }

        public ShopCategoryModel GetCategoryById(Guid? id)
        {
            return _shopModel.NodeCategory!.ChildCategories.Find(g => g.Id == id)!;
        }

        public string GetShopName() => _shopModel?.Name ?? string.Empty;

        public List<ShopCategoryModel> GetShopCategories() => _shopModel.NodeCategory!.ChildCategories.Where(x => x.ParentCategoryId == Guid.Empty).ToList();

        public ShopModel GetShop() => _shopModel;
    }
}
