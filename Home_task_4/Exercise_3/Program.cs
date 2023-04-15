namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ApartmentsManipulator apartmens = new ApartmentsManipulator();
            apartmens.ReadApartmentsFromFile("../../../data.txt");
            /*foreach (var apartment in apartmens.Apartments)
            {
                Console.WriteLine(apartment.ToString());
            }*/
            Console.WriteLine(apartmens.FindMaxTax(15));
            Console.WriteLine(apartmens.ShowApartmentWithoutElectricity());
            Console.WriteLine(apartmens.ShowApartment(3));
        }
    }
}

