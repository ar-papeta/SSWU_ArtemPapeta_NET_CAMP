using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.ShippingVisitor;

namespace Task_2.Models;

public class Food : Product
{
    public double Weight { get; set; }
    public bool IsUrgent { get; set; }

    public override void Accept(IShippingVisitor visitor)
    {
        visitor.VisitFood(this);
    }

    public override double CalculateSize()
    {
        return Dimensions.Height * Dimensions.Length * Dimensions.Width;
    }
}
