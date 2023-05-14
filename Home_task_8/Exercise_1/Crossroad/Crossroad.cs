namespace Exercise_1
{
    public abstract class Crossroad
    {
        private int _number;
        private int _time;

        public int Number
        {
            get { return _number;}
            set { _number = value;}
        }

        public int Time
        {
            get { return _time;}
            set { _time = value;}
        }

        public abstract Task Start();

        protected Crossroad(int number)
        {
            this._number = number;
        }

        public async Task PrintRoadNumber()
        {
            Console.WriteLine($"Дорога {Number}:");
        }

        public async Task InitTime(int time)
        {
            this.Time = time;
        }
    }
}