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

        protected Stack<(int x, int y)> pathStack = new Stack<(int x, int y)>();

        protected void Explore(int x, int y)
        {
            if (!IsValidMove(x, y) || visited[x, y])
            {
                return;
            }
            visited[x, y] = true;
            pathStack.Push((x, y));
            garden[x, y] = "x ";
            Garden.PrintGarden(garden);
            System.Threading.Thread.Sleep(150);
            garden[x, y] = "- ";
            DecreaseBattery(1);
            DisplayBattery();
            ExploreAdjacent(x + 1, y);
            ExploreAdjacent(x - 1, y);
            ExploreAdjacent(x, y + 1);
            ExploreAdjacent(x, y - 1);
            if (IsDeadEnd(x, y))
            {
                Backtrack();
            }
        }

        private void Backtrack()
        {
            while (pathStack.Count > 0)
            {
                var (prevX, prevY) = pathStack.Pop();
                garden[prevX, prevY] = "x "; 
                Garden.PrintGarden(garden);
                System.Threading.Thread.Sleep(150);
                garden[prevX, prevY] = "- ";
                if (!IsDeadEnd(prevX, prevY))
                {
                    Explore(prevX, prevY);
                    break;
                }
            }
        }

        protected void ExploreAdjacent(int x, int y)
        {
            if (IsValidMove(x, y))
            {
                Explore(x, y);
            }
        }

        private bool IsDeadEnd(int x, int y)
        {
            return !(IsValidMove(x, y + 1) || IsValidMove(x, y - 1) ||
                     IsValidMove(x - 1, y) || IsValidMove(x + 1, y));
        }

    }
}