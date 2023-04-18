namespace Exercise_2
{
    internal class Item
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public Department department { get; set; }
        public double Size => Width * Length * Height;

        public Item(string name, double width, double length, double height, Department department)
        {
            Name = name;
            Width = width;
            Length = length;
            Height = height;
            this.department = department;
        }

        public override string ToString() => $"Product: {Name}; Sizes: {Width}x{Length}x{Height}; Department: {department.Name}";
    }
}