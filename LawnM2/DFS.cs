using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnM2
{
    internal class DFS : Robot
    {
        public DFS(int startX, int startY) : base(startX, startY)
        {
        }

        public override void Cut(string[,] garden)
        {
            this.garden = garden;
            visited = new bool[garden.GetLength(0), garden.GetLength(1)];
            Explore(posX, posY);
        }

        protected void Explore(int x, int y)
        {
            if (!IsValidMove(x, y))
            {
                return;
            }
            visited[x, y] = true;
            garden[x, y] = "x ";
            DecreaseBattery(0.5);
            Garden.PrintGarden(garden);
            DisplayBattery();
            System.Threading.Thread.Sleep(50);
            garden[x, y] = "- ";
            Explore(x + 1, y);
            Explore(x - 1, y);
            Explore(x, y + 1);
            Explore(x, y - 1);
        }
    }
}
