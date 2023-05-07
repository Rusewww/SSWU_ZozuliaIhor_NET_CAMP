namespace Home_task_7
{
    public class TrafficLights
    {
        private string _color;
        private readonly Simulator _simulator;
        
        public string Color()
        {
            return (string)_color.Clone();
        }
        
        public TrafficLights(string color, Simulator simulator)
        {
            _color = (string)color.Clone();
            _simulator = simulator;
            SubscribeTraffic();
        }

        private void OnColorSwiped(string color) => _color = color;
        private void SubscribeTraffic() => _simulator.SwipeColorEvent += OnColorSwiped;
        public void UnsubscribeTraffic() => _simulator.SwipeColorEvent -= OnColorSwiped;
    }
}