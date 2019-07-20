using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME
{
    abstract class Obstacle : GenObj
    {
        public Obstacle(int weight, int length, int width, String color)
            : base(weight, length, width, color)
        {

        }
    }

    class Tree : Obstacle
    {
        public Tree() : base(weight: 200, length: 1, width: 1, color: "Brown")
        {
            
        }
        public override void CreateCoords()
        {

        }
    }

    class Stone : Obstacle
    {
        public Stone() : base(weight: 4000, length: 2, width: 2, color: "Gray")
        {

        }
        public override void CreateCoords()
        {

        }
    }

    class Fence : Obstacle
    {
        public Fence() : base(weight: 1000, length: 30, width: 1, color: "Yellow")
        {

        }
        public override void CreateCoords()
        {

        }
    }

    class Puddle : Obstacle
    {
        public Puddle() : base(weight: 100, length: 4, width: 4, color: "Blue")
        {

        }
        public override void CreateCoords()
        {

        }
    }

    class House : Obstacle
    {
        public House() : base(weight: 100000, length: 20, width: 15, color: "Green")
        {
        }
        public override void CreateCoords()
        {

        }
    }
}
