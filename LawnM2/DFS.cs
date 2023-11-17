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
            if (!IsValidMove(x, y))
            {
                return;
            }
            visited[x, y] = true;
            pathStack.Push((x, y));
            garden[x, y] = "<#>";
            Garden.PrintGarden(garden);
            System.Threading.Thread.Sleep(100);
            garden[x, y] = "...";
            DecreaseBattery(0.1);
            DisplayBattery();
            Explore(x + 1, y);
            Explore(x - 1, y);
            Explore(x, y + 1);
            Explore(x, y - 1);
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
                garden[prevX, prevY] = "<#>"; 
                Garden.PrintGarden(garden);
                System.Threading.Thread.Sleep(100);
                garden[prevX, prevY] = "...";
                DecreaseBattery(0.1);
                DisplayBattery();
                if (HasUnexploredAdjacent(prevX, prevY))
                {
                    var nextCell = FindNextUnvisitedAdjacent(prevX, prevY);
                    if (nextCell != null)
                    {
                        Explore(nextCell.Value.x, nextCell.Value.y);
                        break;
                    }
                }

            }
        }

        private (int x, int y)? FindNextUnvisitedAdjacent(int x, int y)
        {
            if (IsValidMove(x, y - 1) && !visited[x, y - 1])
                return (x, y - 1);

            if (IsValidMove(x, y + 1) && !visited[x, y + 1])
                return (x, y + 1);

            if (IsValidMove(x - 1, y) && !visited[x - 1, y])
                return (x - 1, y);

            if (IsValidMove(x + 1, y) && !visited[x + 1, y])
                return (x + 1, y);

            return null;
        }

        private bool IsDeadEnd(int x, int y)
        {
            return !(IsValidMove(x, y + 1) || IsValidMove(x, y - 1) ||
                     IsValidMove(x - 1, y) || IsValidMove(x + 1, y));
        }
        private bool HasUnexploredAdjacent(int x, int y)
        {
            return IsValidMove(x + 1, y) || IsValidMove(x - 1, y) ||
                   IsValidMove(x, y + 1) || IsValidMove(x, y - 1);
        }
    }
}