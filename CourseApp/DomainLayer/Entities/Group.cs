﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Group
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateDate { get; set; }
        public Teacher Teacher { get; set; }

    }
}
