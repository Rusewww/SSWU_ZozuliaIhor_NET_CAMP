using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class Pump
    {
        private readonly int _efficiency;
        private double _power;

        public double Power
        {
            get
            {
                return Power;
            }
            set
            {
                if (Validator.ValidateNumber(value)) _power = value;
            }
        }

        public Pump(double power, int efficiency)
        {
            Power = power;
            if (Validator.ValidateEfficiency(efficiency)) _efficiency = efficiency;
        }

        public double StartPump(double water)
        {
            //#TODO: Реалізувати метод, який буде запускати помпу для заповнення башти, та повертати інформацію про час витрачений на це.
            return water/(_power*_efficiency);
        }
    }
}
