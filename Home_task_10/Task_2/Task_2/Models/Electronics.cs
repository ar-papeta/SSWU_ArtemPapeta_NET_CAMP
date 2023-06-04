using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.ShippingVisitor;

namespace Task_2.Models;

public class Electronics : Product
{
    public double Weight { get; set; }
    public double Price { get; set; }
    public bool IsOversized(double allowedSize) => CalculateSize() > allowedSize;

    public override void Accept(IShippingVisitor visitor)
    {
        visitor.VisitElectronics(this);
    }

    public override double CalculateSize()
    {
        return Dimensions.Height * Dimensions.Length * Dimensions.Width;
    }
}
