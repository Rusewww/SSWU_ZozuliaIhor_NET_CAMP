using Exercise_1.StrategyStandart;
using Exercise_1.StrategyArrowed;

namespace Exercise_1
{
    public class ConnectTrafficLightToCrossroad
    {
        private readonly TrafficLight _trafficLight;
        private readonly IStrategyCrossroadStandart _strategyTrafficLights;
        private readonly IStrategyCrossroadArrowed _strategyTrafficLightsArrowed;

        public ConnectTrafficLightToCrossroad(IStrategyCrossroadStandart strategyTrafficLights, TrafficLight trafficLight)
        {
            _strategyTrafficLights = strategyTrafficLights;
            _trafficLight = trafficLight;
        }

        public ConnectTrafficLightToCrossroad(IStrategyCrossroadArrowed strategyTrafficLightsArrowed, TrafficLight trafficLight)
        {
            _strategyTrafficLightsArrowed = strategyTrafficLightsArrowed;
            _trafficLight = trafficLight;
        }

        public void WriteColor()
        {
            _strategyTrafficLights.WriteColor(_trafficLight.Color());
        }

        public void WriteDirection()
        {
            _strategyTrafficLights.WriteDirection();
        }

        public void WriteColorArrow(string colorArrow)
        {
            _strategyTrafficLightsArrowed.WriteColor(_trafficLight.Color(), colorArrow);
        }

        public void WriteDirectionArrow(string arrowState)
        {
            _strategyTrafficLightsArrowed.WriteDirection(arrowState);
        }
    }
}