using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME
{
    class Field
    {
        public int Length { get; set; } = 100;
        public int Width { get; set; } = 100;

        Point[,] points;
        public Point this[int i, int j]
        {
            get
            {
                return points[i, j];
            }
            set
            {
                points[i, j] = value;
            }
        }

        public Field()
        {
            points = new Point[Length, Width];
            CreatePoints();
        }

        public void CreatePoints()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = i; j < Width; j++)
                {
                    points[i, j] = new Point(i, j);
                }
            }
        }
    }
}