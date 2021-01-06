using Project3.Classes;
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

            //int[] xCoords = { 0, 1, 3, 0, 10, 15};
            //int[] yCoords = { 0, 0, 0, 1, 1, 1};

            List<DataPoint> dataPoints = GetDataPoints(xCoords, yCoords);

            Graph graph = new Graph(dataPoints, 100);

            GraphRenderer.RenderGraph(graph);

            Console.ReadLine();
        }
         
        private static void RenderGraph(int[,] graphData)
        {
            for (int i = graphData.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < graphData.GetLength(1); j++)
                {
                    if (graphData[j, i] == 1)
                        Console.Write("x ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine("#" + i + "   ");
            }
        }

        private static int[,] CreateGraph(List<DataPoint> dataPoints, int size)
        {
            int[,] graphData = new int[size, size];

            for (int i = 0; i < graphData.GetLength(0); i++)
            {
                for (int j = 0; j < graphData.GetLength(1); j++)
                {
                    foreach (DataPoint data in dataPoints)
                    {
                        if (data.X == i && data.Y == j)
                        {
                            graphData[i, j] = 1;
                            break;
                        }
                        else
                        {
                            graphData[i, j] = 0;
                        }
                    }
                }
            }

            return graphData;
        }

        private static List<DataPoint> GetDataPoints(int[] xCoords, int[] yCoords)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < xCoords.Length; i++)
            {
                DataPoint dataPoint = new DataPoint(xCoords[i], yCoords[i]);
                dataPoints.Add(dataPoint);
            }

            foreach (DataPoint data in dataPoints)
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
