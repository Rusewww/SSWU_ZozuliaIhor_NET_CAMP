namespace Exercise_1
{
    public class TrafficLight
    {
        private string _color;
        private readonly ControlerCrossroad _simulator;

        public string Color()
        {
            return (string) _color.Clone();
        }

        public TrafficLight(string color, ControlerCrossroad simulator)
        {
            _color = (string) color.Clone();
            _simulator = simulator;
            SubscribeTraffic();
        }

        private void ColorSwipe(string color) => _color = color;
        private void SubscribeTraffic() => _simulator.SwipeColorEvent += ColorSwipe;
        public void UnsubscribeTraffic() => _simulator.SwipeColorEvent -= ColorSwipe;
    }
}