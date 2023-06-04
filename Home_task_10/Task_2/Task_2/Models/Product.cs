using Task_2.ShippingVisitor;

namespace Task_2.Models;

public abstract class Product
{
    public ProductDimensions Dimensions { get; set; }
    public abstract void Accept(IShippingVisitor visitor);
    public abstract double CalculateSize();
}
