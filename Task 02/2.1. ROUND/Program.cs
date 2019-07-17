using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.ROUND
{
    class Program
    {
        public static void Main(string[] args)
        {
            Round round = new Round();

            Console.WriteLine($"Окружность имеет длину: {round.LengtgOfCircle}");
            Console.WriteLine($"Круг с координатами центра [{round.X}, {round.Y}], имеет площадь: {round.AreaOfRound}");
            Console.ReadKey();
        }
    }
}
