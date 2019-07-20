using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._8.GAME
{
    interface IMovable
    {
        int Speed { get; set; }
        
        void Move();
        void GoLeft();
        void GoRight();
        void GoUp();
        void GoDown();
    }
}
