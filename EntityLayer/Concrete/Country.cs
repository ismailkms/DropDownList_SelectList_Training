﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> People { get; set; }
        public ICollection<City> Cities { get; set; }

    }
}
