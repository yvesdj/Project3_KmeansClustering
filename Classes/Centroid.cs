using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3.Classes
{
    public class Centroid : IDataPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public List<IDataPoint> DataPoints { get; set; }

        public bool IsConverged { get; set; }

        public int id;

        public Centroid(int x, int y, int id)
        {
            X = x;
            Y = y;
            DataPoints = new List<IDataPoint>();
            IsConverged = false;
            this.id = id;
        }
    }
}
