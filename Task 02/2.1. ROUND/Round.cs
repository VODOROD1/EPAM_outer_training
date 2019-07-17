using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.ROUND
{
    class Round
    {
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private int r;
        public int R
        {
            get { return r; }
            set { if (value < 0) { Console.WriteLine("Радиус не может быть отрицательным!");
                    inputRad();
                }
                else { r = value; } }
        }

        private double lengtgOfCircle;
        public double LengtgOfCircle
        {
            get { return lengtgOfCircle; }
            set { lengtgOfCircle = value; }
        }

        private double areaOfRound;
        public double AreaOfRound
        {
            get { return areaOfRound; }
            set { areaOfRound = value; }
        }

        public Round()
        {
            inputCoord();
            inputRad();
            searchLengthOfCircle();
            searchAreaOfRound();
        }
        public void inputCoord()
        {
            String s;
            Console.Write("Введите координаты центра круга: - X: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out x))
            {
                X = Convert.ToInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputCoord(); }

            Console.Write("                                - Y: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out y))
            {
                Y = Convert.ToInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputCoord(); }
        }
        public void inputRad()
        {
            String s;
            Console.Write("Введите радиус круга: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out r))
            {
                R = Convert.ToInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputRad(); }
        }
        public void searchLengthOfCircle()
        {
            lengtgOfCircle = 2 * 3.14 * r;
        }

        public void searchAreaOfRound()
        {
            areaOfRound = 3.14 * r * r;
        }
    }
}
