using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models.OrderModels
{
    public class Dessert : IDish
    {
        public async Task<IDish> CookAsync()
        {
            //await CookAsync();
            return this;
        }
    }
}
