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


        public Algorithme(int k, Graph graph)
        {
            Graph = graph;
            GenerateCentroids(k);
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
                        }
                    }
                }
            }

        }

        public void PrintAssignedValues()
        {
            int i = 1;
            foreach (IDataPoint dataPoint in Graph.DataPoints)
            {
                if (dataPoint is Centroid centroid)
                    Console.WriteLine("{0,15} {1,5} {2,5}", "Centroid #" + i, "X: " + centroid.X, "Y: " + centroid.Y);
                if (dataPoint is DataPoint data)
                    Console.WriteLine("{0,15} {1,5} {2,5} {3,30} {4,30}", "#" + i, "X: " + data.X,"Y: " + data.Y, "Assigned Centroid: " + (data.AssignedCentroid.id + 1), "Distance: " + data.Distance);
                i++;
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

        public void UpdateCentroids()
        {
            AssignDataToCentroids();
            Graph.UpdateGraph();
        }


    }
}
