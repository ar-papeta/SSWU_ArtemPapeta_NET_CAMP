using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Models.OrderModels;

namespace Task1.Models.CooksModels;

public class UniversalCook : ICook<IDish>
{
    public string Name { get; set; }

    public IDish Cooking(IDish dish)
    {
        throw new NotImplementedException();
    }
}
