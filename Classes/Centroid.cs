﻿using System;
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

        public Centroid(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
