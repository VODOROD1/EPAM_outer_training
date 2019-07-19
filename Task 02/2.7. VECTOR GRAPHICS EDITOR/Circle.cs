using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VECTOR_GRAPHICS_EDITOR
{
    class Circle : Figure, IDrawable
    {
        public Line Radious { get; set; }
        public Circle(int[,] coords) : base(coords)
        {
            createRadious();
            searchLength();
        }
        public Circle(int amountOfPoints) : base(amountOfPoints)
        {
            TypeOfFigure = "Окружность";
            createRadious();
            searchLength();
        }
        //Найдем радиус посредством агрегации класса Line
        public void createRadious()
        {
            Radious = new Line(new int[,] { { points[0].X, points[0].Y },
                                           {points[1].X, points[1].Y}});
        }
        public override void searchLength()
        {
            Length = 2 * 3.14 * Radious.Length;
        }
        public void draw()
        {
            Console.WriteLine("Свойства выбранной фигуры:");
            Console.WriteLine($"\t - Фигура типа \"{TypeOfFigure}\" ");
            Console.WriteLine($"\t - Длина окружности равна {Length} ");
        }
    }
}
