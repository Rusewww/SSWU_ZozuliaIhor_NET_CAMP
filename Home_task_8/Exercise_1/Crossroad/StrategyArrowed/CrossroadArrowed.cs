using System.Globalization;

namespace Exercise_1.StrategyArrowed
{
    public class CrossroadArrowed : Crossroad
    {
        private readonly TrafficLight _trafficLight;
        private readonly ControlerCrossroad _controlerTrafficLights;
        private readonly ConnectTrafficLightToCrossroad _connectTrafficLightToCrossroad;
        private string _color = "Червоний";
        private string _direction;
        private string _arrowColor = "Зелений";
        private int _delayRedAndGreen;
        private int _delayYellow;

        public CrossroadArrowed(int number, ControlerCrossroad controlerTrafficLights, string direction) : base(number)
        {
            _controlerTrafficLights = controlerTrafficLights;
            _trafficLight = new TrafficLight("Червоний", _controlerTrafficLights);
            _connectTrafficLightToCrossroad =
                new ConnectTrafficLightToCrossroad(new StrategyStrategyCrossroadArrowed(), _trafficLight);
            _direction = direction;
        }

        public override async Task Start()
        {
            int timeSeconds = Time * 1000;
            _delayRedAndGreen = (int) (timeSeconds * 0.75);
            _delayYellow = (int) (timeSeconds * 0.25);

            while (!Console.KeyAvailable)
            {
                if (_color == "Червоний")
                {
                    await ColorTimer(_delayRedAndGreen, "Червоний", _direction, _arrowColor);
                    await ColorTimer(_delayYellow, "Жовтий", _direction, "Жовтий");
                    _color = "Зелений";
                    if (_arrowColor == "Зелений") _arrowColor = "Червоний";
                    else _arrowColor = "Зелений";
                }
                else if (_color == "Зелений")
                {
                    await ColorTimer(_delayRedAndGreen, "Зелений", _direction, _arrowColor);
                    await ColorTimer(_delayYellow, "Жовтий", _direction, "Жовтий");
                    _color = "Червоний";
                    if (_arrowColor == "Червоний") _arrowColor = "Зелений";
                    else _arrowColor = "Червоний";
                }
            }
        }

        private async Task ColorTimer(int time, string color, string arrowState, string colorArrow)
        {
            await PrintRoadNumber();
            arrowState = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(arrowState).Trim();
            _controlerTrafficLights.SetColorTrafficLights(color);
            _connectTrafficLightToCrossroad.WriteDirectionArrow(arrowState);
            _connectTrafficLightToCrossroad.WriteColorArrow(colorArrow);
            await Task.Delay(time);
        }
    }
}