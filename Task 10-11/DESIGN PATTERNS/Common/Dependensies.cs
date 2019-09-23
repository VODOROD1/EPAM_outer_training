using _6._1.USERS_.Entities;
using _6._1.USERS_.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1.USERS_.Common
{
    public static class Dependensies
    {
        static IStorable textFiles = new TextFiles();
        public static IStorable TextFiles { get { return textFiles; } }
    }
}
