using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    public class Graph
    {
        public List<DataPoint> DataPoints { get; set; }

        private int[,] graph;


        public int[,] GetGraph()
        {
            return graph;
        }

        public void SetGraph(int[,] value)
        {
            graph = value;
        }
        public Graph(List<DataPoint> dataPoints, int size)
        {
            DataPoints = dataPoints;
            CreateGraph(dataPoints, size);
        }



        private void CreateGraph(List<DataPoint> dataPoints, int size)
        {
            graph = new int[size, size];

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    foreach (DataPoint data in dataPoints)
                    {
                        if (data.X == i && data.Y == j)
                        {
                            graph[i, j] = 1;
                            break;
                        }
                        else
                        {
                            graph[i, j] = 0;
                        }
                    }
                }
            }
        }

    }
}
