using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME
{
    abstract class Enemy : GenObj, IMovable
    {
        public int Speed { get; set; }
        public int Damage { get; set; }
        protected List<Point> currentPositions = new List<Point>();

        public Enemy(int weight, int length, int width, String color, int speed, int damage) 
            : base(weight, length, width, color)
        {
            this.Speed = speed;
            this.Damage = damage;
        }

        public List<Point> GetContinuePosition()
        {
            return currentPositions;
        }
        public abstract void attack();

        public void GoDown()
        {
            Console.WriteLine($"Враг {this.GetType()} передвинулся вниз");
        }

        public void GoLeft()
        {
            Console.WriteLine($"Враг {this.GetType()} передвинулся влево");
        }

        public void GoRight()
        {
            Console.WriteLine($"Враг {this.GetType()} передвинулся вправо");
        }

        public void GoUp()
        {
            Console.WriteLine($"Враг {this.GetType()} передвинулся вверх");
        }

        public abstract void Move();
    }

    class Wolf : Enemy
    {
        public Wolf() : base(weight: 40, length: 2, width: 1, color: "Grey", speed: 20, damage: 25)
        {

        }
        public override void Move()
        {

        }
        public override void CreateCoords()
        {
            int amountPoints = 2;
        }
        public override void attack()
        {

        }

    }

    class Bear : Enemy
    {
        public Bear() : base(weight: 200, length: 3, width: 2, color: "Brown", speed: 10, damage: 45)
        {

        }
        public override void Move()
        {

        }
        public override void CreateCoords()
        {

        }
        public override void attack()
        {
            int amountPoints = 6;
        }
    }

    class Spider : Enemy
    {
        public Spider() : base(weight: 20, length: 1, width: 1, color: "Black", speed: 5, damage: 20)
        {

        }
        public override void Move()
        {

        }
        public override void CreateCoords()
        {
            int amountPoints = 2;
        }
        public override void attack()
        {

        }
    }

    class Zombie : Enemy
    {
        public Zombie() : base(weight: 60, length: 1, width: 1, color: "gray-green", speed: 2, damage: 10)
        {

        }
        public override void Move()
        {

        }
        public override void CreateCoords()
        {

        }
        public override void attack()
        {
            int amountPoints = 1;
        }
    }

    class GreenSkin : Enemy
    {
        public GreenSkin() : base(weight: 150, length: 1, width: 2, color: "Green", speed: 12, damage: 35)
        {

        }
        public override void Move()
        {

        }
        public override void CreateCoords()
        {
            int amountPoints = 2;
        }
        public override void attack()
        {

        }
    }
}
