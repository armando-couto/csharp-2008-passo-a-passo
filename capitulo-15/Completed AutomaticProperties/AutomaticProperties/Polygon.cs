using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomaticProperties
{
    class Polygon
    {
        public Polygon()
        {
            this.NumSides = 4;
            this.SideLength = 10.0;
        }

        public int NumSides { get; set; }
        public double SideLength { get; set; }
    }
}
