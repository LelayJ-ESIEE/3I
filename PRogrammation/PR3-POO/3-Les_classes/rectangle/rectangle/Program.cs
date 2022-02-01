using System;

namespace rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle vR1 = new Rectangle(20, 30, new int[] { 15, 20 } );
            Console.WriteLine("R1 :");
            Console.WriteLine("  Largeur : " + vR1.Largeur);
            Console.WriteLine("  Hauteur : " + vR1.Hauteur);
            Console.WriteLine("  Position : (" + vR1.Position[0] + ", " + vR1.Position[1] + ")");
            Console.WriteLine("  Aire : " + vR1.Aire() + "\n");

            Rectangle vR2 = new Rectangle();
            vR2.DoublerTaille();
            Console.WriteLine("R2 :");
            Console.WriteLine("  Largeur : " + vR2.Largeur);
            Console.WriteLine("  Hauteur : " + vR2.Hauteur + "\n");

            Console.WriteLine("A(R1) > A(R2) : " + vR1.TestePlusPetit(vR2) + "\n");

            Rectangle vR3 = new Rectangle(vR1);
            vR3.Largeur += 25;
            Console.WriteLine("R1 :");
            Console.WriteLine("  Largeur : " + vR1.Largeur);
            Console.WriteLine("R3 :");
            Console.WriteLine("  Largeur : " + vR3.Largeur + "\n");

            Console.Read();
        }
    }
}
