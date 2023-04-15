
namespace Exercise_3
{
    public class Apartment
    {
        private int _number;
        private string _address;
        private string _ownerName;
        private int _startReading;
        private int _endReading;
        private DateTime _readingDate;

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }
        
        public string OwnerName
        {
            get
            {
                return _ownerName;
            }

            set
            {
                _ownerName = value;
            }
        }
        
        public int StartReading
        {
            get
            {
                return _startReading;
            }

            set
            {
                _startReading = value;
            }
        }
        
        public int EndReading
        {
            get
            {
                return _endReading;
            }

            set
            {
                _endReading = value;
            }
        }
        
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }
        
        public DateTime ReadingDate
        {
            get
            {
                return _readingDate;
            }

            set
            {
                _readingDate = value;
            }
        }
        
        public Apartment(int number,string address, string ownerName, int startReading, int endReading, DateTime readingDate)
        {
            _number = number;
            _address = address;
            _ownerName = ownerName;
            _startReading = startReading;
            _endReading = endReading;
            _readingDate = readingDate;
        }

        public override string ToString()
        {
            return ($"Number: {_number}; Address: {_address}; Owner: {_ownerName}; Last: {_startReading}; Now: {_endReading}; {_readingDate.ToString("MMMM")}: {_readingDate.ToString("dd.MM.yy")}");
        }

        public (double bill, int flat) GetBillCost(double costOfElectricity)
        {
            return ((EndReading - StartReading) * costOfElectricity, Number);
        }
    }
}