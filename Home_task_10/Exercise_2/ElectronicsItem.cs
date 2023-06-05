namespace Exercise_2;

// Клас "Електроніка"
public class ElectronicsItem : Product
{
    public double ExtraChargePercentage { get; set; }

    public override double Accept(ShippingCostVisitor visitor)
    {
        return visitor.VisitElectronics(this);
    }
}