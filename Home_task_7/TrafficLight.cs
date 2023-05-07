namespace Home_task_7
{
    public enum LightColor
    {
        Red,
        Yellow,
        Green
    }

    public class TrafficLight : ITrafficLight
    {
        private LightColor northSouthColor;
        private LightColor eastWestColor;

        public event EventHandler StateChanged;

        public LightColor NorthSouthColor
        {
            get { return northSouthColor; }
            set
            {
                if (northSouthColor != value)
                {
                    northSouthColor = value;
                    OnStateChanged();
                }
            }
        }

        public LightColor EastWestColor
        {
            get { return eastWestColor; }
            set
            {
                if (eastWestColor != value)
                {
                    eastWestColor = value;
                    OnStateChanged();
                }
            }
        }

        public void Update(int secondsElapsed)
        {
            // TODO: Implement traffic light timing logic here
        }

        protected virtual void OnStateChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}