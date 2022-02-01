using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy
{
    class Polygone
    {
        public Point[] points;

        public Polygone(Point[] points)
        {
            this.points = points;
        }

        public Polygone(Polygone P)
        {
            this.points = new Point[P.points.Length];
            for(int i = 0; i<this.points.Length; i++)
            {
                this.points[i] = new Point(P.points[i]);
            }

        }
    }
}
