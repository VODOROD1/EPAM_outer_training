using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2.TRIANGLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tri = new Triangle();
            Console.WriteLine($"Периметр треугольника: {tri.Perimeter}");
            Console.WriteLine($"Площадь треугольника: {tri.Area}");
            Console.ReadKey();
        }
    }
}