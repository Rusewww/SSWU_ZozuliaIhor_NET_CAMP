﻿namespace Home_task_7
{
    public class Simulator
    {// Недоліком Вашої програми є те, що у вас один клас виконує і візуалізацію результату і керівництво логікою переключення.
        public event Action<string> SwipeColorEvent;
        private readonly ITrafficLight _iTrafficLights;
        private readonly TrafficLights _trafficLights;

        public Simulator(ITrafficLight iTrafficLights)
        {
            _iTrafficLights = iTrafficLights;
            _trafficLights = new TrafficLights("Червоний", this);
        }

        public async Task Start(int time)
        {// Ці константи мають бути не вкоді методу.
            int timeSeconds = time * 1000;
            int delayRedAndGreen = (int)(timeSeconds * 0.75);
            int delayYellow = (int)(timeSeconds * 0.25);

            Console.WriteLine("|----------|---------------|---------------|---------------|---------------|");
            Console.WriteLine("|{0, 10}|{1, 15}|{2, 15}|{3, 15}|{4, 15}|", "Свiтлофор", "Схiд-Захiд", "Захiд-Схiд", "Пiвнiч-Пiвдень", "Пiвдень-Пiвнiч");
            Console.WriteLine("|----------|---------------|---------------|---------------|---------------|");

            bool roadGo = false;
            while (!Console.KeyAvailable)
            {
                roadGo = !roadGo;
                SetColorTrafficLights(roadGo ? "Зелений" : "Червоний");
                await Task.Delay(delayRedAndGreen);
                SetColorTrafficLights("Жовтий");
                await Task.Delay(delayYellow);
            }

            _trafficLights.UnsubscribeTraffic();
            Console.ReadKey(true);
            Console.WriteLine("|----------|---------------|---------------|---------------|---------------|");
        }

        private void SetColorTrafficLights(string color)
        {
            SwipeColorEvent?.Invoke(color);
            _iTrafficLights.WriteColor(_trafficLights.Color());
        }
    }
}
