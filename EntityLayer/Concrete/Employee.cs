﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
