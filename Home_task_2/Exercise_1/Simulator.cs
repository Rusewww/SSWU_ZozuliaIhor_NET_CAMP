using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class Simulator
    {
        //Поля класу відображабть роботу однієї помпи для кількох користувачів.
        private WaterTower _waterTower;
        private User[] _users;
// хто створює ці об'єкти. Хто керує часом.Як контролюється рівень води в вежі?
        protected Simulator(WaterTower waterTower, User[] users)
        {
            _waterTower = waterTower;
            _users = users;
        }

        public void Simulation(double timeOfSimulation)
        {
            //#TODO: Метод який буде запускати симуляцію, та контролювати використання водонапорної вежі декількома користувачами.
        }
    }
}
