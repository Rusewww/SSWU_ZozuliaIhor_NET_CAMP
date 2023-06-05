namespace Exercise_2;

// Базовий клас "Товар"
public abstract class Product
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Size { get; set; }
    
    public double Price { get; set; }

    // Метод для відвідувача
    public abstract double Accept(ShippingCostVisitor visitor);
}