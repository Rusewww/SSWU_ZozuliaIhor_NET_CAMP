namespace Home_task_7
{
    public class TrafficLightsColors : ITrafficLight
    {
        public void WriteColor(string color)
        {
            string oppositeColor = color switch
            {
                "Зелений" => "Червоний",
                "Червоний" => "Зелений",
                _ => "Жовтий",
            };
            
            Console.WriteLine("|{0, 10}|{1, 15}|{2, 15}|{3, 15}|{4, 15}|", "Колiр", color, color, oppositeColor, oppositeColor);
        }
    }
}