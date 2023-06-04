using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Models;

namespace Task_2.ShippingVisitor;

public class ShippingCostVisitor : IShippingVisitor
{
    public double ShippingCost { get; private set; }

    private const double FoodWeightCoef = 0.7;
    private const double FoodUrgentCost = 10.0;
    private const double FoodSizeCostCoef = 5.0;
    private const double FoodMaxAllowedSize = 100;
    public void VisitFood(Food food)
    {
        double baseCost = food.Weight * FoodWeightCoef;
        double urgentCost = food.IsUrgent ? FoodUrgentCost : 0.0;
        double sizeCost = food.CalculateSize() > FoodMaxAllowedSize ? FoodSizeCostCoef * baseCost : 0.0;

        ShippingCost += (baseCost + urgentCost + sizeCost);
    }

    private const double ElectronicsWeightCoef = 0.86;
    private const double ElectronicsMaxAllowedSize = 100;
    private const double ElectronicsOversizeCoef = 0.3;
    public void VisitElectronics(Electronics electronics)
    {
        double baseCost = electronics.Weight * ElectronicsWeightCoef;
        double oversizedCost = electronics.IsOversized(ElectronicsMaxAllowedSize) ? electronics.Price * ElectronicsOversizeCoef : 0.0;

        ShippingCost += (baseCost + oversizedCost);
    }

    private const double ClothingWeightCoef = 11.36;
    private const double ClothingMaxAllowedSize = 50;
    private const double ClothingOversizeCoef = 2;
    public void VisitClothing(Clothing clothing)
    {
        double baseCost = clothing.Weight * ClothingWeightCoef;
        double sizeCost = clothing.CalculateSize() > ClothingMaxAllowedSize ? ClothingOversizeCoef * baseCost : 0.0;
        ShippingCost += (baseCost + sizeCost);
    }
}
