using System;

namespace TabInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test 1 :");
            TabInt t = new TabInt(11, -5); // tableau de 11 éléments commençant à l'indice -5
            t[-5] = -5; // initialisation du 1er élément du tableau
            for (int i = t.IStart + 1; i < t.IStart + t.Length; i++)
                t[i] = t[i - 1] + i;
            Console.WriteLine(t[t.IStart + t.Length - 1]); // affichage du dernier élément t[5]

            Console.WriteLine("Test 2 :");
            t = new TabInt(5, 1); // tableau de 5 entiers tous égaux à 0
                                         // commencant à l'indice 1
            t.SetAll(2, 1, 2, 3); // Mets les éléments 1,2,3 à partir de l'indice 2
                                  // t contient maintenant 0 1 2 3 0
            for (int i = 1; i < 6; i++)
                Console.WriteLine("" + t[i]);
            Console.Read();
        }
    }
}
