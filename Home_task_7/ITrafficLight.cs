namespace Home_task_7
{
    public class ITrafficLight
    {
        event EventHandler<StateChangedEventArgs> StateChanged;

        void Update(TimeSpan elapsedTime);
    }
}