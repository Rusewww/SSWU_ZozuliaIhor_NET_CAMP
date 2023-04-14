
namespace Exercise_3
{
    public class Apartment
    {
        public int Number { get; set; }
        public string OwnerName { get; set; }
        public int StartReading { get; set; }
        public int EndReading { get; set; }
        public DateTime ReadingDate { get; set; }

        public Apartment(int number, string ownerName, int startReading, int endReading, DateTime readingDate)
        {
            Number = number;
            OwnerName = ownerName;
            StartReading = startReading;
            EndReading = endReading;
            ReadingDate = readingDate;
        }

        public override string ToString()
        {
            return ("Number: " + Number + "; Owner: " + OwnerName + "; Last: " + StartReading + "; Now:" + EndReading + "; Date: " + ReadingDate);
        }
    }
}