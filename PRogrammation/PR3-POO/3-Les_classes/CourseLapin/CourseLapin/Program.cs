using System;

namespace CourseLapin
{
    class Program
    {
        static void Main(string[] args)
        {
            Lapin L1 = new Lapin("Lazlow", 2), L2 = new Lapin("Glasgow", 4), L3 = new Lapin("Carow", 1);
            Lapin[] Lapins = { L1, L2, L3 };

            for(int i = 0; i<100; i++)
            {
                foreach (Lapin L in Lapins)
                    L.Avancer();
            }

            Console.WriteLine("Positions finales :");
            foreach (Lapin L in Lapins)
                Console.WriteLine("    " + L.Surnom + " : " + L.Position);

            Console.WriteLine("\nLe gagnant est : {0}", (L1.Position > L2.Position) ? ((L1.Position > L3.Position) ? L1.Surnom : L3.Surnom) : ((L2.Position > L3.Position) ? L2.Surnom : L3.Surnom));
            Console.ReadLine();
        }
    }
}
