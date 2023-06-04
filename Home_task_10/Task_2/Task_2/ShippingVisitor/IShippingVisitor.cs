
using Task_2.Models;

namespace Task_2.ShippingVisitor
{
    public interface IShippingVisitor
    {
        void VisitFood(Food food);
        void VisitElectronics(Electronics electronics);
        void VisitClothing(Clothing clothing);
    }
}
