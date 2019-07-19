using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VECTOR_GRAPHICS_EDITOR
{
    class Rectangle : Figure, IDrawable
    {
        Line[] lines;
        public double Area { get; set; }
        public Rectangle(int amountOfPoints) : base(amountOfPoints)
        {
            TypeOfFigure = "Прямоугольник";
            lines = new Line[4];
            createLines();
            searchLength();
            searchArea();
        }
        //Далее произведем агрегацию класса Line
        public void createLines()
        {
            lines[0] = new Line(new int[,] { { points[0].X, points[0].Y },
                                           {points[0].X, points[1].Y}});
            lines[1] = new Line(new int[,] { { points[0].X, points[1].Y },
                                           {points[1].X, points[1].Y}});
            lines[2] = new Line(new int[,] { { points[1].X, points[1].Y },
                                           {points[1].X, points[0].Y}});
            lines[3] = new Line(new int[,] { { points[1].X, points[0].Y },
                                           {points[0].X, points[0].Y}});
        }
        public override void searchLength()
        {
            Length = lines[0].Length + lines[1].Length + lines[2].Length + lines[3].Length;
        }
        public void searchArea()
        {
            Area = lines[0].Length * lines[1].Length;
        }
        public void draw()
        {
            Console.WriteLine("Свойства выбранной фигуры:");
            Console.WriteLine($"\t - Фигура типа \"{TypeOfFigure}\" ");
            Console.WriteLine($"\t - Периметр прямоугольника равен {Length} ");
            Console.WriteLine($"\t - Площадь прямоугольника равна {Area} ");
        }
    }
}
