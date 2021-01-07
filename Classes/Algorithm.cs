using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Classes
{
    public class Algorithm
    {
        private Random random = new Random();
        public List<Centroid> Centroids { get; set; }
        public Graph Graph { get; set; }
        public bool IsConverged { get; set; }


        public Algorithm(int k, Graph graph)
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

                    if (averageX == centroid.X && averageY == centroid.Y)
                    {
                        centroid.IsConverged = true;
                    }
                    else
                    {
                        centroid.X = averageX;
                        centroid.Y = averageY;
                        centroid.DataPoints.Clear();
                    }


                }
            }
        }

        private void CheckAllCentroidConverged()
        {
            for (int i = 0; i < Centroids.Count; i++)
            {
                if (!Centroids[i].IsConverged)
                    break;
                IsConverged = true;
            }
        }

        public void PrintAssignedValues()
        {
            for (int j = 0; j < Centroids.Count; j++)
            {
                Console.WriteLine("{0,15} {1,5} {2,5}", "Centroid #" + j, "X: " + Centroids[j].X, "Y: " + Centroids[j].Y);
                int i = 1;
                foreach (IDataPoint iData in Centroids[j].DataPoints)
                {
                    Console.WriteLine("{0,15} {1,5} {2,5}", "#" + i, "X: " + iData.X, "Y: " + iData.Y);
                    i++;
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
            CheckAllCentroidConverged();
        }


    }
}
