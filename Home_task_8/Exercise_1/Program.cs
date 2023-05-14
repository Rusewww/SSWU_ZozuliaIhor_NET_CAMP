namespace Exercise_1
{
    public class Program
    {
        //У данному завданні я врахував помилки, розділив клас Simulator, та спробував кикористати Strategy design pattern
        static async Task Main(string[] args)
        {
            int numOfRoads;
            bool isParsed;

            do
            {
                Console.Write("Напишiть кiлькiсть перехресть: ");
                string input = Console.ReadLine();

                isParsed = int.TryParse(input, out numOfRoads);

                if (!isParsed)
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }

            } while (!isParsed);
            
            ControlerCrossroad controlerTrafficLights = new();
            await controlerTrafficLights.CreateCrossroad(numOfRoads);
            await controlerTrafficLights.SetTime();
            await controlerTrafficLights.StartShowCrossroad();
        }
    }
}