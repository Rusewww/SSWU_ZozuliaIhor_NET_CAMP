namespace Exercise_1.StrategyStandart
{
    public class CrossroadStandart : Crossroad
    {
        private readonly TrafficLight _trafficLight;
        private readonly ControlerCrossroad _controlerTrafficLights;
        private readonly ConnectTrafficLightToCrossroad _connectTrafficLightToCrossroad;
        private string _color = "Червоний";
        private int _delayRedAndGreen;
        private int _delayYellow;

        public CrossroadStandart(int number, ControlerCrossroad controlerTrafficLights) : base(number)
        {
            _controlerTrafficLights = controlerTrafficLights;
            _trafficLight = new TrafficLight("Червоний", _controlerTrafficLights);
            _connectTrafficLightToCrossroad = new ConnectTrafficLightToCrossroad(new StrategyStrategyCrossroadStandart(), _trafficLight);
        }

        public override async Task Start()
        {
            int timeSeconds = Time * 1000;
            _delayRedAndGreen = (int)(timeSeconds * 0.75);
            _delayYellow = (int)(timeSeconds * 0.25);

            while (!Console.KeyAvailable)
            {
                if (_color == "Червоний")
                {
                    await ColorTimer(_delayRedAndGreen, "Червоний");
                    await ColorTimer(_delayYellow, "Жовтий");
                    _color = "Зелений";
                }
                else if (_color == "Зелений")
                {
                    await ColorTimer(_delayRedAndGreen, "Зелений");
                    await ColorTimer(_delayYellow, "Жовтий");
                    _color = "Червоний";
                }
            }
        }

        private async Task ColorTimer(int time, string color)
        {
            await PrintRoadNumber();
            _controlerTrafficLights.SetColorTrafficLights(color);
            _connectTrafficLightToCrossroad.WriteDirection();
            _connectTrafficLightToCrossroad.WriteColor();
            await Task.Delay(time);
        }
    }
}