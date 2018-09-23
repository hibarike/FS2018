using System;

[assembly: CLSCompliant(true)]
namespace Calc
{
    class Program
    {
        static void Main()
        {
            Calc c = new Calc();
            ulong ans = c.Add(10, 84);
            Console.WriteLine("10 + 84 is: {0}", ans);
            Console.ReadLine();
        }
    }

    class Calc
    {
        public ulong Add(int x, int y) {
            return (ulong)(x + y);
        }
    }
}
