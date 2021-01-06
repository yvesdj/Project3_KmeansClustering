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
                Centroid centroid = new Centroid(random.Next(0, Graph.GetGraph().GetLength(0)), random.Next(0, Graph.GetGraph().GetLength(1)));
                Centroids.Add(centroid);
            }
        }
    }
}
