﻿using System;
using System.Collections.Generic;

namespace _6._1.USERS_.Common
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public uint Age { get; set; }
    }
}