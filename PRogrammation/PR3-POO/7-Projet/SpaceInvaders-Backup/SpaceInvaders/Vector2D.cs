using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Vector2D
    {
        private double x, y;

        public double Norme
        {
            get
            {
                return Math.Sqrt(this.x * this.x + this.y * this.y);
            }
        }

        public Vector2D(double pX = 0, double pY = 0)
        {
            this.x = pX;
            this.y = pY;
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2D operator -(Vector2D v)
        {
            return new Vector2D(-v.x, -v.y);
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2D operator *(Vector2D v, double d)
        {
            return new Vector2D(v.x * d, v.y * d);
        }

        public static Vector2D operator *(double d, Vector2D v)
        {
            return v * d;
        }

        public static Vector2D operator /(Vector2D v, double d)
        {
            return new Vector2D(v.x / d, v.y / d);
        }
    }
}
