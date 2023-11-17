using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnM2
{
    internal class BFS : Robot
    {
        public BFS(int startX, int startY) : base(startX, startY)
        {
        }

        public override void Cut(string[,] garden)
        {
            this.garden = garden;
            visited = new bool[garden.GetLength(0), garden.GetLength(1)];

            var queue = new Queue<(int, int)>();
            queue.Enqueue((posX, posY));

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                if (!IsValidMove(x, y)) continue;

                visited[x, y] = true;
                garden[x, y] = "<#>";
                Garden.PrintGarden(garden);
                System.Threading.Thread.Sleep(100);
                garden[x, y] = "...";
                DecreaseBattery(0.1);
                DisplayBattery();

                EnqueueNeighbors(queue, x, y);
            }
        }

        private void EnqueueNeighbors(Queue<(int, int)> queue, int x, int y)
        {
            EnqueueIfValid(queue, x + 1, y);
            EnqueueIfValid(queue, x - 1, y);
            EnqueueIfValid(queue, x, y + 1);
            EnqueueIfValid(queue, x, y - 1);
        }

        private void EnqueueIfValid(Queue<(int, int)> queue, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < garden.GetLength(0) && y < garden.GetLength(1) && !visited[x, y])
            {
                queue.Enqueue((x, y));
            }
        }
    }
}
