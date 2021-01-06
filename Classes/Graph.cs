using Project3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    public class Graph
    {
        public List<IDataPoint> DataPoints { get; set; }
        public List<Centroid> Centroids { get; set; }

        private int[,] _graph;
        private int _size;


        public int[,] GetGraph()
        {
            return _graph;
        }

        public void SetGraph(int[,] value)
        {
            _graph = value;
        }
        public Graph(List<IDataPoint> dataPoints, int size)
        {
            DataPoints = dataPoints;
            _size = size;
            CreateGraph(dataPoints);
        }



        private void CreateGraph(List<IDataPoint> dataPoints)
        {
            _graph = new int[_size, _size];

            for (int i = 0; i < _graph.GetLength(0); i++)
            {
                for (int j = 0; j < _graph.GetLength(1); j++)
                {
                    foreach (IDataPoint data in dataPoints)
                    {
                        if (data.X == i && data.Y == j)
                        {
                            switch (data)
                            {
                                case DataPoint dataPoint:
                                    _graph[i, j] = 1;
                                    break;

                                case Centroid centroid:
                                    _graph[i, j] = 2;
                                    break;

                                default:
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            _graph[i, j] = 0;
                        }
                    }
                }
            }
        }

        public void UpdateGraph(List<Centroid> centroids)
        {
            Centroids = centroids;
            foreach (IDataPoint data in DataPoints)
            {
                if (data is Centroid)
                    DataPoints.Remove(data);
            }

            foreach (Centroid centroid in Centroids)
            {
                DataPoints.Add(centroid);
            }
            CreateGraph(DataPoints);
        }
    }
}
