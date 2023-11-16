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
            Garden.PrintGarden(garden);
            System.Threading.Thread.Sleep(500);
            garden[x, y] = "- ";
            DecreaseBattery(1);
            DisplayBattery();
            List<(int, int)> nextMoves = GetNextMoves(x, y);
            foreach (var (nextX, nextY) in nextMoves)
            {
                if (!visited[nextX, nextY])
                {
                    Explore(nextX, nextY);
                }
            }

            garden[x, y] = "- ";
        }

        private List<(int, int)> GetNextMoves(int x, int y)
        {
            var moves = new List<(int, int)>();
            // Check and add all possible moves (down, up, left, right) if they are within bounds
            if (y + 1 < garden.GetLength(1)) moves.Add((x, y + 1)); // Down
            if (y - 1 >= 0) moves.Add((x, y - 1)); // Up
            if (x - 1 >= 0) moves.Add((x - 1, y)); // Left
            if (x + 1 < garden.GetLength(0)) moves.Add((x + 1, y)); // Right
            return moves;
        }
    }

}