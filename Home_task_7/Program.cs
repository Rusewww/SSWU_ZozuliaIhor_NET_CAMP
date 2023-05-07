namespace Home_task_7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var simulator = new Simulator(new TrafficLightsColors());

                Console.Write("Введiть скiльки, часу буде тривати змiна кольору зелений-зелений: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out var time) || time <= 0)
                {
                    throw new ArgumentException("Неправильне значення часу.");
                }

                await simulator.Start(time);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка: {ex.Message}");
            }
        }
    }
}