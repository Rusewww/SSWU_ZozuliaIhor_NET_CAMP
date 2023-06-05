namespace Exercise_2;

// Клас "Одяг"
public class ClothingItem : Product
{
    public override double Accept(ShippingCostVisitor visitor)
    {
        return visitor.VisitClothing(this);
    }
}