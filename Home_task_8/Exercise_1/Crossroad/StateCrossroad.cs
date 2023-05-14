using Exercise_1.StrategyStandart;
using Exercise_1.StrategyArrowed;

namespace Exercise_1
{
    public class StateCrossroad
    {
        private List<Crossroad> _baseCrossroads = new List<Crossroad>();
        private readonly ControlerCrossroad _controlerTrafficLights;

        public StateCrossroad(ControlerCrossroad controlerTrafficLights)
        {
            _controlerTrafficLights = controlerTrafficLights;
        }

        public void AddCrossroad(Crossroad crossroad)
        {
            _baseCrossroads.Add(crossroad);
        }

        public async Task Initialize(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                int numStrategy = GetNumStrategy(i);
                await SetStrategy(numStrategy, i);
            }
        }

        public async Task SetTime()
        {
            foreach (var crossroad in _baseCrossroads)
            {
                await crossroad.PrintRoadNumber();
                int time = GetTimeCrossroad();
                await crossroad.InitTime(time);
            }
        }

        public async Task Start()
        {
            Task[] tasks = new Task[_baseCrossroads.Count];
            for (int i = 0; i < _baseCrossroads.Count; i++)
            {
                tasks[i] = _baseCrossroads[i].Start();
            }

            await Task.WhenAll(tasks);
        }

        private int GetTimeCrossroad()
        {
            Console.WriteLine("Введiть скiльки, часу буде тривати змiна кольору зелений-зелений: ");
            int time = Convert.ToInt32(Console.ReadLine());
            if (time <= 0)
            {
                throw new ArgumentException("Неправильне значення часу.");
            }

            return time;
        }

        private async Task SetStrategy(int numStrategy, int roadNumber)
        {
            Crossroad crossroad;
            switch (numStrategy)
            {
                case 1:
                    crossroad = new CrossroadStandart(roadNumber, _controlerTrafficLights);
                    break;
                case 2:
                    string direction = GetRandomDirection();
                    crossroad = new CrossroadArrowed(roadNumber, _controlerTrafficLights, direction);
                    break;
                default:
                    throw new ArgumentException("Неправильне значення стратегії.");
            }

            AddCrossroad(crossroad);
        }

        private int GetNumStrategy(int roadNumber)
        {
            Console.WriteLine($"Дорога {roadNumber}:");
            Console.WriteLine("Обери тип свiтлофорiв: 1 - Без стрiлки; 2 - Зi стрiлкою");
            int numStrategy = Convert.ToInt32(Console.ReadLine());
            if (numStrategy != 1 && numStrategy != 2)
            {
                throw new ArgumentException("Неправильне значення стратегії.");
            }

            return numStrategy;
        }

        private string GetRandomDirection()
        {
            string[] directions = {"Направо", "Налiво"};
            Random random = new Random();
            int randomIndex = random.Next(directions.Length);
            return directions[randomIndex];
        }
    }
}