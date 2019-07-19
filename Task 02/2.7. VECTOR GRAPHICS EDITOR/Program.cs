using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7.VECTOR_GRAPHICS_EDITOR
{
    class Program
    {
        static void Main(string[] args)
        {
            IDrawable draw;
            char choice;
            askChoice(out choice);
            createFigure(choice, out draw);
            draw.draw();
            Console.ReadKey();
        }

        public static void askChoice(out char choice)
        {
            char choiceLocal = ' ';
            Console.WriteLine("Даны фигуры: ");
            Console.WriteLine("\t1) Линия");
            Console.WriteLine("\t2) Прямоугольник");
            Console.WriteLine("\t3) Окружность");
            Console.WriteLine("\t4) Круг");
            Console.WriteLine("\t5) Кольцо");
            
            while (true) {
                Console.Write("Выберите тип фигуры: ");
                choiceLocal = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (!(char.IsDigit(choiceLocal) && Convert.ToInt32(choiceLocal)>0))     //Провести проверку на отрицательные числа
                {
                    Console.WriteLine("Введите цифру!");
                }
                else { break; }
            }
            choice = choiceLocal;
        }
        //применим полиморфизм
        public static void createFigure(char choice, out IDrawable draw)
        {
            IDrawable drawLocal = null;
            switch (choice){
                case '1':
                    drawLocal = new Line(2);
                    break;
                case '2':
                    drawLocal = new Rectangle(2);
                    break;
                case '3':
                    drawLocal = new Circle(2);
                    break;
                case '4':
                    drawLocal = new Round(2);
                    break;
                case '5':
                    drawLocal = new Ring(3);
                    break;
            }
            draw = drawLocal;
        }
    }
}
