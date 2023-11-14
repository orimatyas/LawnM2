using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnM2
{
    public abstract class Robot
    {
        private double battery = 100;
        public double BatteryLife
        {
            get
            {
                return battery;
            }
            set
            {
                if (value >= 0)
                {
                    battery = value;
                }
                else
                {
                    throw new Exception("Recharge battery");
                }
            }
        }
        public abstract void Cut(string[,] arr);
        public void DecreaseBattery(double b)
        {
            try
            {
                BatteryLife = BatteryLife - b;
            }
            catch
            {
                Console.WriteLine("Recharge battery");
                BatteryLife = 100;
                Console.ReadKey();
            }
        }
    }
}
