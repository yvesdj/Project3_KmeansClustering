using Project3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    public class DataPoint : IDataPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public double Distance { get; set; }
        public Centroid AssignedCentroid { get; set; }

        public DataPoint()
        {
        }
        public DataPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
