using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6.RING
{
    class Program
    {
        static void Main(string[] args)
        {
            AskAboutRing ask = new AskAboutRing();
            Round round1 = new Round(ask.X, ask.Y, ask.R1);
            Round round2 = new Round(ask.X, ask.Y, ask.R2);
            Ring ring = new Ring(round1, round2);
            outAboutRing(ring);
        }

        public static void outAboutRing(Ring ring)
        {
            Console.WriteLine($"Площадь кольца: {ring.searchAreaOfRing()}");
            Console.WriteLine($"Суммарная длина внешней и внутренней окружностей: {ring.searchSummaryLengtgOfCircles()}");
            Console.ReadKey();
        }
    }
}
