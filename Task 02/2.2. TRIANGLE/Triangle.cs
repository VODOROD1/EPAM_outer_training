using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2.TRIANGLE
{
    class Triangle
    {
        private int a;
        public int A
        {
            get { return a; }
            set {
                if (value < 0)
                {
                    Console.WriteLine("Значение длины стороны не может быть отрицательным!");
                    inputA();
                }
                else { a = value; }
            }
        }
        private int b;
        public int B
        {
            get { return b; }
            set {
                if (value < 0)
                {
                    Console.WriteLine("Значение длины стороны не может быть отрицательным!");
                    inputB();
                }
                else { b = value; }
            }
        }
        private int c;
        public int C
        {
            get { return c; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Значение длины стороны не может быть отрицательным!");
                    inputC();
                }
                else { c = value; }
            }
        }

        private double perimeter;
        public double Perimeter
        {
            get { return perimeter; }
            set { perimeter = value; }
        }

        private double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public Triangle()
        {
            inputA();
            inputB();
            inputC();
            perimeterOfTriangle();
            areaOfTriangle();
        }
        public void inputA()
        {
            String s;
            Console.Write("Введите числовое значение длины стороны A: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out a))
            {
                A = Convert.ToInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputA(); }
        }
        public void inputB()
        {
            String s;
            Console.Write("Введите числовое значение длины стороны B: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out b))
            {
                B = Convert.ToInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputB(); }
        }
        public void inputC()
        {
            String s;
            Console.Write("Введите числовое значение длины стороны C: ");
            s = Console.ReadLine();
            Console.WriteLine();
            if (int.TryParse(s, out c))
            {
                C = Convert.ToInt32(s);
            }
            else { Console.WriteLine("Введите число!"); inputC(); }
        }
        public void perimeterOfTriangle()
        {
            perimeter = a + b + c;
        }
        public void areaOfTriangle()
        {
            double p = perimeter / 2;
            Console.WriteLine($"{p}");
            area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}