﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnM2
{
    internal class Helpers
    {
        internal static int height = 10;
        internal static int width = 10;
        internal static int maxObstacles = 2;
        internal static string selectedMethod = "DFS";
        internal static int methodNumber = 0;

        internal static void ShowMenu()
        {
            bool isMenuOn = true;
            do
            {
                Console.WriteLine("---Lawn Mower v2---");
                Console.WriteLine(@"Options:
S - Start Simulation
G - Garden
L _ Lawn Mower
Q - Quit Game");
                var optSelected = Console.ReadLine();
                switch (optSelected.Trim().ToLower())
                {
                    case "s":
                        Console.Clear();
                        string[,] garden = Garden.MakeGarden(height, width, maxObstacles);
                        Garden.ShowGarden(garden);
                        var (startX, startY)  = FindValidStartPosition(garden);
                        Console.WriteLine("Press any key to start..");
                        Console.ReadKey();
                        if (methodNumber == 0)
                        {
                            DFS dfsRobot = new DFS(startX, startY);
                            dfsRobot.Cut(garden);
                            dfsRobot.OverallConsumption();
                        }
                        else if (methodNumber == 1)
                        {
                            BFS bfsRobot = new BFS(startX, startY);
                            bfsRobot.Cut(garden);
                            bfsRobot.OverallConsumption();
                        }
                        else if (methodNumber == 2)
                        {
                            Astar astarRobot = new Astar(startX, startY);
                            astarRobot.Cut(garden);
                            astarRobot.OverallConsumption();
                        }
                        break;
                    case "g":
                        Console.Clear();
                        Helpers.GardenOptions();
                        break;
                    case "l":
                        Console.Clear();
                        Helpers.MowerOptions();
                        break;
                    case "q":
                        isMenuOn = false;
                        break;
                    default:
                        isMenuOn = true;
                        Console.Clear();
                        break;
                }

            }
            while (isMenuOn);
        }
        private static void GardenOptions()
        {
            bool optionsOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine($@"Options:
H - Height: {height}
W - Width: {width}
O - Number of obstacels: {maxObstacles}");

                var optSelected = Console.ReadLine();

                switch (optSelected.Trim().ToLower())
                {
                    case "h":
                        Console.Clear();
                        Console.WriteLine("Enter the height of the garden");
                        
                        height = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "w":
                        Console.Clear();
                        Console.WriteLine("Enter the width of the garden");
                        width = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "o":
                        Console.Clear();
                        Console.WriteLine("Enter the the number of obstacles");
                        maxObstacles = Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        optionsOn = false;
                        Console.Clear();
                        break;

                }
            }
            while (optionsOn);
        }
        private static void MowerOptions()
        {
            bool optionsOn = true;
            do
            {
                Console.Clear();
                Console.WriteLine($@"Which method should the robot use:
D - DFS
B - BFS
A - Algorithm*
Currently in use: {selectedMethod}");

                var optSelected = Console.ReadLine();

                switch (optSelected.Trim().ToLower())
                {
                    case "d":
                        methodNumber = 0; 
                        selectedMethod = "DFS";
                        break;
                    case "b":
                        methodNumber = 1;
                        selectedMethod = "BFS";
                        break;
                    case "a":
                        methodNumber = 2; 
                        selectedMethod = "Algorithm*";
                        break;
                    default:
                        optionsOn = false;
                        Console.Clear();
                        break;

                }
            }
            while (optionsOn);
        }
        public static (int, int) FindValidStartPosition(string[,] garden)
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    if (garden[i, j] != "0 ")
                    {
                        return (i, j);
                    }
                }
            }

            throw new InvalidOperationException("No valid starting point found in the garden.");
        }

    }
}
