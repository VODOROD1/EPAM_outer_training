using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.DYNAMIC_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 12, 3, 45, -9, 0, 32 };
            int result = Array.Find(arr, i => i.Equals(12));
        }
    }
}
