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

        public void ReadApartmentsFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);

            string line = reader.ReadLine();
            string[] parts = line.Split(' ');
            _apartmentCount = int.Parse(parts[0]);
            _quarter = short.Parse(parts[1]);
            Apartment[] apartments = new Apartment[_apartmentCount];

            for (int i = 0; i < _apartmentCount; i++)
            {
                line = reader.ReadLine();
                parts = line.Split("; ");
                int apartmentNumber = int.Parse(parts[0]);
                string address = parts[1];
                string ownerLastName = parts[2];
                int previousReading = int.Parse(parts[3]);
                int currentReading = int.Parse(parts[4]);
                string dateString = parts[5];
                DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                apartments[i] = new Apartment(apartmentNumber, address, ownerLastName, previousReading, currentReading,
                    date);
            }

            Apartments = apartments;
            reader.Close();
        }

        public string? ShowApartment(int apartmentNumber)
        {
            foreach (var apartment in Apartments)
            {
                if (apartment.Number == apartmentNumber) return apartment.ToString();
            }

            return null;
        }

        public string? ShowApartment(string ownerName)
        {
            foreach (var apartment in Apartments)
            {
                if (apartment.OwnerName == ownerName) return apartment.ToString();
            }

            return null;
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
            foreach (var apartment in Apartments)
            {
                if (apartment.EndReading - apartment.StartReading == 0) return apartment.ToString();
            }

            return null;
        }

    }
}