﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class User
    {
        private int _id = 0;
        private double _waterConsumption;

        public User(double waterConsumption)
        {
            _id += 1;
            _waterConsumption = waterConsumption;
        }
        
        //Функція яка використовує воду з башти
        private void WaterUse(double countOfWater)
        {
            //#TODO: Реалізувати медод який буде викликати функцію useWater з класу Башти імітуючи використання води.
        }

        public void TakeShower(double time)
        {
            //#TODO: Реалізувати функцію прийняття душу користувачем, яка буде викликати метод WaterUse. ?Додати коофіцієнт витрати води?
        }
        
        //#TODO: Реалізувати функції подібні до TakeShower, які будуть імітувати використання води реальним користувачем для різних цілей.
        
        public override string ToString()
        {
            return  $"Користувач {_id}: Cереднє використання води:{_waterConsumption}.";
        }
    }
}
