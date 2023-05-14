namespace Exercise_1.StrategyArrowed
{
    public class StrategyStrategyCrossroadArrowed : IStrategyCrossroadArrowed
    {
        private string CheckerColor(string color)
        {
            return color switch
            {
                "Зелений" => "Червоний",
                "Червоний" => "Зелений",
                _ => "Жовтий",
            };
        }

        public void WriteDirection(string direction)
        {
            Console.WriteLine("|----------+---------------+---------------+---------------+---------------+---------------|");
            Console.WriteLine("|{0, 10}|{1, 15}|{2, 15}|{3, 15}|{4, 15}|{5, 15}|", "Напрям", "Схiд-Захiд", "Захiд-Схiд", "Пiвнiч-Пiвдень", "Пiвдень-Пiвнiч", "Стрiлка " + direction);
            Console.WriteLine("|----------+---------------+---------------+---------------+---------------+---------------|");
        }

        public void WriteColor(string color, string colorArrow)
        {
            var oppositeColor = CheckerColor(color);
            Console.WriteLine("|{0, 10}|{1, 15}|{2, 15}|{3, 15}|{4, 15}|{5, 15}|", "Колiр", color, color, oppositeColor,
                oppositeColor, colorArrow);
        }
    }
}