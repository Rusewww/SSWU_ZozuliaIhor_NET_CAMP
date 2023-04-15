using System;
using System.IO;
using System.Globalization;

namespace Exercise_3
{
    public class ApartmentsManipulator
    {
        private int _apartmentCount;
        private short _quarter;
        public Apartment[] Apartments;

        public short Quarter
        {
            get => _quarter;
            set => _quarter = value;
        }

        public void ReadApartmentsFromFile(string fileName)
        {
            using StreamReader reader = new StreamReader(fileName);

            string[] parts = reader.ReadLine().Split(' ');
            int apartmentCount = int.Parse(parts[0]);
            _quarter = short.Parse(parts[1]);

            Apartment[] apartments = new Apartment[apartmentCount];

            for (int i = 0; i < apartmentCount; i++)
            {
                parts = reader.ReadLine().Split("; ");
                int apartmentNumber = int.Parse(parts[0]);
                string address = parts[1];
                string ownerLastName = parts[2];
                int previousReading = int.Parse(parts[3]);
                int currentReading = int.Parse(parts[4]);
                DateTime date = DateTime.ParseExact(parts[5], "dd.MM.yy", CultureInfo.InvariantCulture);

                apartments[i] = new Apartment(apartmentNumber, address, ownerLastName, previousReading, currentReading, date);
            }

            Apartments = apartments;
            reader.Close();
        }

        public string? ShowApartment(int apartmentNumber)
        {
            return Apartments.FirstOrDefault(a => a.Number == apartmentNumber)?.ToString();
        }

        public string? ShowApartment(string ownerName)
        {
            return Apartments.FirstOrDefault(a => a.OwnerName == ownerName)?.ToString();
        }

        public (string owner, double bill) FindMaxTax(double costOfElectricity)
        {
            Apartment maxTax = Apartments[0];
            foreach (var apartment in Apartments)
            {
                if (apartment.EndReading - apartment.StartReading > maxTax.EndReading - maxTax.StartReading)
                {
                    maxTax = apartment;
                }
            }

            return (maxTax.OwnerName, (maxTax.EndReading - maxTax.StartReading) * costOfElectricity);
        }

        public string? ShowApartmentWithoutElectricity()
        {
            return Apartments.FirstOrDefault(a => a.StartReading == a.EndReading)?.ToString();
        }
    }
}