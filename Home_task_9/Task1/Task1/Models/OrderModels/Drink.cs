﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models.OrderModels;

public class Drink : IDish
{
    public async Task<IDish> CookAsync()
    {
        return this;
    }
}
