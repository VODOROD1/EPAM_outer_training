using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME
{
    abstract class Bonus : GenObj
    {
        public int RecoveryPoints { get; set; }
        public Bonus(int weight, int length, int width, String color, int recoveryPoints)
            : base(weight, length, width, color)
        {
            this.RecoveryPoints = recoveryPoints;
        }
        public void RaiseCharacts()
        {

        } 
    }

    class Apple : Bonus
    {
        public Apple() : base(weight: 1, length: 1, width: 1, color: "Green", recoveryPoints: 5)
        {

        }
        public override void CreateCoords()
        {

        }
    }

    class Honey : Bonus
    {
        public Honey() : base(weight: 3, length: 1, width: 1, color: "Yellow", recoveryPoints: 10)
        {

        }
        public override void CreateCoords()
        {

        }
    }

    class Water : Bonus
    {
        public Water() : base(weight: 15, length: 1, width: 1, color: "Blue", recoveryPoints: 15)
        {
            
        }
        public override void CreateCoords()
        {

        }
    }

    class Juice : Bonus
    {
        public Juice() : base(weight: 3, length: 1, width: 1, color: "Red", recoveryPoints: 25)
        {
            
        }
        public override void CreateCoords()
        {

        }
    }

    class ParticleOfEnergy : Bonus
    {
        public ParticleOfEnergy() : base(weight: 10, length: 1, width:1, color: "Violet", recoveryPoints: 15)
        {
            
        }
        public override void CreateCoords()
        {

        }
    }
}
