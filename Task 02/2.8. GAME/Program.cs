using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageObjects SO = new StorageObjects();
            
        }
    }
    //В этом классе создаем все объекты поля и помещаем их в коллекцию.
    class StorageObjects
    {
        List<Obstacle> obstacles = new List<Obstacle>();
        List<Bonus> bonuses = new List<Bonus>();
        List<Enemy> enemies = new List<Enemy>();

        public StorageObjects()
        {
            obstacles[0] = new Tree();
            // и так далее
            bonuses[0] = new Honey();
            // и так далее
            enemies[0] = new Zombie();
            // и так далее
        }
    }
}