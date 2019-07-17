using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6.RING
{
    class Round
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
        private uint r;
        public uint R
        {
            get { return r; }
        }

        private double lengtgOfCircle;
        public double LengtgOfCircle
        {
            get { return lengtgOfCircle; }
        }

        private double areaOfRound;

        public double AreaOfRound
        {
            get { return areaOfRound; }
            set { areaOfRound = value; }
        }

        public Round(int x, int y, uint r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }

        public double searchAreaOfRound()
        {
            return areaOfRound = 3.14 * r * r;
        }

        public double searchLengthOfCircle()
        {
            return lengtgOfCircle = 2 * 3.14 * r;
        }
    }
}
