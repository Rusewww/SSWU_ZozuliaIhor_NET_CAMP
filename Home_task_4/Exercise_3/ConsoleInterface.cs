namespace Exercise_3
{
    public class ConsoleInterface
    {
        private static readonly ApartmentsManipulator apartments = new ApartmentsManipulator();
        
        public static void Start()
        {
            apartments.ReadApartmentsFromFile("../../../data.txt");
            Console.WriteLine("Enter the cost of electricity:");
            double cost = Convert.ToDouble(Console.ReadLine());
            while (true)
            {
                Console.WriteLine(
                    "1 - Show apartments table;\n2 - Show apartment;\n3 - Find max bill;\n4 - Show apartment that don`t use electricity;\n5 - Exit;");
                Console.WriteLine("Write number to choose: ");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        ShowApartmentsTable(cost);
                        Console.ReadLine();
                        break;
                    case 2:
                        ShowApartment();
                        Console.ReadLine();
                        break;
                    case 3:
                        ShowMaxBill(cost);
                        Console.ReadLine();
                        break;
                    case 4:
                        ShowApartmentsWithoutElectricity();
                        Console.ReadLine();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Wrong item!!!!!");
                        break;
                }
            }
        }
        
        private static void ShowApartmentsTable(double cost)
        {
            Console.WriteLine("Report for quarter {0}", apartments.Quarter);
            Console.WriteLine("|{0,-4}|{1,-20}|{2,-15}|{3,-24}|{4,-21}|{5,-28}|{6,-35:F2}|", "No.", "Address",
                "Owner", "Electricity consumption", "Date of last reading", "Need to pay for electricity", "Days since the last fixation");
            Console.WriteLine(
                "|----|--------------------|---------------|------------------------|---------------------|----------------------------|-----------------------------------|");
            foreach (var flat in apartments.Apartments)
            {
                Console.WriteLine("|{0,-4}|{1,-20}|{2,-15}|{3,-24}|{4,-21}|{5,-28}|{6,-35:F2}|", flat.Number,
                    flat.Address,
                    flat.OwnerName, flat.EndReading - flat.StartReading,
                    flat.ReadingDate.ToString("dd.MM.yy"), flat.GetBillCost(cost).bill,
                    (DateTime.Now - flat.ReadingDate).ToString("dd"));
            }
            Console.WriteLine(
                "|----|--------------------|---------------|------------------------|---------------------|----------------------------|-----------------------------------|");
        }
        
        private static void ShowApartment()
        {
            Console.WriteLine("How you want to find apartment:\n1 - By number;\n2 - By owner surname;");
            int find = Convert.ToInt32(Console.ReadLine());
            string res = "";
            switch (find)
            {
                case 1:
                    Console.WriteLine("Enter number of flat:");
                    res = apartments.ShowApartment(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Enter owner number");
                    res = apartments.ShowApartment(Console.ReadLine());
                    break;
            }
            if (res != null)
            {
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("There is no such apartment.");
            }
        }
        
        private static void ShowMaxBill(double cost)
        {
            var bill = apartments.FindMaxTax(cost);
            Console.WriteLine($"Owner name: {bill.owner}; Should to pay: {bill.bill}.");
        }
        
        private static void ShowApartmentsWithoutElectricity()
        {
            Console.WriteLine(apartments.ShowApartmentWithoutElectricity());
        }
    }
}
