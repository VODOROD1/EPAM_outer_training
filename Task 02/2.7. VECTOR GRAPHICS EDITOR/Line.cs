using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VECTOR_GRAPHICS_EDITOR
{
    class Line : Figure, IDrawable
    {
        
        public Line(int[,] coords) : base(coords)
        {
            searchLength();
        }
        public Line(int amountOfPoints) : base(amountOfPoints)
        {
            TypeOfFigure = "Линия";
            searchLength();
        }
        public override void searchLength()
        {   
            Length = Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2));
        }
        public void draw()
        {
            Console.WriteLine("Свойства выбранной фигуры:");
            Console.WriteLine($"\t - Фигура типа \"{TypeOfFigure}\" ");
            Console.WriteLine($"\t - Длина линии равна {Length} ");
        }
    }
}
