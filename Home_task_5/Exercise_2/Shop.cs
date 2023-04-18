namespace Exercise_2
{
    internal class Shop
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        
        public Shop()
        {
            Name = "";
            Departments = new List<Department>();
        }
        
        public Shop(string name, List<Department> departments)
        {
            Name = name;
            Departments = departments;
        }
        
        public void AddDepartment(Department department)
        {
            Departments.Add(department);
        }
        
        public List<Box> PackProducts(List<Item> products, Shop shop)
        {
            List<Box> boxes = new List<Box>();
            foreach (var product in products)
            {
                Box boxToUse = null;
                foreach (Box box in boxes)
                {
                    if (Box.IsFitInBox(product, box))
                    {
                        boxToUse = box;
                        break;
                    }
                }
                if (boxToUse != null)
                {
                    boxToUse.Products.Add(product);
                    var dimensions = boxToUse.CalculateBoxDimensions();
                    boxToUse.Height = dimensions.height;
                    boxToUse.Length = dimensions.length;
                    boxToUse.Width = dimensions.width;
                    boxToUse.Name += $", {product.Name}";
                }
                else
                {
                    Box newBox = new Box(product.Name, new List<Item> { product }, shop);
                    boxes.Add(newBox);
                }
            }
            return boxes;
        }
    }
}