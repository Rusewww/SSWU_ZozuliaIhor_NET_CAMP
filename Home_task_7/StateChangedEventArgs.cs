namespace Home_task_7
{
    public class StateChangedEventArgs : EventArgs
    {
        public TrafficLightColor NorthSouthColor { get; set; }
        public TrafficLightColor EastWestColor { get; set; }
    }
}