using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnM2
{
    public abstract class Robot
    {
        protected int posX;
        protected int posY;
        protected double battery = 100;
        protected Robot(int startX, int startY)
        {
            posX = startX;
            posY = startY;
        }

        protected double BatteryLife
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
        protected void DecreaseBattery(double b)
        {
            BatteryLife = BatteryLife - b;
            CheckForRecharge();
        }

        protected void CheckForRecharge()
        {
            if (battery <= 0)
            {
                Console.WriteLine("Recharge battery");
                battery = Convert.ToInt32(Console.ReadLine());
            }
        }

        protected abstract void Explore(int x, int y);
    }
}
