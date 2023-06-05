namespace Exercise_2;

public class Program
{
    public static void Main()
    {
        // Створюємо товари
        ProductItem product = new ProductItem
        {
            Name = "Молоко",
            Weight = 0.5,
            Size = 10,
            IsPerishable = true
        };

        ElectronicsItem electronics = new ElectronicsItem
        {
            Name = "Смартфон",
            Weight = 0.3,
            Size = 120,
            ExtraChargePercentage = 10
        };

        ClothingItem clothing = new ClothingItem
        {
            Name = "Футболка",
            Weight = 0.2,
            Size = 30
        };

        // Створюємо відвідувача для розрахунку вартості доставки
        ShippingCostVisitor shippingCostVisitor = new ShippingCostCalculator();

        // Використовуємо відвідувача для розрахунку вартості доставки для кожного товару
        double productShippingCost = product.Accept(shippingCostVisitor);
        double electronicsShippingCost = electronics.Accept(shippingCostVisitor);
        double clothingShippingCost = clothing.Accept(shippingCostVisitor);

        // Виводимо результати
        Console.WriteLine($"Вартiсть доставки продукту \"{product.Name}\": {productShippingCost}");
        Console.WriteLine($"Вартiсть доставки електронiки \"{electronics.Name}\": {electronicsShippingCost}");
        Console.WriteLine($"Вартiсть доставки одягу \"{clothing.Name}\": {clothingShippingCost}");
    }
}