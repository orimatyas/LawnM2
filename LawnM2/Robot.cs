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
        internal double totalEnergyUsed = 0;
        protected bool[,] visited;
        protected string[,] garden;

        protected Robot(int startX, int startY)
        {
            posX = startX;
            posY = startY;
        }

        public abstract void Cut(string[,] arr);

        protected bool IsValidMove(int x, int y)
        {
            return x >= 0 && y >= 0 && x < garden.GetLength(0) && y < garden.GetLength(1)
                && !visited[x, y] && garden[x, y] != "0 " && BatteryLife > 0;
        }
        protected double BatteryLife
        {
            get
            {
                return battery;
            }
            set
            {
                battery = Math.Max(value, 0);
            }
        }
        protected void DecreaseBattery(double b)
        {
            double previousBatteryLife = BatteryLife;
            BatteryLife -= b;
            totalEnergyUsed += previousBatteryLife - BatteryLife;
            if (BatteryLife <= 0)
            {
                CheckForRecharge();
            }
        }
        protected void CheckForRecharge()
        {
                Console.WriteLine("Recharge battery");
                double rechargedAmount = Helpers.RechargeDoubleValidation(0, 100);
                totalEnergyUsed += (100 - rechargedAmount);
                battery = rechargedAmount;
        }
        protected void DisplayBattery()
        {
            Console.WriteLine($"Current battery health: {battery}%");
        }

        internal void OverallConsumption()
        {
            Console.WriteLine($"Overall energy used: {totalEnergyUsed}%");
        }
    }
}
