using System;

namespace CourseAnimaux
{
    class Program
    {
        static void Main(string[] args)
        {
            Lapin L1 = new Lapin("Lazlow", 2, 0, "Blanc"), L2 = new Lapin("Glasgow", 4, 0, "Noir");
            Tortue T1 = new Tortue("Paris", 56, 0, 5), T2 = new Tortue("Hector", 53, 0, 3);

            Animal[] Animaux = { L1, L2, T1, T2 };

            for (int i = 0; i < 100; i++)
            {
                foreach (Animal A in Animaux)
                    A.Avancer();
            }

            Console.WriteLine("Positions finales :");
            foreach (Animal A in Animaux)
                Console.WriteLine("    " + A.Surnom + " : " + A.Position);

            Console.WriteLine("\nLe gagnant est : {0}", (L1.Position > L2.Position) ? ((L1.Position > T1.Position) ? (L1.Position > T2.Position ? L1.ToString() : T2.ToString()) : (T1.Position > T2.Position ? T1.ToString() : T2.ToString())) : ((L2.Position > T1.Position) ? (L2.Position > T2.Position ? L2.ToString() : T2.ToString()) : (T1.Position > T2.Position ? T1.ToString() : T2.ToString())));
            Console.ReadLine();
        }
    }
}
