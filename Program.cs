﻿using Project3.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] xCoords = { 25, 34, 22, 27, 33, 33, 31, 22, 35, 34, 67, 54, 57, 43, 50, 57, 59, 52, 65, 47, 49, 48, 35, 33, 44, 45, 38, 43, 51, 46, 0, 99 };
            int[] yCoords = { 79, 51, 53, 78, 59, 74, 73, 57, 69, 75, 51, 32, 40, 47, 53, 36, 35, 58, 59, 50, 25, 20, 14, 12, 20, 5, 29, 27, 8, 7, 0, 99 };

            List<IDataPoint> dataPoints = GetDataPoints(xCoords, yCoords);

            Graph graph = new Graph(dataPoints, 100);

            GraphRenderer.RenderGraph(graph);

            Algorithme algorithme = new Algorithme(2, graph);

            algorithme.UpdateCentroids();
            GraphRenderer.RenderGraph(algorithme.Graph);

            algorithme.UpdateCentroids();
            GraphRenderer.RenderGraph(algorithme.Graph);

            Console.ReadLine();
        }

        private static List<IDataPoint> GetDataPoints(int[] xCoords, int[] yCoords)
        {
            List<IDataPoint> dataPoints = new List<IDataPoint>();

            for (int i = 0; i < xCoords.Length; i++)
            {
                DataPoint dataPoint = new DataPoint(xCoords[i], yCoords[i]);
                dataPoints.Add(dataPoint);
            }

            foreach (IDataPoint data in dataPoints)
            {
                Console.Write("X: " + data.X + "   Y: " + data.Y);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            return dataPoints;
        }
    }
}
