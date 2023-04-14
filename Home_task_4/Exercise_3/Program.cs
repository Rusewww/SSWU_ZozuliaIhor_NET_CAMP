namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ApartmentFileManipulator apartmens = new ApartmentFileManipulator();
            apartmens.ReadApartmentsFromFile("../../../data.txt");
            foreach (var apartment in apartmens.Apartments)
            {
                Console.WriteLine(apartment.ToString());
            }
        }
    }
}

