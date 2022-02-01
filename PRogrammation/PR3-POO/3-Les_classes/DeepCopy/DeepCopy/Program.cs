using System;
using System.Diagnostics;


namespace DeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Décomentez pour tester

            Point p1 = new Point(1,2);
            Point p2 = new Point(p1); // deep copy

            p2.x = 3;
            Debug.Assert(p1.x != p2.x, "Problème sur le constructeur par copie de Point.");

            Point[] points = {p1, p2};
            
            Polygone po1 = new Polygone(points);
            Polygone po2 = new Polygone(po1); // deep(er) copy

            po2.points[0].x = 4;
            Debug.Assert(po2.points[0].x != po1.points[0].x, "Problème sur le constructeur par copie de Polygone.");
        }
    }
}
