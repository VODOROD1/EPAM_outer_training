using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME
{
    abstract class GenObj
    {
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public String Color { get; set; }

        protected Point[] startPosition;
        public GenObj(int weight, int length, int width, String color)
        {
            Weight = weight;
            Length = length;
            Width = width;
            Color = color;
        }
        public Point[] GetStartPosition()
        {
            return startPosition;
        }
        
        //В этом методе задаются начальные координаты для всех объектов на поле
        public abstract void CreateCoords();
        //В этом методе создаются объекты класса Point посредством значений координат
        public void CreatePoints(int[,] coords)
        {
            startPosition = new Point[coords.Length];
            for (int i = 0; i < coords.GetLength(0); i++)
            {
                startPosition[i] = new Point(coords[i, 0], coords[i, 1]);
            }
        }
    }
}
