﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REP001.Comun.BO
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateBird { get; set; }
        public int Age { get { return ((int)((DateBird - DateTime.Today).TotalDays/365) - 1); } }
    }
}