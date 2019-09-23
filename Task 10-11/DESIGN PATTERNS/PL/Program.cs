using _6._1.USERS_.Entities;
using _6._1.USERS_.PL;
using System;

namespace PL
{
    class Program
    {
        static void Main(string[] args)
        {
            IUI CUI = new ConsoleUI();
            CUI.LaunchCode();
        }
    }
}
