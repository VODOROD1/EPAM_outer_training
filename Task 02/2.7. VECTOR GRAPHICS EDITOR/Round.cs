using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VECTOR_GRAPHICS_EDITOR
{
    class Round : Circle, IDrawable
    {
        public double Area { get; set; }
        public Round(int[,] coords) : base(coords)
        {
            searchArea();
        }
        public Round(int amountOfPoints) : base(amountOfPoints)
        {
            TypeOfFigure = "Круг";
            searchArea();
        }

        public void searchArea()
        {
            Area = 3.14 * Math.Pow(Radious.Length, 2);
        }
        public new void draw()
        {
            Console.WriteLine("Свойства выбранной фигуры:");
            Console.WriteLine($"\t - Фигура типа \"{TypeOfFigure}\" ");
            Console.WriteLine($"\t - Длина описанной окружности равна {Length} ");
            Console.WriteLine($"\t - Площадь круга равна {Area} ");
        }
    }
}
