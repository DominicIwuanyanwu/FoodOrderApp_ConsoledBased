﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace just_nom.Food
{
    internal class Garnish
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Garnish (string _name, double _price)
        {
            Name = _name;
            Price = _price;
        }
    }
}
