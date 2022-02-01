using System;

namespace Cartes
{
    enum Enseigne { Pique, Coeur, Carreau, Trèfle }
    enum Valeur { As, Roi, Dame, Valet, Deux, Trois, Quatre, Cinq, Six, Sept, Huit, Neuf, Dix }
    class Program
    {
        static void Main(string[] args)
        {
            Jeu game = new Jeu();
            foreach(Carte carte in game.Cartes)
            {
                Console.WriteLine("" + carte);
            }
            Console.ReadLine();
        }
    }
}
