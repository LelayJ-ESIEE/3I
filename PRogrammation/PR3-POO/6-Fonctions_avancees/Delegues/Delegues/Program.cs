using System;

namespace Delegues
{
    class Program
    {
        public delegate void IntAction(int i);
        public static void PrintInt(int i)
        {
            Console.WriteLine(i);
        }
        public static void PrintIntSquare(int i)
        {
            Console.WriteLine(i*i);
        }
        public static void Perform(IntAction d, params int[] t)
        {
            foreach (int i in t)
                d(i);
        }
        static void Main(string[] args)
        {
            IntAction act = x => PrintInt(x);
            act(42);
            int[] tab = { 1, 2, 3, 4 };
            Perform(act, tab);
            Perform(act, 9, 8, 7, 6, 5);
            act = x => PrintIntSquare(x);
            Perform(act, tab);
            Console.Read();
        }
    }
}
