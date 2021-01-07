using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Classes
{
    public class Algorithme
    {
        private Random random = new Random();
        public List<Centroid> Centroids { get; set; }
        public Graph Graph { get; set; }
        public bool IsConverged { get; set; }


        public Algorithme(int k, Graph graph)
        {
            Graph = graph;
            GenerateCentroids(k);
            IsConverged = false;
        }

        private void GenerateCentroids(int k)
        {
            Centroids = new List<Centroid>();

            for (int i = 0; i < k; i++)
            {
                Centroid centroid = new Centroid(random.Next(0, Graph.GetGraph().GetLength(0)), random.Next(0, Graph.GetGraph().GetLength(1)), i);
                Centroids.Add(centroid);
                Graph.DataPoints.Add(centroid);
            }
        }

        private void AssignDataToCentroids()
        {
            foreach (Centroid centroid in Centroids)
            {
                foreach (IDataPoint iData in Graph.DataPoints)
                {
                    if (iData is DataPoint data)
                    {
                        double distance = EuclideanDistanceSquared(centroid, data);
                        if (distance < data.Distance || data.Distance == 0)
                        {
                            data.Distance = distance;
                            data.AssignedCentroid = centroid;
                            centroid.DataPoints.Add(data);
                        }
                    }
                }
            }

        }

        private void UpdateCentroidPositions()
        {
            foreach (Centroid centroid in Centroids)
            {
                if (centroid.DataPoints.Count == 0)
                {
                    break;
                }
                else
                {
                    int sumX = 0;
                    int sumY = 0;
                    foreach (IDataPoint data in centroid.DataPoints)
                    {
                        sumX += data.X;
                        sumY += data.Y;
                    }

                    int averageX = (int)(sumX / centroid.DataPoints.Count);
                    int averageY = (int)(sumY / centroid.DataPoints.Count);

                    //if (centroid.X == )
                    //{

                    //}
                    centroid.X = averageX;
                    centroid.Y = averageY;
                    centroid.DataPoints.Clear();
                }
            }
        }

        public void PrintAssignedValues()
        {
            int i = 1;
            foreach (IDataPoint dataPoint in Graph.DataPoints)
            {
                if (dataPoint is DataPoint data)
                    Console.WriteLine("{0,15} {1,5} {2,5} {3,30} {4,30}", "#" + i, "X: " + data.X,"Y: " + data.Y, "Assigned Centroid: " + (data.AssignedCentroid.id + 1), "Distance: " + data.Distance);
                i++;
            }
            Console.WriteLine("------------------------------------------------------------------------------");
            for (int j = 0; j < Centroids.Count; j++)
            {
                Console.WriteLine("{0,15} {1,5} {2,5}", "Centroid #" + j, "X: " + Centroids[j].X, "Y: " + Centroids[j].Y);
                foreach (IDataPoint iData in Centroids[j].DataPoints)
                {
                    Console.WriteLine("{0,15} {1,5} {2,5}", "#" + i, "X: " + iData.X, "Y: " + iData.Y);
                }
            }
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
        }

        private double EuclideanDistanceSquared(Centroid centroid, DataPoint data)
        {
            return Math.Sqrt(Math.Pow(centroid.X - data.X, 2) + Math.Pow(centroid.Y - data.Y, 2));
        }

        public void UpdateClusters()
        {
            AssignDataToCentroids();
            PrintAssignedValues();
            UpdateCentroidPositions();
            Graph.UpdateGraph();
        }


    }
}
