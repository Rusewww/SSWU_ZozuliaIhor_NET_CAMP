namespace Exercise_1.StrategyStandart
{
    public sealed class StrategyStrategyCrossroadStandart : IStrategyCrossroadStandart
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

        public void WriteDirection()
        {
            Console.WriteLine("|----------+---------------+---------------+---------------+---------------|");
            Console.WriteLine("|{0, 10}|{1, 15}|{2, 15}|{3, 15}|{4, 15}|", "Напрям", "Схiд-Захiд", "Захiд-Схiд",
                "Пiвнiч-Пiвдень", "Пiвдень-Пiвнiч");
            Console.WriteLine("|----------+---------------+---------------+---------------+---------------|");
        }

        public void WriteColor(string color)
        {
            string oppositeColor = CheckerColor(color);
            Console.WriteLine("|{0, 10}|{1, 15}|{2, 15}|{3, 15}|{4, 15}|", "Колiр", color, color, oppositeColor,
                oppositeColor);
        }
    }
}