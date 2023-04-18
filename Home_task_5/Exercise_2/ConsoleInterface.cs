namespace Exercise_2
{
    public class ConsoleInterface
    {
        private static Shop shop;
        private static bool isSet = false;
        
        public static void Start()
        {
            while (true)
            {
                Console.WriteLine(
                    "1 - Enter shop structure;\n2 - Use basic shop;\n3 - Show items;\n4 - Show boxes;\n5 - Exit;");
                Console.WriteLine("Write number to choose: ");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        if (!isSet)
                        {
                            shop = EnterShopStruture();
                            isSet = true;
                        }
                        else
                        {
                            Console.WriteLine("Shop is already set!");
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        if (!isSet)
                        {
                            shop = UseBasicShop();
                            isSet = true;
                        }
                        else
                        {
                            Console.WriteLine("Shop is already set!");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        if (isSet)
                        {
                            ShowItemsInShop();
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Shop is not set!");
                        }

                        break;
                    case 4:
                        if (isSet)
                        {
                            PackProducts();
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Shop is not set!");
                        }

                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Wrong item!!!");
                        break;
                }
            }
        }

        private static Shop EnterShopStruture()
        {
            Console.WriteLine("Enter shop name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter count of departments: ");
            int countOfDepartments = Convert.ToInt32(Console.ReadLine());
            List<Department> departments = new List<Department>();

            for (int i = 0; i < countOfDepartments; i++)
            {
                Console.WriteLine($"Enter name of department {i}: ");
                departments.Add(new Department(Console.ReadLine()));
                Console.WriteLine($"Enter count of items in department: ");
                int countOfItems = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < countOfItems; j++)
                {
                    Console.WriteLine($"Enter name of item {j}: ");
                    string nameItem = Console.ReadLine();
                    Console.WriteLine($"Enter width of {nameItem}: ");
                    int width = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Enter length of {nameItem}: ");
                    int length = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Enter height of {nameItem}: ");
                    int height = Convert.ToInt32(Console.ReadLine());
                    departments[i].AddProduct(new Item(nameItem, width, length, height, departments[i]));
                }
            }

            Shop shop = new Shop(name, departments);
            Console.WriteLine("Shop is set!");
            return shop;
        }

        private static Shop UseBasicShop()
        {
            Department electronic = new Department("Electronics");
            Department food = new Department("Food");
            Department drinks = new Department("Drinks");

            List<Item> electronicItems = new List<Item>
            {
                new Item("TV", 50, 30, 10, electronic),
                new Item("Iphone", 20, 10, 5, electronic),
                new Item("Shaver", 10, 10, 5, electronic),
            };
            
            List<Item> foodItems = new List<Item>
            {
                new Item("Bread", 15, 10, 8, food),
                new Item("Meat", 20, 20, 10, food),
                new Item("Cucumber", 10, 4, 4, food),
            };
            
            List<Item> drinksItems = new List<Item>
            {
                new Item("Water", 25, 10, 10, drinks),
                new Item("CocaCola", 8, 6, 6, drinks),
                new Item("DrPepper", 10, 5, 5, drinks),
            };

            drinks.AddProducts(drinksItems);
            food.AddProducts(foodItems);
            electronic.AddProducts(electronicItems);
            
            List<Department> departments = new List<Department> {electronic, food, drinks};
            Shop shop = new Shop("Rozetka", departments);
            Console.WriteLine("Shop is set!");
            return shop;
        }

        private static void ShowItemsInShop()
        {
            Console.WriteLine($"Items in {shop.Name}:");
            foreach (var department in shop.Departments)
            {
                foreach (var item in department.Products)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void PackProducts()
        {
            foreach (var department in shop.Departments)
            {
                var boxes = shop.PackProducts(department.Products, shop);
                foreach (var box in boxes)
                {
                    Console.WriteLine(box.ToString());
                    Console.WriteLine();
                }
            }
        }
    }
}