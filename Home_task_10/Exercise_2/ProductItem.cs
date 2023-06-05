namespace Exercise_2;

// Клас "Продукт"
public class ProductItem : Product
{
    public bool IsPerishable { get; set; }

    public override double Accept(ShippingCostVisitor visitor)
    {
        return visitor.VisitProduct(this);
    }
}