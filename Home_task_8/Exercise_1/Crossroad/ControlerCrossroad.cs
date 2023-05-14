namespace Exercise_1
{
    public class ControlerCrossroad
    {
        public event Action<string> SwipeColorEvent;

        private readonly StateCrossroad _stateCrossroad;

        public ControlerCrossroad()
        {
            _stateCrossroad = new StateCrossroad(this);
        }

        public void SetColorTrafficLights(string color)
        {
            SwipeColorEvent.Invoke(color);
        }

        public async Task CreateCrossroad(int count)
        {
            await _stateCrossroad.Initialize(count);
        }

        public async Task SetTime()
        {
            await _stateCrossroad.SetTime();
        }

        public async Task StartShowCrossroad()
        {
            await _stateCrossroad.Start();
        }
    }
}