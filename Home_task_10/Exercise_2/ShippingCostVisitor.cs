namespace Exercise_2;

public abstract class ShippingCostVisitor
{
    public abstract double VisitProduct(ProductItem product);
    public abstract double VisitElectronics(ElectronicsItem electronics);
    public abstract double VisitClothing(ClothingItem clothing);
}