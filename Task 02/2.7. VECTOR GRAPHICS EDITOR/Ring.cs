using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VECTOR_GRAPHICS_EDITOR
{
    class Ring : Figure, IDrawable
    {
        public Round InnerRound{ get; set; }
        public Round OuterRound { get; set; }
        public double Area { get; set; }
        public Ring(int amountOfPoints) : base(amountOfPoints)
        {
            TypeOfFigure = "Кольцо";
            createRounds();
            searchLength();
            searchArea();
        }
        //агрегируем класс Round
        public void createRounds()
        {
            InnerRound = new Round(new int[,] { { points[0].X, points[0].Y },
                                           {points[1].X, points[1].Y}});
            OuterRound = new Round(new int[,] { { points[0].X, points[0].Y },
                                           {points[2].X, points[2].Y}});
        }
        public override void searchLength()
        {
            Length = InnerRound.Length + OuterRound.Length;
        }
        public void searchArea()
        {
            Area = OuterRound.Area - InnerRound.Area;
        }
        public void draw()
        {
            Console.WriteLine("Свойства выбранной фигуры:");
            Console.WriteLine($"\t - Фигура типа \"{TypeOfFigure}\" ");
            Console.WriteLine($"\t - Суммарная длина внешней и внутренней окружностей {Length} ");
            Console.WriteLine($"\t - Площадь кольца равна {Area} ");
        }
    }
}