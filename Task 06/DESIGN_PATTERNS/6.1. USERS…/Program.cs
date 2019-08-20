using _6._1.USERS_.Common;
using _6._1.USERS_.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1.USERS_
{
    class Program
    {
        static void Main(string[] args)
        {
            IUI CUI = new ConsoleUI();
            CUI.SelectOption();
        }
    }
}