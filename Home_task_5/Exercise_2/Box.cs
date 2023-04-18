namespace Exercise_2
{
    internal class Box
    {
        private readonly Shop _shop;
        public string Name { get; set; }
        public List<Item> Products { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }

        public Box(string name, List<Item> products, Shop shop)
        {
            Name = name;
            Products = products;
            Width = products.Sum(p => p.Width);
            Length = products.Max(p => p.Length);
            Height = products.Max(p => p.Height);
            _shop = shop;
        }

        public (double width, double length, double height) CalculateBoxDimensions()
        {
            double width = Products.Sum(p => p.Width);
            double length = Products.Max(p => p.Length);
            double height = Products.Max(p => p.Height);
            return (width, length, height);
        }

        public static bool IsFitInBox(Item item, Box box)
        {
            if (item.Length <= box.Length && item.Height <= box.Height &&
                (box.Products.Count == 0 || box.Products[0].department == item.department))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var productDepartment = Products.FirstOrDefault()?.department.Name ?? "";
            return $"Box: {_shop.Name}->{productDepartment}\nSizes: {Width}x{Length}x{Height}\nIn box: {Name}";
        }
    }
}
