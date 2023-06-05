namespace Exercise_2;

public class ShippingCostCalculator : ShippingCostVisitor
{
    public override double VisitProduct(ProductItem product)
    {
        double shippingCost = product.Weight * 0.5; // Вартість доставки на основі ваги

        if (product.IsPerishable)
        {
            shippingCost += 5.0; // Додаткова вартість для продуктів, що швидко псуються
        }

        return shippingCost;
    }

    public override double VisitElectronics(ElectronicsItem electronics)
    {
        double shippingCost = electronics.Weight * 0.5; // Вартість доставки на основі ваги

        if (electronics.Size > 100)
        {
            double extraCharge = electronics.Price * electronics.ExtraChargePercentage / 100;
            shippingCost += extraCharge; // Додаткова вартість для електроніки з великими габаритами
        }

        return shippingCost;
    }

    public override double VisitClothing(ClothingItem clothing)
    {
        double shippingCost = clothing.Weight * 0.5; // Вартість доставки на основі ваги

        // Для одягу немає додаткових витрат на доставку

        return shippingCost;
    }
}