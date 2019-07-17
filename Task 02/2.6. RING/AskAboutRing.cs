using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6.RING
{
    class AskAboutRing
    {
        private int x;
        public int X
        {
            get { return x; }
        }
        private int y;
        public int Y
        {
            get { return y; }
        }
        private uint r1;
        public uint R1
        {
            get { return r1; }
        }
        private uint r2;
        public uint R2
        {
            get { return r2; }
        }

        public AskAboutRing()
        {
            inputCoord();
            inputInnerRad();
            inputOuterRad();
        }
        public void inputCoord()
        {
            String s;
            Console.Write("Введите координаты центра кольца: - X: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out x))
            {
                x = Convert.ToInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputCoord(); }

            Console.Write("\t\t\t\t- Y: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out y))
            {
                y = Convert.ToInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputCoord(); }
        }


        public void inputInnerRad()
        {
            String s;
            
            Console.Write("Введите внутренний радиус кольца: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (uint.TryParse(s, out r1))
            {
                r1 = Convert.ToUInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputInnerRad(); }
        }
        public void inputOuterRad()
        {
            String s;

            Console.Write("Введите внешний радиус кольца: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (uint.TryParse(s, out r2))
            {
                r2 = Convert.ToUInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputOuterRad(); }
        }
    }
}
