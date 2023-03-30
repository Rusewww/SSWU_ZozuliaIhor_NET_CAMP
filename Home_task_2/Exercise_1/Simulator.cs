using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class Simulator
    {
        private WaterTower _waterTower;
        private User[] _users;

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
