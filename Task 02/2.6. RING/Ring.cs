using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._6.RING
{
    class Ring
    {
        Round innerRound;
        Round outerRound;

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
        private uint innerR;
        public uint InnerR
        {
            get { return innerR; }
        }
        private uint outerR;
        public uint OuterR
        {
            get { return outerR; }
        }

        private double areaOfRing;
        public double AreaOfRing
        {
            get { return areaOfRing; }
        }

        private double summaryLengtgOfCircles;
        public double SummaryLengtgOfCircles
        {
            get { return summaryLengtgOfCircles; }
        }

        public Ring(Round round1, Round round2)
        {
            innerRound = round1;
            outerRound = round2;
            x = round1.X;
            y = round2.Y;
            innerR = round1.R;
            outerR = round2.R;
        }

        public double searchAreaOfRing()
        {
            return areaOfRing = outerRound.searchAreaOfRound() - innerRound.searchAreaOfRound();
        }

        public double searchSummaryLengtgOfCircles()
        {
            return summaryLengtgOfCircles = outerRound.searchLengthOfCircle() + innerRound.searchLengthOfCircle();
        }
    }
}
