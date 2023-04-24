namespace Exercise_2
{
    internal class Department
    {
        public string Name { get; }
        //Порушення інкапсуляції
        // не враховано ієрархічну структуру.
        public List<Item> Products { get; }

        public Department(string name)
        {
            Name = name;
            Products = new List<Item>();
        }

        public void AddProduct(Item item) => Products.Add(item);

        public void AddProducts(List<Item> products) => Products.AddRange(products);
    }
}
