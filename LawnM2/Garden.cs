using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnM2
{
    internal class Garden
    {
        public static string[,] MakeGarden(int x, int y, int maxObstacles)
        {
            string[,] garden = new string[x, y];
            Random random = new Random();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    garden[i, j] = "~ ";
                }
            }

            int obstaclesPlaced = 0;
            while (obstaclesPlaced < maxObstacles)
            {
                int randomX = random.Next(x);
                int randomY = random.Next(y);

                if (garden[randomX, randomY] == "~ ")
                {
                    garden[randomX, randomY] = "0 ";
                    obstaclesPlaced++;
                }
            }

            return garden;
        }

        public static void ShowGarden(string[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
