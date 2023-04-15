namespace Exercise_3
{
    public class ConsoleInterface
    {
        public static void Start()
        {
            ApartmentsManipulator apartments = new ApartmentsManipulator();
            apartments.ReadApartmentsFromFile("../../../data.txt");
            Console.WriteLine("Enter the cost of electricity:");
            string line = Console.ReadLine();
            double cost = Convert.ToDouble(line);
            while (true)
            {
                Console.WriteLine(
                    "1 - Show apartments table;\n2 - Show apartment;\n3 - Find max bill;\n4 - Show apartment that don`t use electricity;\n5 - Exit;");
                Console.WriteLine("Write number to choose: ");
                line = Console.ReadLine();
                int num = Convert.ToInt32(line);
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Report for quarter {0}", apartments.Quarter);
                        Console.WriteLine("|{0,-4}|{1,-20}|{2,-15}|{3,-24}|{4,-21}|{5,-28:F2}|", "No.", "Address",
                            "Owner", "Electricity consumption", "Date of last reading", "Need to pay for electricity");
                        Console.WriteLine(
                            "|----|--------------------|---------------|------------------------|---------------------|----------------------------|");
                        foreach (var flat in apartments.Apartments)
                        {
                            Console.WriteLine("|{0,-4}|{1,-20}|{2,-15}|{3,-24}|{4,-21}|{5,-28:F2}|", flat.Number,
                                flat.Address,
                                flat.OwnerName, flat.EndReading - flat.StartReading,
                                flat.ReadingDate.ToString("dd.MM.yy"), flat.GetBillCost(cost).bill);
                        }

                        Console.WriteLine(
                            "|----|--------------------|---------------|------------------------|---------------------|----------------------------|");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("How you want to find apartment:\n1 - By number;\n2 - By onwer surname;");
                        line = Console.ReadLine();
                        int find = Convert.ToInt32(line);
                        string res = "";
                        switch (find)
                        {
                            case 1:
                                Console.WriteLine("Enter number of flat:");
                                line = Console.ReadLine();
                                res = apartments.ShowApartment(Convert.ToInt32(line));
                                break;
                            case 2:
                                Console.WriteLine("Enter owner number");
                                line = Console.ReadLine();
                                res = apartments.ShowApartment(line);
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
                        Console.ReadLine();
                        break;
                    case 3:
                        var bill = apartments.FindMaxTax(cost);
                        Console.WriteLine($"Owner name: {bill.owner}; Should to pay: {bill.bill}.");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine(apartments.ShowApartmentWithoutElectricity());
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
    }
}