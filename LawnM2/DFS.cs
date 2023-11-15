using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnM2
{
    internal class DFS : Robot
    {
        private bool[,] visited;
        private string[,] garden;

        public DFS(int startX, int startY) : base(startX, startY)
        {
        }

        public override void Cut(string[,] garden)
        {
            this.garden = garden;
            visited = new bool[garden.GetLength(0), garden.GetLength(1)];
            Explore(posX, posY);
        }

        protected override void Explore(int x, int y)
        {
            if (!IsValidMove(x, y))
            {
                return;
            }
            visited[x, y] = true;
            garden[x, y] = "x ";
            DecreaseBattery(0.5);
            Garden.PrintGarden(garden);
            System.Threading.Thread.Sleep(50);
            garden[x, y] = "- ";
            Explore(x + 1, y);
            Explore(x - 1, y);
            Explore(x, y + 1);
            Explore(x, y - 1);


        }

        private bool IsValidMove(int x, int y)
        {
            return x >= 0 && y >= 0 && x < garden.GetLength(0) && y < garden.GetLength(1)
                && !visited[x, y] && garden[x, y] != "0 " && BatteryLife > 0;
        }

    }
}
