using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VECTOR_GRAPHICS_EDITOR
{
    abstract class Figure
    {
        public String TypeOfFigure { get; set; }
        protected List<Point> points = new List<Point>();
        public double Length { get; set; }
        public Figure(int[,] coords)
        {
            createPoints(coords);
        }
        public Figure(int amountOfPoints)
        {
            int[,] coords = new int [amountOfPoints, 2];
            ask(coords);
            createPoints(coords);
        }
        public virtual void searchLength()
        {

        }
        public void ask(int[,] coords)
        {
            String x = " ";
            String y = " ";
            for (int i = 0; i < coords.GetLength(0); i++)
            {
                Console.WriteLine($"Введите координаты {i+1}-й точки фигуры: ");
                while (true)
                {
                    Console.Write($"\t-X: ");
                    x = Console.ReadLine();
                    if (int.TryParse(x, out coords[i, 0]))
                    {
                        coords[i, 0] = Convert.ToInt32(x);
                        break;
                    }
                    else { Console.WriteLine("Введите число!"); }
                }
                while (true)
                {
                    Console.Write("\t-Y: ");
                    y = Console.ReadLine();
                    if (int.TryParse(y, out coords[i, 1]))
                    {
                        coords[i, 1] = Convert.ToInt32(y);
                        break;
                    }
                    else { Console.WriteLine("Введите число!"); }
                }
            }
            checkSamePoints(coords);
        }
        public void checkSamePoints(int[,] coords)
        {
            bool flag = true;
            for (int i = 0; i < coords.GetLength(0) && flag; i++)
            {
                for (int j = i+1; j < coords.GetLength(0); j++) {
                    if (coords[i, 0] == coords[j, 0] && coords[i, 1] == coords[j, 1])
                    {
                        Console.WriteLine($"{i}-я точка и {j}-я точка совпадают -- это не допустимо! +" +
                            $"Снова введите координаты всех точек! ");
                        ask(coords);
                        flag = false;
                        break;
                    }
                    else { continue;}
                }
            }
        }
        public void createPoints(int[,] coords)
        {
            for (int i = 0; i < coords.GetLength(0); i++)
            {
                points.Add(new Point(coords[i,0], coords[i, 1]));
            }
        }
    }
}