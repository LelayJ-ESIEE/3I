using System;

namespace duree
{
    class Program
    {
        static void Main(string[] args)
        {
            Duree d = new Duree(70); // durée de 70 secondes
            Console.WriteLine(d.DureeSeconde); // 70
            d.DureeMinute = -2;
            Console.WriteLine(d.DureeSeconde); // 70
            Console.WriteLine(d.DureeMinute); // 2
            d.DureeMinute = 2;
            Console.WriteLine(d.DureeSeconde); // 120
            Console.Read();
        }
    }
}
