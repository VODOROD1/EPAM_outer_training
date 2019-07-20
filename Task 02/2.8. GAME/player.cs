using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME 
{
    class Player : GenObj, IMovable
    {
        public int HP { get; set; }
        public int Stamina { get; set; }
        public int Mana { get; set; }
        public int Speed { get; set; }
        public int SpeedFaster { get; set; }
        public char PressedKey { get; set; }
        protected Point[] currentPositions;
        public Player()
            : base(weight : 80, length : 1, width : 1, color : "White")
        {
            HP = 100;
            Stamina = 100;
            Mana = 100;
            Speed = 15;
            SpeedFaster = 25;
            CreateCoords();
            currentPositions = new Point[startPosition.Length];
            for (int i = 0; i< startPosition.Length; i++)
            {
                currentPositions[i] = startPosition[i];
            }
        }

        public override void CreateCoords()
        {
            int amountPoints = 1;
            //startPosition[,] = ...
            //здесь задается начальная позиция игрока
            int[,] coords = new int[1,1];
            CreatePoints(coords);
        }
        public void ManageCharacter()
        {
            //Здесь производится управление персонажем
            PressedKey = Console.ReadKey().KeyChar;
        }
        public void GoDown()
        {
            Console.WriteLine("Игрок передвигается вниз!");
            
        }

        public void GoLeft()
        {
            Console.WriteLine("Игрок передвигается влево!");
        }

        public void GoRight()
        {
            Console.WriteLine("Игрок передвигается вправо!");
        }

        public void GoUp()
        {
            Console.WriteLine("Игрок передвигается вверх!");
        }
        //Сравниваем все координаты, пройденные игроком, и координаты бонусов.
        public void Move()
        {
            switch (PressedKey) {
                case 'S':
                    GoDown();
                    break;
                case 'A':
                    GoLeft();
                    break;
                case 'D':
                    GoRight();
                    break;
                case 'W':
                    GoUp();
                    break;
            }
        }
        public void DiedPlayer()
        {
            Console.WriteLine("YOU DIED");
        }
        public void TakeAllBonuses()
        {
            Console.WriteLine("YOU WIN");
        }

    }
}