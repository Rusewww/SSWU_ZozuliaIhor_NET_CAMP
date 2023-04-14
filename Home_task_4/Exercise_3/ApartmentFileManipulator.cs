using System;
using System.IO;
using System.Globalization;

namespace Exercise_3
{
    public class ApartmentFileManipulator
    {
        private int _apartmentCount;
        private short _quarter;
        public Apartment[] Apartments;

        public void ReadApartmentsFromFile(string fileName)
        {
            // Відкриваємо файл для зчитування
            StreamReader reader = new StreamReader(fileName);

            // Читаємо перший рядок з файлу, який містить загальну інформацію про квартири та місяць
            string line = reader.ReadLine();
            string[] parts = line.Split(' ');
            _apartmentCount = int.Parse(parts[0]);
            _quarter = short.Parse(parts[1]);

            // Створюємо масив для збереження інформації про квартири
            Apartment[] apartments = new Apartment[_apartmentCount];

            // Читаємо наступні рядки з файлу та заповнюємо масив apartments
            for (int i = 0; i < _apartmentCount; i++)
            {
                line = reader.ReadLine();
                parts = line.Split(' ');
                int apartmentNumber = int.Parse(parts[0]);
                string ownerLastName = parts[1];
                int previousReading = int.Parse(parts[2]);
                int currentReading = int.Parse(parts[3]);
                string dateString = parts[4];

                // Парсимо дату з рядка за допомогою методу ParseExact() та задаємо формат дати dd.MM.yy
                DateTime date = DateTime.ParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                apartments[i] = new Apartment(apartmentNumber, ownerLastName, previousReading, currentReading, date);
            }

            Apartments = apartments;
            reader.Close();
        }
    }
}