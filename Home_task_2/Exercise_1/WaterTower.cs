using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    internal class WaterTower
    {
        private double _maxWaterLevel;
        private double _currentWaterLevel;
        private Pump _waterPump;

        public double CurrentWaterLevel
        {
            get
            {
                return _currentWaterLevel;
            }
            set
            {
                if (Validator.ValidateNumber(value)) _currentWaterLevel = value;
            }
        }
        
        public double MaxWaterLevel
        {
            get
            {
                return _maxWaterLevel;
            }
            set
            {
                if (Validator.ValidateNumber(value)) _maxWaterLevel = value;
            }
        }

        public WaterTower(double maxWaterLevel, Pump waterPump)
        {
            MaxWaterLevel = maxWaterLevel;
            _waterPump = waterPump;
            CurrentWaterLevel = 0;
        }

        public override string ToString()
        {
            return  $"WaterTower: MaxVolume={MaxWaterLevel}, CurrentVolume={CurrentWaterLevel}";
        }
        
        public void UseWater(double water)
        {
            //#TODO: Реалізувати метод викориcтання води користувачем з вежі. 
        }

        public void FillWater()
        {
            //#TODO: реалізувати метод, який буде запускати помпу та заповнювати башту, якщо вона порожня.
        }

        public void ChangePump(Pump pump)
        {
            //#TODO: реалізувати метод, який буде замінювати помпу.
        }
        
    }
}
