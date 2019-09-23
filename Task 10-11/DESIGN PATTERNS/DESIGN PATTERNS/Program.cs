using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESIGN_PATTERNS
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
